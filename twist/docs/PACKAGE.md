# Twist 0.7.32

Extract the entire ZIP, then open **twist Launcher.exe**. Keep the `app` folder beside it. Windows x64 and .NET Framework 4.8 are required.

## Backpack recovery

Twist records failed backpack equipment attempts, reopens the inventory and resolves the same tool again. The retry temporarily bypasses saved alignment offsets. After two failed attempts, fishing stops with an explanation. This recovery also applies when duplicate dropping is enabled.

## Report a problem

Open **Activity**, click **Export TXT**, save the file and attach it to [a new GitHub issue](https://github.com/stellsor/twist/issues/new). The export includes all saved accounts and events. Existing webhook and pairing-code redaction applies. Account names and event details remain in the export.

## Source and license

Twist's code is licensed under GPL-3.0. The license is included at `app/assets/GPL-3.0.txt`. The corresponding source for this build is available at [tag v0.7.32](https://github.com/stellsor/twist/tree/v0.7.32). Build instructions and asset attribution are included in that source tree.

This is a build from recovered source. The dashboard-close self-test has a known failure also observed in the original release. Live operation on the affected user's setup still needs confirmation.
