<h1 align="center">twist</h1>
<p align="center">A compact fishing macro for Grand Piece Online.</p>

<p align="center">
  <a href="https://github.com/stellsor/twist/releases/latest"><img src="https://img.shields.io/github/v/release/stellsor/twist?style=flat-square&color=bda6ef&label=release" alt="Latest release"></a>
  <img src="https://img.shields.io/badge/platform-Windows-202025?style=flat-square" alt="Windows">
</p>

<p align="center">
  <strong><a href="https://github.com/stellsor/twist/releases/latest">Download twist</a></strong>
  &nbsp;·&nbsp;
  <a href="twist/docs/USAGE.md">Usage guide</a>
  &nbsp;·&nbsp;
  <a href="twist/docs/examples/README.md">Screenshots</a>
  &nbsp;·&nbsp;
  <a href="CHANGELOG.md">What's new</a>
</p>

---

## Start fishing

1. Download **twist-VERSION-public.zip** from the [latest release](https://github.com/stellsor/twist/releases/latest) and **extract the entire ZIP**.
2. Open **twist Launcher.exe** and choose **Local** for one account, or **Controller + Workers** for RDP.
3. Equip your rod in GPO and choose your bait in **Settings**.
4. Save a cast point over the water, then press **Start fishing**.

In a worker, use **Select cursor point**, then **right-click** the spot in Roblox. In Local mode, point at the water and press **F7**.

Keep Roblox in the foreground in each fishing session. twist uses that session's mouse and keyboard.

**Step-by-step setup:** [One account](twist/docs/USAGE.md#one-account-local-mode) · [Multiple accounts with RDP](twist/docs/USAGE.md#multiple-accounts-with-rdp) · [Troubleshooting](twist/docs/USAGE.md#common-problems)

## Choose your mode

| Mode | Use it for |
| --- | --- |
| **Local** | Fishing and viewing stats on the PC you are using. |
| **Controller** | Managing your accounts from the main desktop. |
| **Worker** | Running the macro inside a separate Windows/RDP session. |

For multiple accounts, run one worker per RDP session and connect them to your controller. Choose **Total · all accounts** to view combined stats or start them together. [Full setup →](twist/docs/USAGE.md#multiple-accounts-with-rdp)

## Features

| Feature | What it does |
| --- | --- |
| **Auto fishing** | Casts, waits for a bite, and controls the fishing minigame. |
| **Bait management** | Uses Common or the best available bait, with a custom restock threshold and purchase amount. |
| **Fruit handling** | Equips and stores new devil fruits, with optional duplicate dropping. |
| **World** | Worker coordinates, All Seeing Eye countdowns, and saved AFK history. |
| **Spawn alerts** | Sends the exact fruit-spawn announcement and Eye pulse coordinates to Discord, with saved history in World. Requires an All Seeing Eye. |
| **Activity log** | Search saved events, see why fishing stopped, and review local crash details under Settings → Activity. |
| **Catch tracker** | Tracks catches, runtime, fish per hour, and catch history. |
| **Live inventories** | Shows fish and stored fruits with images, quantities, rarity filters, and a Legendary fish owned total. |
| **Discord alerts** | Reports stored fruits and fishing stats, with optional Mythical pings. |

[Set up spawn alerts →](twist/docs/USAGE.md#world-coordinates-and-spawn-history)

Backpack equipment failures now trigger one recovery attempt and appear in Activity. If recovery fails, fishing stops. To report a problem, choose **Activity → Export TXT** and attach the file to the issue.

Settings save automatically. Workers detect reopened Roblox clients; press **Start** to resume fishing.

## Screenshots

Actual UI with demo accounts and statistics. Screenshots are from 0.7.20; newer versions have a few differences.

![twist live tracking example](twist/docs/examples/0.7.20/02-live-tracking.png)

[View all 9 screenshots →](twist/docs/examples/README.md)

## Controls

**F7** — save cast point &nbsp;·&nbsp; **F8** — start / stop &nbsp;·&nbsp; **F9** — stop

## Updates

The launcher checks for app updates and offsets when opened. When **Download update** appears, close the controllers and workers using that folder, then accept the update. Your settings and history carry over. The downloaded update ZIP is removed after successful verification and extraction.

[Read the usage guide](twist/docs/USAGE.md) for bait settings, fruit storage, alerts, and UI alignment.

## Source and building

The recovered C# source is available under **GPL-3.0**. See [build instructions](twist/docs/BUILD.md), [the license](LICENSE), and [asset attribution](twist/docs/ASSETS.md). Some recovered internal names remain generated.

All project code, assets, documentation and build tools are in [`twist/`](twist/). Build from the repository root with `node twist/scripts/build.mjs`.
