using UnityEngine;

namespace BlinkingMechanic;

public class SSSConfiguration
{
    public int MenuPriority { get; set; } = 0;
    
    public int HeaderId { get; set; } = 7000;
    public string HeaderLabel { get; set; } = "Blink Menu";
    public bool ReducedPaddingHeader { get; set; } = false;
    public string HeaderHint { get; set; } = "Menu used to define player configuration.";

    public int KeybindId { get; set; } = 7001;
    public string KeybindLabel { get; set; } = "Blink key";
    public KeyCode KeybindSuggestedKey { get; set; } = KeyCode.E;
    public bool KeybindTriggerInGui { get; set; } = false;
    public bool KeybindTriggerWhenSpectating { get; set; } = false;
    public string KeybindHint { get; set; } = "Used to manually blink instead of automatically";

    public int ShowEyeId { get; set; } = 7002;
    public string ShowEyeLabel { get; set; } = "Show eye";
    public string ShowEyeLeftOption { get; set; } = "Yes";
    public string ShowEyeRightOption { get; set; } = "No";
    public bool ShowEyeDefaultlySelectedRight { get; set; } = false;
    public string ShowEyeHint { get; set; } = "Indication if eye icon indicating when player blinks should be shown.";
}