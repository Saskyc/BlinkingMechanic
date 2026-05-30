![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/Saskyc/BlinkingMechanic/total)
# About
This plugin uses effect called "Blindness" to simulate blinking similar to containment breach.
There is also API that can easily be used to make player blink and events that are cancelable if any developer would want to use it.
If there are any issues feel free to ping me on Discord/Create issue here on github (It might give me time to notice the issue though)

# Config
```
# If Debug is enabled [You might have a lot of logs in console after this]
is_debug: true
# Time between blinks. [IN SECONDS]
time_blink: 3
# Time that blinking is lasting. [IN MILISECONDS]
blink_lasting: 500
blacklisted_roles:
- Scp049
- Scp0492
- Scp079
- Scp096
- Scp106
- Scp173
- Scp939
- Scp3114
blacklisted_teams:
- SCPs
```

# How does it look in-game?
https://www.youtube.com/watch?v=64LlXKs-FvA

# Credits:
Ai was used for figuring out Elapsed DateTime to use as cooldown and helping me create the patch.
I've copied gitignore from great developer MedveMerci from repository that can be found here: https://github.com/MedveMarci/Scp999
