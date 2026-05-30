![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/Saskyc/BlinkingMechanic/total)
# About
This plugin creates primitive infront of Player as "blinking". Player can still see under them and above as more primitives would have to be created.
There is also API that can easily be used to make player blink and events that are cancelable if any developer would want to use it.
I've used networking to ensure that players cannot see each others primitives (yes also NPCs).
If there are any issues feel free to ping me on Discord/Create issue here on github (It might give me time to notice the issue though)

# Config
```
# If Debug is enabled [You might have a lot of logs in console after this]
is_debug: true
# The time that blinking stays. [IN SECONDS]
time_blink: 3
# The amount of time that blinking is lasting. [IN MILISECONDS]
blink_lasting: 500
```

# How does it look in-game?
### Front
<img width="1919" height="1079" alt="obrazek" src="https://github.com/user-attachments/assets/6bef6dbd-152c-49a9-bb47-d18fa933c5a9" /><br>
### Below
<img width="1919" height="1079" alt="obrazek" src="https://github.com/user-attachments/assets/03960104-3756-442d-b2a0-ab5b61538a07" /><br>
### Above
<img width="1919" height="1079" alt="obrazek" src="https://github.com/user-attachments/assets/97915fa0-03d5-4006-8da9-86cc43ca484b" /><br>

# Credits:
Ai was used to help me with Mirror getting the method to create spawn message via reflection.
Ai was used for figuring out Elapsed DateTime to use as cooldown.
Ai was used to help me create the patch.
I've copied gitignore from great developer MedveMerci from repository that can be found here: https://github.com/MedveMarci/Scp999
Also I didn't figure out how to spawn for single player that was another legend: https://github.com/MS-crew/NightVisionGoggles/blob/master/NightVisionGoggles/Extensions.cs
