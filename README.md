# twist

A compact GPO fishing app with a controller, local mode, and workers for separate Windows/RDP sessions.

**[Download the latest release](https://github.com/Stellsor/twist/releases/latest)** · [All releases](https://github.com/Stellsor/twist/releases) · [Usage guide](docs/USAGE.md)

Current version: **0.7.18**. If the release is still publishing, use the [audited ZIP](https://github.com/Stellsor/twist/raw/refs/heads/main/releases/twist-0.7.18-public.zip).

## Quick start

1. Download the ZIP from Releases and extract the entire folder.
2. Open **twist Launcher.exe** and choose **Controller**, **Worker**, or **Local**.
3. For RDP: run Controller on your main desktop and one Worker inside each separate Windows session. Controller administrator access supports discovery across Windows users.
4. Inside each worker, equip a fishing rod and use **Select cursor point**, then right-click the desired point in Roblox.
5. Select an account (or Total) in the controller and press **Start fishing**.

Each worker uses the real mouse and keyboard inside its Windows session and needs Roblox in the foreground. **F7** saves a point, **F8** starts/stops, and **F9** stops fishing. Workers attach to reopened Roblox clients automatically; press Start to resume fishing.

## Features

- Controller, compact always-on-top worker, and standalone local mode.
- Per-account and Total statistics, fish and fruit inventories, and rarity sorting.
- Common or best-available bait selection and Common bait restocking.
- Devil fruit storage and optional duplicate dropping.
- Discord stored-fruit alerts and optional mythical pings.
- Automatic settings saving, encrypted webhook storage, and offline worker settings sync.
- Roblox client detection, loading retries, and closed-session cleanup.
- Version-matched offset downloads with a cached/bundled fallback.

## Updates

Close the older controller and workers, extract the new release, and restart every component from that version. Settings and history remain in `%LOCALAPPDATA%/twist-rdp`. Fishing starts stopped.

## Distribution

This repository distributes obfuscated Windows binaries, assets, documentation, and release metadata. The application source and private build files remain in the development workspace. Releases are packaged and audited before publication; the release workflow verifies the ZIP checksum, contents, and executable hashes.

Third-party asset credits are in [THIRD-PARTY-NOTICES.txt](THIRD-PARTY-NOTICES.txt) and inside the ZIP.
