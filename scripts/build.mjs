import { spawnSync } from 'node:child_process';
import { createHash } from 'node:crypto';
import * as fs from 'node:fs/promises';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const root = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '..');
const version = '0.7.31';
const buildOnly = process.argv.includes('--build-only');
const dotnet = process.env.DOTNET_EXE || 'dotnet';
function run(command, args) {
  const result = spawnSync(command, args, { cwd: root, stdio: 'inherit', windowsHide: true });
  if (result.error) throw result.error;
  if (result.status !== 0) throw new Error(`${command} failed with exit code ${result.status}`);
}

for (const project of ['App', 'Launcher']) {
  run(dotnet, ['build', `src/${project}/Twist.${project}.csproj`, '-c', 'Release', '--nologo']);
}
const folder = path.join(root, 'artifacts', `twist-${version}`);
await fs.mkdir(path.join(folder, 'app'), { recursive: true });
await fs.cp(path.join(root, 'runtime', 'app'), path.join(folder, 'app'), { recursive: true });
const executablePaths = {
  'twist Launcher.exe': 'src/Launcher/bin/Release/net48/twist Launcher.exe',
  'app/twist.exe': 'src/App/bin/Release/net48/twist.exe',
};
const executableHashes = {};
for (const [destination, source] of Object.entries(executablePaths)) {
  const data = await fs.readFile(path.join(root, source));
  await fs.writeFile(path.join(folder, destination), data);
  executableHashes[destination] = createHash('sha256').update(data).digest('hex');
}
await fs.copyFile(path.join(root, 'docs', 'PACKAGE.md'), path.join(folder, 'README.md'));
console.log(`Built ${folder}`);
if (!buildOnly) {
  const asset = `releases/twist-${version}-public.zip`;
  await fs.mkdir(path.join(root, 'releases'), { recursive: true });
  run('tar', ['-a', '-cf', asset, '-C', 'artifacts', `twist-${version}`]);
  const data = await fs.readFile(path.join(root, asset));
  const manifest = {
    version,
    asset,
    sha256: createHash('sha256').update(data).digest('hex'),
    bytes: data.length,
    executable_sha256: executableHashes,
    notes: [
      'Added bounded backpack click recovery with Activity diagnostics.',
      'Added Activity TXT export and duplicate-fruit decision details.',
      'Published recovered, buildable source under GPL-3.0.'
    ]
  };
  await fs.writeFile(path.join(root, 'release.json'), JSON.stringify(manifest, null, 2) + '\n');
  await fs.writeFile(path.join(root, 'CHECKSUMS.sha256'), `${manifest.sha256}  ${asset}\n`);
  console.log(`Packaged ${asset}`);
}
