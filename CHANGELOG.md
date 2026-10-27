# Changelog

## 0.7.20

- Fruit equipment now waits for backpack layout and recovers hidden tiles by clearing the available search field and reopening the backpack when needed.
- Exact fruit/rod identity and hotbar slots are checked again after each menu change; the backpack closes before storage or fishing resumes.
- Old hover targets are cleared during equipment and scrolling so they cannot pull the cursor away from the current control.
- Backpack search recovery uses Delete instead of the fruit-drop Backspace key, and releases text focus before closing.
- Existing Store/Drop ownership and receipt verification, settings, inventories and updater behavior are preserved.

## 0.7.19

- The launcher checks for newer stable app releases and offers Download update at the bottom.
- Accepted updates download beside the launcher, verify their checksum, install in the same folder and reopen the launcher. Close controllers/workers using that folder first.
- Latest offsets are checked on every launcher opening; each Roblox client uses its matching validated version with cached/bundled fallback.
- Future ZIPs omit THIRD-PARTY-NOTICES.txt and the README Distribution section.
- Install this version manually once to enable future app-update prompts. Settings and history are preserved.

## 0.7.18

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
