# twist 0.7.19

Open **twist Launcher.exe** and choose Worker, Controller or Local. Controller can request administrator access for discovering workers under other Windows users.

## Launcher app and offset updates

Every launcher opening checks the latest stable GitHub release and downloads the latest validated JSON from https://offsets.imtheo.lol/offsets.json. A newer app version appears at the bottom with **Download update**. Updates are optional. The ZIP downloads beside the launcher and is checked against GitHub’s SHA-256 digest.

Close all twist controllers and workers using that folder before updating. The launcher stages the verified package, closes itself, replaces files in the same folder, and opens the new launcher. Existing LocalAppData settings/history and unrelated files remain intact. File replacement errors roll back copied files. Update failures leave the ordinary launcher usable.

Offsets update independently from app updates. Each Roblox client uses the validated offsets for its own version; cached or bundled matching data remains available if the site is unavailable. The downloaded ZIP stays in the app folder.

Install 0.7.19 manually once to enable app-update prompts; earlier launchers do not contain this feature.

## Automatic settings saving

Settings save as you change them, without pressing Save or closing the controller. Bait preferences, restocking, fruit handling, limits and timing save immediately for toggles and after a short typing pause for text fields. Switching accounts also flushes valid edits for the previous account. Invalid numeric entries preserve the last valid profile. Worker cursor points, UI alignment and other calibration values are retained. Fishing settings apply on the next Start.

Controller edits are saved locally first and sent to their worker. If a worker is unavailable, its pending settings survive controller restarts and synchronize when it reconnects, without starting fishing. Discovery preferences and the connection port also persist; the port takes effect at Restart listener or the next controller start.

Webhook URLs, enabled state and mythical ping options save automatically. URLs are encrypted for the current Windows user. Incomplete webhook/ping edits are saved as an encrypted draft and restored on reopening; they do not replace valid active settings until complete. Disabling notifications takes effect even if the current draft is incomplete. Autosave does not send a test notification.

## Roblox reconnect and dead-session cleanup

Workers keep scanning their own Windows session. When Roblox closes, its input session and inventory monitor are disposed and its entry is removed. A newly opened Roblox client is attached automatically; a player still loading or a failed attach is retried about every six seconds without restarting the worker. PID reuse is treated as a new client. Saved account settings, cursor point and catch history are preserved. New clients remain stopped until you press Start fishing.

The controller removes closed clients from its account selector and Total view, hides disconnected worker cards and expires offline worker connections after 30 seconds. The worker itself stays connected while waiting for a new Roblox client. Automatic attach uses the startup/version offset cache and existing guards; it does not launch Roblox or join a server.

## Controller pairing recovery

A damaged saved controller pairing file is backed up and regenerated automatically, so Controller opens without asking for a worker pairing code. Controller pairing changes are now flushed and replaced atomically. Valid saved codes and custom ports are preserved. Workers can reconnect through automatic discovery; manual pairing, when needed, uses the new code shown in Connections.

## Webhook UI fixes

Validation errors stay visible instead of being overwritten by status polling. Send test checks only the pasted webhook URL, works while notifications are disabled or ping settings are incomplete, and never pings. It does not save or change notification preferences; use Save alerts for those. Network failures show their connection-status category without exposing the webhook token.

## Inventory sorting

Fish and Fruits cards now sort from highest rarity to lowest, with alphabetical names within each tier, for individual accounts and Total. The Fish rarity dropdown omits Mythical, Collectable and Unknown. The Fruits dropdown omits Collectable and Unknown.

## Fruit inventory and Discord alerts

**Fruits** shows stored devil fruits with quantities, rarity filters, search and colored icons from the [Grand Piece Online Wiki](https://grand-piece-online.fandom.com/wiki/Devil_Fruits). **Fish** remains fish-only. Both views support individual accounts and **Total · all accounts**, merging quantities without counting reconnected copies twice. All 37 fruit icons are bundled and work offline; they override older grayscale mesh previews. Bomu/Bomb and Ptero/Pteranodon aliases use matching icons. Rarities use captured game styling with the [official game-description tiers](https://www.roblox.com/games/1730877806/Grand-Piece-Online) as fallback.

Open **Alerts** on the controller (or Local mode). Paste a Discord webhook URL and enable stored-fruit notifications; changes save automatically. **Send test** verifies your webhook without pinging anyone. One controller setup covers all connected RDP workers. The masked URL is encrypted for the current Windows user in LocalAppData and is never included in worker profiles or RDP packets.

A confirmed automatic storage produces a message such as **Hie was stored successfully**, with that account's fish caught, fishing runtime and fresh Common/Rare/Legendary bait quantities. Counts describe the worker's current runtime; missing bait data is labelled unknown. Existing inventory, replayed worker packets and dropped duplicates never create a new storage notification. A stored fruit is confirmed only after the carried tool disappears and the stored inventory count increases.

Optional **Mythical-only pings** support a Discord user ID, role ID or Everyone. Other fruit alerts and test messages suppress mentions. Server permissions and the recipient's Discord notification settings still apply. Defaults are notifications off and pings off, until configured.

Notifications run outside the fishing/input loop. Delivery state and event IDs are saved locally. Discord rate limits use its retry_after delay. An interrupted request or uncertain network response pauses that notification so it cannot repeatedly ping automatically; check Discord, then use **Retry pending** if needed. After correcting a rejected webhook URL, valid edits save automatically and resume delivery. An explicit retry can duplicate a message whose original acknowledgement was lost.

The integration follows Discord's [webhook endpoint](https://docs.discord.com/developers/resources/webhook), [allowed mentions](https://docs.discord.com/developers/resources/message#allowed-mentions-object) and [rate limits](https://docs.discord.com/developers/topics/rate-limits). Automated webhook tests use mocked HTTP; no message was sent to a real Discord server during development. Use Send test for your live check.

## UI hover refresh

Before each bait selection, purchase Yes/quantity/Buy/Done click, backpack tile selection and Store Fruit click, the cursor moves to the target, nudges a few pixels left/right (or vertically for a narrow control), and returns to its center. The nudge repeats about every two seconds while the worker is waiting on the same verified UI target. It sends movement only; purchase and fruit receipt checks still control actual clicks.

The refresh stays within the control, rechecks geometry/window bounds and focus at each step, and is cancelled by Stop. It does not run during casting, held reel input or normal cursor anchoring. No background cursor timer is created; each RDP worker runs it through its existing input owner. Very small controls keep their center without a nudge.

Mock-input timing, bounds, focus/cancellation and regression tests passed. Live GPO hover registration still needs your check.

## Devil fruit handling

Enabled by default in Settings: **Automatically equip and store devil fruits** and **Drop already-owned fruits with Backspace**. Each worker checks carried fruit tools between casts, equips the exact fruit from a hotbar slot or opens the backpack and scrolls its tile into view, then restores the fishing rod and saved cast point. Tools are identified by their fruit components and UI-to-tool references, not a word in their name. The Fish tab shows fish and the Fruits tab shows stored devil fruits.

A fruit absent from stored inventory is stored using the visible **Store Fruit** control. A loose fruit already present in stored inventory is equipped and dropped with Backspace, leaving the stored copy unchanged. The worker verifies the current tool and stored ownership before acting. An unavailable inventory or failed Store click never authorizes dropping a new fruit. Delayed receipts, missed actions and rod restoration retry until acknowledged or stopped. Settings shows stored/dropped counters for the current worker session.

Stop/F9, focus and session/connection guards remain active. Fruit handling runs before an optional session goal ends the run. Disable duplicate dropping to leave duplicate tools alone; disable fruit handling to preserve the previous behavior. Changes apply on the next Start.

Automated fruit and protocol tests passed with mocked input; a read-only check confirmed live Spin/Heal tool identity and storage metadata. Your manual Store action confirmed immediate storage. The new automated Store/Drop/scroll sequence still needs a live user check.

## Catch counting and supplies

Catch totals and fish/hour use one catch per successfully completed minigame, including catches at the 40-per-species inventory cap. Inventory changes identify species and rarity only. Capped catches without evidence are shown as **Unidentified fish / Unknown**. Existing history is preserved; completion-based counting applies from the first opening of 0.7.10 or later.

Restocking recovers at the final vendor screen. Quantity verification uses a 37-to-100 edit; only a live verified 100 can be submitted. Persistent retries and purchase receipt protection remain included.

## Total accounts

In the controller's account picker, choose **Total · all accounts**. The Session view combines fish caught, fish owned, per-account fish/hour rates, weighted on-target time and a per-account overview. Session time shows the longest account session. Inventory combines quantities by fish species; search, rarity filters and catch history apply across accounts. Reconnected copies of the same account are counted once. Last-known offline inventories are labelled.

**Start all fishing** starts ready accounts concurrently using each account's saved settings and cast point. Already-running accounts stay running. One active client per Windows input session is supported; clients in different RDP sessions can run together. A failed worker does not cancel other successful starts. **Stop all** stops connected accounts. Select an individual account to edit its settings.

Persistent bait retries from 0.7.8 are included. Recoverable supply/UI failures keep waiting/retrying while enabled; after Buy input, the worker waits for the existing inventory receipt instead of sending another purchase. Input-focus and connection/session emergency guards remain.

## Automatic offsets

Every launcher opening checks https://offsets.imtheo.lol/offsets.json. Valid dumps are cached under %LOCALAPPDATA%/twist-rdp/offsets by exact Roblox version. Workers use a matching cache entry, fetch the corresponding version archive when needed, or keep a matching bundled file if the website is unavailable. Invalid, incomplete or mismatched responses do not replace good cached files. Opening the runtime directly also runs the check.

Offsets are data only; the updater does not download or run executables. Some inventory, mesh and UI layouts are outside the published offset feed, so a future Roblox/GPO update may still need an application update.

## Updating

Close older controllers/workers and start every session from this same build. Your pairing, profiles, cast point, UI alignment and history remain in each Windows user's LocalAppData/twist-rdp folder. Keep the app folder beside the launcher.

## Public distribution

This package contains obfuscated executables and required runtime assets. It contains no C# source, source archive, debug symbols, private obfuscation maps or account profiles. Obfuscation increases reverse-engineering effort; it does not make distributed code unrecoverable.

Publish this 0.7.19 public ZIP or the prepared publish/github-0.7.19 folder. Earlier 0.7.6 packages contained a source archive and should not be used as the private-source public release.
