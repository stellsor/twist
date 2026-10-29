# twist

A fishing macro for Grand Piece Online, with support for separate Windows/RDP sessions.

**[Download](https://github.com/stellsor/twist/releases/latest)** · [Setup](docs/USAGE.md) · [Screenshots](docs/examples/README.md) · [Changelog](CHANGELOG.md)

![twist](docs/examples/0.7.20/02-live-tracking.png)

## Getting started

1. Download the latest ZIP and extract the whole folder.
2. Open **twist Launcher.exe** and choose **Local**.
3. Equip your rod in GPO, point at the water and press **F7** to save your cast point.
4. Press **F8** to start. **F9** stops the macro.

Keep Roblox in front while fishing. twist uses the mouse and keyboard in that Windows session.

## Features

- Auto casting and reel control.
- Common bait or best available, with custom restocking amounts.
- Automatic fruit storage and optional duplicate dropping.
- Fish and fruit inventories, rarity filters and Legendary fish totals.
- Catch history, fish per hour and session stats.
- Discord notifications for stored fruits, with optional Mythical pings.

Settings save as you change them. [The setup guide](docs/USAGE.md) covers each option.

## Multiple accounts

Run **Controller** on your main desktop and **Worker** inside each RDP session. Workers connect automatically, or you can pair them from **Connections**.

In each worker, click **Select cursor point**, then right-click the water in Roblox. Use one fishing client per Windows session.

Select **Total · all accounts** in the controller to see combined stats and start accounts together. [RDP setup →](docs/USAGE.md#multiple-accounts-with-rdp)

## Updates

Reopen the launcher to check for updates. Close controllers and workers using that folder before choosing **Download update**. Your settings and history carry over.

Offsets are checked when the launcher opens. The update ZIP is removed after it’s checked and unpacked.

---

[Screenshots](docs/examples/README.md) use demo accounts and sample stats.
