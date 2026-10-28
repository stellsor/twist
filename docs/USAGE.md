# How to use twist

## Getting started

1. Download the [latest release](https://github.com/stellsor/twist/releases/latest) and extract the whole ZIP.
2. Open **twist Launcher.exe** and choose a mode:
   - **Local:** fish on the PC you are using.
   - **Controller:** manage accounts running in separate Windows/RDP sessions.
   - **Worker:** run inside each Windows/RDP session you want the controller to manage.
3. Open GPO, equip your fishing rod, and stand where you can cast into water.
4. Set your cast point. In a worker, click **Select cursor point**, then **right-click** the spot in Roblox. In Local mode, point at the water and press **F7**.
5. Choose the account in twist and press **Start fishing**.

Keep Roblox visible and in the foreground in each fishing session. twist uses that session's mouse and keyboard.

## Multiple accounts with RDP

1. Open **Controller** on your main desktop. Administrator access helps it discover workers under other Windows users.
2. Open **Worker** inside each separate RDP session, with Roblox running there.
3. Workers should connect automatically. If one does not, copy the code from the controller's **Connections → Manual pairing**, paste it into the worker's **Manual pairing** box, and click **Connect**.
4. Set a cursor point in each worker.
5. Select an account to control it, or choose **Total · all accounts** and press **Start all fishing**.

Use one actively fishing Roblox client per Windows session. **Stop all** stops the connected accounts. When Roblox closes, its old entry is removed; a newly opened client is detected automatically. Press Start to resume.

## What each tab does

| Tab | What it does |
| --- | --- |
| **Session** | Shows fishing status, fish caught, runtime, and fish per hour. **Total** combines the accounts' statistics. |
| **Tracker** | Shows catch history and round performance. Use **Export catches** to save catch data. |
| **Fish** | Shows fish inventory, quantities, images, search, and rarity filters. |
| **Fruits** | Shows stored devil fruits with quantities, images, search, and rarity filters. |
| **Settings** | Controls bait, restocking, fruit handling, session limits, and timing for the selected account. |
| **Alerts** | Sets up Discord notifications for successfully stored fruits. |
| **Connections** | Shows connected workers and provides discovery and manual pairing controls. |

Fish and fruit inventories sort from highest rarity to lowest. Select **Total** to combine inventories across accounts. Catch totals count successful minigames even when a fish's inventory stack is full.

## Main settings

- **Common bait:** uses Common bait.
- **Best available:** uses Legendary first, then Rare, then Common as stock runs out.
- **Auto-buy bait:** buys 100 Common bait when Common stock falls below 50. Stand within **12 studs** of the Common Fish Bait vendor and have enough Peli.
- **Automatically equip and store devil fruits:** checks the hotbar and backpack between casts, stores new fruits, then equips the rod again.
- **Drop already-owned fruits:** drops a carried duplicate with Backspace if that fruit is already stored. Turn this off to keep duplicates.
- **Session limits:** stops after the chosen rounds or minutes, finishing the current round first. **0** means unlimited.
- **Timing & calibration:** adjusts casting delays, the cast point, and the rod slot. Start with the defaults.

Settings save automatically as you change them. Stop and start fishing to apply fishing changes.

## Discord alerts

In **Alerts**, paste your webhook URL and enable stored-fruit notifications. Use **Send test** to check delivery.

Storage messages include the fruit name, fish caught, fishing time, and remaining bait. Enable **Mythical-only pings** and choose a user, role, or Everyone if you want mentions for Mythical fruits. Test messages do not ping.

## Controls and updates

| Control | Action |
| --- | --- |
| **F7** | Save the cast point at the cursor. |
| **F8** | Start or stop fishing. |
| **F9** | Stop fishing. |
| Worker **Select cursor point** | Right-click in Roblox to choose the cast point. |

If bait or purchase clicks land in the wrong place, open the worker's **UI alignment**, click **Align bait / purchase UI**, then right-click the center of the highest bait row.

Reopen the launcher to check for updates. Choose **Download update** at the bottom when offered; close controllers and workers using that folder first. Offsets are checked automatically whenever the launcher opens.
