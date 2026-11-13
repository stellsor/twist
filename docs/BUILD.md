# Build Twist

Install .NET SDK 8 and Node.js 20 or later on Windows x64. The projects target .NET Framework 4.8. NuGet restores reference assemblies automatically.

From the repository root, run

```bat
node scripts/build.mjs
```

The runnable folder is written to `artifacts/twist-0.7.31/`. The release ZIP is written to `releases/`, and `release.json` and `CHECKSUMS.sha256` are updated for the generated package.

Use `node scripts/build.mjs --build-only` to build a runnable folder without updating release metadata.

## Source layout

- `src/App/` contains the fishing app, dashboard, input code and existing regression checks.
- `src/Launcher/` contains the launcher and update validation.
- `runtime/app/` contains XAML, the item catalog, bundled offsets and assets.
- `scripts/build.mjs` builds and packages both executables.

The source was recovered from the 0.7.29 public executables after the original checkout was lost. Many internal identifiers still use generated names. New recovery and export code uses descriptive names. Original comments and project organization were lost.

## Validation

The launcher supports `--self-test`. The app supports `--ui-self-test` and `--self-test`. Run these from the packaged directory so the runtime assets can be found.

The full app self-test stops at a dashboard-close assertion that also fails in the original 0.7.29 executable in the recovery environment. Individually running the 24 subsystem groups passes 23 groups. The backpack recovery, duplicate-drop guards, export formatting and UI checks pass. Live fishing on the reporting user's setup remains unverified.

Compiler warnings remain in recovered compiler-generated code.
