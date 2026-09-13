using System.Collections.Generic;
using ASS.Events.EventArgs;
using ASS.Features.Collections;
using ASS.Features.Settings;
using BlinkingMechanic.API;
using BlinkingMechanic.Features;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.SSS;

public class BlinkingMenu : AbstractMenu
{
    public static BlinkingMenu Instance { get; } = new();
    
    protected override ASSGroup Generate(Player owner)
    {
        var configuration = EntryPoint.Instance?.Config?.SSSConfig ?? new SSSConfiguration();

        List<ASSBase> bases =
        [
            new ASSHeader(configuration.HeaderId, configuration.HeaderLabel, configuration.ReducedPaddingHeader,
                configuration.HeaderHint),
            new ASSKeybind(configuration.KeybindId, configuration.KeybindLabel, configuration.KeybindSuggestedKey,
                configuration.KeybindTriggerInGui, configuration.KeybindTriggerWhenSpectating,
                configuration.KeybindHint),
            new ASSTwoButtons(configuration.ShowEyeId, configuration.ShowEyeLabel, configuration.ShowEyeLeftOption, configuration.ShowEyeRightOption, 
                configuration.ShowEyeDefaultlySelectedRight)
        ];

        return new ASSGroup(bases, configuration.MenuPriority, player => player == owner);
    }

    public void OnSettingTriggered(SettingTriggeredEventArgs ev)
    {
        var configuration = EntryPoint.Instance?.Config?.SSSConfig ?? new SSSConfiguration();
        if (ev.Setting.Id == configuration.KeybindId && ev.Setting is ASSKeybind keybind && keybind.IsPressed)
        {
            var data = PlayerData.GetPlayerData(ev.Player);
            data?.Blink(BlinkReason.Manual);
        }
    }
}