# Changelog

[Download](https://github.com/stellsor/twist/releases/latest) · [Setup](docs/USAGE.md)

## [0.7.27](https://github.com/Stellsor/twist/releases/tag/v0.7.27)

- Fixed round-transition freezes by moving history saves off the UI thread and reducing repeated catch matching.
- Smoothed the current-round display and made inventory previews update without rebuilding the whole list.
- Added a saved hardware acceleration option in Settings. Visual animation pauses while minimized.
- Fixed controller fruit alerts being blocked by ping settings. Usernames are sent as text; numeric Discord IDs create pings.

## [0.7.26](https://github.com/stellsor/twist/releases/tag/v0.7.26)

- Smoothed the live reel indicator and made tabs refresh as soon as you open them.
- Reduced repeated work in account totals and inventory previews.
- Minimized windows now pause UI animations and refresh less often. Fishing, connections and alerts keep running.
- Moved inventory-cache saves off the UI thread to reduce stutters with larger inventories.

## [0.7.25](https://github.com/stellsor/twist/releases/tag/v0.7.25)

- Update ZIPs are deleted once they’ve been checked and unpacked. If unpacking fails or is cancelled, the ZIP is kept.
- Made the inventory totals easier to read and gave them more room above the rarity filter.

## [0.7.24](https://github.com/stellsor/twist/releases/tag/v0.7.24)

- Added a Legendary fish total to Session and Fish inventory.
- Select Total to see how many Legendary fish all your accounts currently own.

<details>
<summary>Older updates</summary>

## [0.7.23](https://github.com/stellsor/twist/releases/tag/v0.7.23)

- Added custom bait restocking amounts. Choose when to restock and how much to buy; the defaults are still below 50 → buy 100.
- Updated Roblox UI reading so bait selection, purchase prompts and Store Fruit are recognised again.

## [0.7.22](https://github.com/stellsor/twist/releases/tag/v0.7.22)

- UI clicks now check that the cursor reaches the button before clicking.
- Added clearer status messages when a click is blocked or the game UI isn’t ready.

## [0.7.21](https://github.com/stellsor/twist/releases/tag/v0.7.21)

- Restocking now checks for a Common Fish Bait vendor within 12 studs.
- Improved Store Fruit button detection and the wait after equipping a fruit.

## [0.7.20](https://github.com/stellsor/twist/releases/tag/v0.7.20)

- Improved fruit selection from the backpack, including clearing a stuck search.
- Stopped old UI targets from pulling the cursor away while the backpack scrolls.
- The backpack closes and the fishing rod is restored before fishing continues.

## [0.7.19](https://github.com/stellsor/twist/releases/tag/v0.7.19)

- Added app updates to the launcher. Download and install new versions in the same folder.
- The launcher also checks offsets each time it opens.
- Close controllers and workers using that folder before updating. Settings and history carry over.

## [0.7.18](https://github.com/stellsor/twist/releases/tag/v0.7.18)

- Settings now save as you change them, including bait preferences and Discord alerts.
- Worker settings are kept while a worker is offline and sent when it reconnects.
- Restart the controller and workers after updating. Fishing changes apply on the next Start.

## 0.7.17

- Workers reconnect to newly opened Roblox clients and remove closed sessions.
- Account settings, cursor points and catch history are kept.

## 0.7.16

- Fixed the controller getting stuck on an invalid pairing code.

</details>
