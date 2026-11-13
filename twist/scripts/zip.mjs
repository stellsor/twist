import * as fs from 'node:fs/promises';
import path from 'node:path';

function crc32(data) {
  let crc = 0xffffffff;
  for (const byte of data) {
    crc ^= byte;
    for (let bit = 0; bit < 8; bit++) crc = (crc >>> 1) ^ ((crc & 1) ? 0xedb88320 : 0);
  }
  return (crc ^ 0xffffffff) >>> 0;
}

// Store file entries only. Existing launchers reject directory entries.
export async function createZip(folder, destination) {
  const localEntries = [];
  const centralEntries = [];
  let offset = 0;
  async function addFiles(directory) {
    const entries = await fs.readdir(directory, { withFileTypes: true });
    entries.sort((a, b) => a.name.localeCompare(b.name));
    for (const entry of entries) {
      const filename = path.join(directory, entry.name);
      if (entry.isDirectory()) {
        await addFiles(filename);
        continue;
      }
      const name = Buffer.from(path.basename(folder) + '/' + path.relative(folder, filename).split(path.sep).join('/'));
      const data = await fs.readFile(filename);
      const local = Buffer.alloc(30);
      local.writeUInt32LE(0x04034b50, 0);
      local.writeUInt16LE(20, 4);
      local.writeUInt16LE(0x800, 6);
      local.writeUInt16LE(33, 12);
      local.writeUInt32LE(crc32(data), 14);
      local.writeUInt32LE(data.length, 18);
      local.writeUInt32LE(data.length, 22);
      local.writeUInt16LE(name.length, 26);
      const central = Buffer.alloc(46);
      central.writeUInt32LE(0x02014b50, 0);
      central.writeUInt16LE(20, 4);
      local.copy(central, 6, 4, 30);
      central.writeUInt32LE(offset, 42);
      localEntries.push(local, name, data);
      centralEntries.push(central, name);
      offset += local.length + name.length + data.length;
    }
  }
  await addFiles(folder);
  const centralDirectory = Buffer.concat(centralEntries);
  const end = Buffer.alloc(22);
  end.writeUInt32LE(0x06054b50, 0);
  end.writeUInt16LE(centralEntries.length / 2, 8);
  end.writeUInt16LE(centralEntries.length / 2, 10);
  end.writeUInt32LE(centralDirectory.length, 12);
  end.writeUInt32LE(offset, 16);
  await fs.writeFile(destination, Buffer.concat([...localEntries, centralDirectory, end]));
}
