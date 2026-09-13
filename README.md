![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/Saskyc/BlinkingMechanic/total)
# About
This plugin uses effect called "Blindness" to simulate blinking similar to containment breach.
There is also API that can easily be used to make player blink and events that are cancelable if any developer would want to use it.
Uses [RueI](https://github.com/pawslee/RueI) and [ASS](https://github.com/Someone-193/ASS)
If there are any issues feel free to ping me on Discord/Create issue here on github (It might give me time to notice the issue though)

# Config
```
# If Debug is enabled [You might have a lot of logs in console after this]
is_debug: false
# Time between blinks. [IN SECONDS]
time_blink: 3.5
# Time that blinking is lasting. [IN MILISECONDS]
blink_lasting: 250
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
s_s_s_config:
  menu_priority: 0
  header_id: 7000
  header_label: Blink Menu
  reduced_padding_header: false
  header_hint: Menu used to define player configuration.
  keybind_id: 7001
  keybind_label: Blink key
  keybind_suggested_key: E
  keybind_trigger_in_gui: false
  keybind_trigger_when_spectating: false
  keybind_hint: Used to manually blink instead of automatically
  show_eye_id: 7002
  show_eye_label: Show eye
  show_eye_left_option: Yes
  show_eye_right_option: No
  show_eye_defaultly_selected_right: false
  show_eye_hint: Indication if eye icon indicating when player blinks should be shown.
hint_config:
  eye_hint_id: remainingTime_untilBlink
  eye_y_pos: 100
  eye_text_shown: "<alpha=#%eyeRemainOpacity%>\U0001F440<alpha=#FF>"

```

# How does it look in-game?
https://www.youtube.com/watch?v=64LlXKs-FvA

# Installation
Move BlinkingMechanic.dll to your {Server}\SCP Secret Laboratory\LabAPI\plugins folder either to {port} or global.
Then move Dependencies.zip into {Server}\SCP Secret Laboratory\LabAPI\dependencies and select either to {port} or global and extract the .zip.

# Credits:
Ai was used for figuring out Elapsed DateTime to use as cooldown and helping me create the patch.
I've copied gitignore from great developer MedveMerci from repository that can be found here: https://github.com/MedveMarci/Scp999
Axwabo for great idea to not use primitive but blindness effect
