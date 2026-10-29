# How to use twist

[Home](../README.md) · [Download](https://github.com/stellsor/twist/releases/latest) · [Screenshots](examples/README.md)

Choose the setup you need:

- [One account on your desktop](#one-account-local-mode)
- [Multiple accounts with RDP](#multiple-accounts-with-rdp)
- [Bait and restocking](#bait-and-restocking)
- [Fruit storage](#fruit-storage)
- [Discord alerts](#discord-alerts)
- [Common problems](#common-problems)

## One account (Local mode)

1. Open the [latest release](https://github.com/stellsor/twist/releases/latest). Under **Assets**, download the file named **twist-VERSION-public.zip**.
2. Extract the whole ZIP into a folder, then open **twist Launcher.exe** from that folder.
3. Choose **Local**. Open GPO and wait for your account to appear in twist's account selector.
4. In GPO, equip your fishing rod and face the water.
5. In twist, open **Settings** and choose **Common bait** or **Best available**. If auto-buy is enabled, stand near the Common Fish Bait vendor. See [bait setup](#bait-and-restocking).
6. Point your mouse at the spot in the water where you want to cast, then press **F7**. Your saved point appears in **Settings → Cast point**.
7. Press **F8** or click **Start fishing**. Leave Roblox in the foreground.

You should see the status move through casting, waiting for a bite and reeling. The live tracker appears during the fishing minigame.

Press **F8** to stop or start again. **F9** stops all fishing in that twist instance.

## Multiple accounts with RDP

These steps assume your RDP sessions are already set up and can run Roblox. Use one actively fishing Roblox client per Windows session.

### 1. Start the controller on your main desktop

1. Extract the twist ZIP into a folder accessible from your sessions, or copy the extracted folder into each session.
2. Open **twist Launcher.exe** on your main desktop and choose **Controller**. Administrator access helps it discover workers running under other Windows users.
3. Open **Connections** and leave the controller running.

### 2. Start a worker in each RDP session

1. Inside the RDP session, open GPO on the account you want to fish with.
2. Open **twist Launcher.exe** inside that same session and choose **Worker**.
3. Check that the compact worker says **Connected**. The account should also appear in the main controller.
4. Select the correct Roblox account in the worker, equip its rod and face the water.
5. Click **Select cursor point** in the worker, then **right-click** the spot in Roblox where you want to cast. The saved coordinates should change in the worker.

Repeat this for each RDP session. [See the compact worker](examples/0.7.20/09-compact-worker.png).

### 3. Start fishing from the controller

1. Return to your main desktop.
2. Select an account in the controller and set its bait and fruit options in **Settings**.
3. Click **Start fishing** for that account, or choose **Total · all accounts** and click **Start all fishing**.
4. Check that each worker's Roblox client stays in the foreground inside its own session.

**Stop all** stops the connected accounts. Keep the RDP sessions active; a locked or disconnected desktop can stop their inputs. You can minimize twist itself to reduce UI activity.

### If automatic connection does not work

1. In the controller, open **Connections → Manual pairing** and copy the complete pairing code.
2. In the worker, expand **Manual pairing**, paste the code and click **Connect**.
3. Check the controller's account selector again.

When Roblox closes, its old entry is removed. The worker detects a newly opened client automatically; press **Start fishing** to resume.

## Bait and restocking

Select the account you want to change, then open **Settings**.

| Option | What happens |
| --- | --- |
| **Common bait** | Uses Common Fish Bait. |
| **Best available** | Uses Legendary first, then Rare, then Common when the better bait runs out. |
| **Automatically buy Common bait** | Restocks Common bait when it falls below your chosen threshold. |

To set up restocking:

1. Enable **Automatically buy Common bait**.
2. Set **Buy when below** to the stock level that should trigger a purchase.
3. Set **Amount to buy** to how many more bait to purchase.
4. Stand within **12 studs** of the Common Fish Bait vendor and have enough Peli.
5. Stop and start fishing to apply the changes.

For example, **Buy when below: 50** and **Amount to buy: 100** buys 100 more when stock drops under 50. A stock of exactly 50 does not trigger it.

If you are fishing away from the vendor, turn off auto-buy and bring enough bait for the run.

## Fruit storage

In **Settings**, enable **Automatically equip and store devil fruits**.

Between casts, twist checks the hotbar and backpack, equips a carried fruit, clicks **Store Fruit**, then restores the rod.

**Drop already-owned fruits with Backspace** controls duplicates. Enable it to drop fruits you already have stored, or turn it off to keep them.

Use the **Fruits** tab to view stored fruit quantities and rarities.

## Discord alerts

1. Open **Alerts** in the controller, or in Local mode.
2. Paste your Discord webhook URL and enable stored-fruit notifications.
3. Click **Send test** and check the Discord channel for the message.
4. For Mythical pings, enable **Ping only when a Mythical fruit is stored**, then choose **User**, **Role** or **Everyone**. Enter the user or role ID when needed.

A successful storage message includes the fruit name, fish caught, fishing time and remaining bait. Test messages do not ping. In an RDP setup, configure alerts on the controller.

## Tabs and totals

| Tab | What it shows |
| --- | --- |
| **Session** | Current status, runtime, fish caught, fish per hour, fish owned and Legendary fish owned. |
| **Tracker** | Catch history, round performance and CSV exports. |
| **Fish** | Fish inventory with quantities, images, search and rarity filters. |
| **Fruits** | Stored fruits with quantities, images, search and rarity filters. |
| **Settings** | Options for the selected account. Changes save automatically. |
| **Alerts** | Discord notifications and Mythical pings. |
| **Connections** | Workers, discovery and manual pairing. |

Select **Total · all accounts** to combine inventories and statistics. To edit an account's settings, select that account instead.

**Fish caught** counts completed successful minigames, even when that fish's inventory stack is full. **Fish owned** and **Legendary owned** show what is currently in inventory.

Session limits are in **Settings**. Set the round or time limit to **0** for an unlimited run. Limits finish the current round before stopping.

## Common problems

| Problem | What to check |
| --- | --- |
| Account is missing | Join GPO and wait for it to load. For RDP, make sure the worker is running in the same Windows session as Roblox. |
| Worker is not connected | Try **Connections → Scan now**, then use manual pairing if needed. |
| Cast lands in the wrong place | Stop fishing, face the water and save the point again. Use **F7** in Local mode, or the worker's **Select cursor point** followed by a right-click. |
| Waiting for bait or the vendor | Check your selected bait and stock. Move within 12 studs of the Common Fish Bait vendor, or turn off auto-buy if you are fishing elsewhere. |
| Bait or purchase clicks miss | Move the worker panel away from the game buttons. Open **UI alignment → Align bait / purchase UI**, then right-click the center of the highest bait row. |
| Fishing stops when switching apps | Roblox needs the foreground in its fishing session. Use separate RDP sessions to fish while using your main desktop. |
| A reopened Roblox client is idle | Wait for the worker to detect it, select the new entry and press **Start fishing** again. |
| Settings seem unchanged | They save automatically, but fishing settings take effect after stopping and starting the account. |
| Discord test does not arrive | Check the webhook URL and the status shown in **Alerts** after pressing **Send test**. |

## Updating

1. Open **twist Launcher.exe** to check for a new version.
2. Close every controller and worker using the folder you are updating.
3. Choose **Download update** when the launcher offers it.
4. After installation, reopen the controller and workers. Update separate copies of twist as well if your sessions use different folders.

Your settings and history carry over. The launcher also checks offsets whenever it opens. It removes the update ZIP after checking and unpacking it; a failed or cancelled extraction keeps the ZIP.

While twist is minimized, the UI refreshes less often. Fishing, connections and alerts continue, and the display refreshes when you restore the window.
