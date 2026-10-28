# Changelog

[Download latest](https://github.com/stellsor/twist/releases/latest) · [Usage guide](docs/USAGE.md) · [Home](README.md)

## [0.7.23](https://github.com/stellsor/twist/releases/tag/v0.7.23)

- Added per-account Buy when below and Amount to buy settings for Common bait, with automatic saving and worker sync. Defaults remain 50 and 100; the requested quantity is checked before purchase and against the inventory receipt.
- Fixed UI text reading for the current Roblox build so Store Fruit, hotbar slot numbers and bait purchase controls are recognized again.
- TextLabel, TextButton and TextBox layouts are handled separately, with the older supported build retaining its own layout.
- Live read-only checks confirmed fruit storage readiness and receipt, hotbar slots, vendor distance, Common bait confirmation, quantity 100 and Legendary bait selection. All game UI actions during verification were performed by the user.

## [0.7.22](https://github.com/stellsor/twist/releases/tag/v0.7.22)

- Bait, purchase, backpack and Store Fruit controls now use verified absolute cursor movement within the worker desktop, with relative movement as a fallback.
- UI movement emits fresh hover events and verifies the cursor before clicking; casting keeps its existing movement behavior.
- Repeated input or UI-readiness failures now remain visible in the controller instead of being hidden behind a Storing fruit or Selecting bait message.
- UI status shows movement and click stages, and target validation preserves the specific reason when a click is blocked.

## [0.7.21](https://github.com/stellsor/twist/releases/tag/v0.7.21)

- Restocking now finds enabled Common Fish Bait vendors by their live world position within 12 studs of the player, instead of depending on the on-screen E prompt.
- Store Fruit now resolves the current visible button across duplicate menus and nested layouts, waits after equipping, and reports the specific reason when storage is blocked.
- Existing quantity-100 verification, purchase receipts, fruit ownership checks, and Stop controls remain active.

## [0.7.20](https://github.com/stellsor/twist/releases/tag/v0.7.20)

- Fruit equipment now waits for backpack layout and recovers hidden tiles by clearing the available search field and reopening the backpack when needed.
- Exact fruit/rod identity and hotbar slots are checked again after each menu change; the backpack closes before storage or fishing resumes.
- Old hover targets are cleared during equipment and scrolling so they cannot pull the cursor away from the current control.
- Backpack search recovery uses Delete instead of the fruit-drop Backspace key, and releases text focus before closing.
- Existing Store/Drop ownership and receipt verification, settings, inventories and updater behavior are preserved.

<details>
<summary>Previous versions</summary>

## [0.7.19](https://github.com/stellsor/twist/releases/tag/v0.7.19)

- The launcher checks for newer stable app releases and offers Download update at the bottom.
- Accepted updates download beside the launcher, verify their checksum, install in the same folder and reopen the launcher. Close controllers/workers using that folder first.
- Latest offsets are checked on every launcher opening; each Roblox client uses its matching validated version with cached/bundled fallback.
- Future ZIPs omit THIRD-PARTY-NOTICES.txt and the README Distribution section.
- Install this version manually once to enable future app-update prompts. Settings and history are preserved.

## [0.7.18](https://github.com/stellsor/twist/releases/tag/v0.7.18)

- Settings save automatically as they change, including bait, fruit handling, timing, session limits, webhook and mythical ping options.
- Webhook URLs and incomplete alert drafts are encrypted for the current Windows user.
- Settings for unavailable workers are retained and synchronized when the worker reconnects.
- Includes Roblox reopen/retry and dead-session cleanup from 0.7.17.
- Restart the controller and all workers from the new version folder. Fishing settings apply on the next Start.

## 0.7.17

- Automatic attachment to reopened Roblox clients, loading retries, and closed-session cleanup.
- Preserved account settings, worker cursor points, and catch history.

## 0.7.16

- Recovery for corrupted controller pairing state and atomic pairing writes.

</details>
