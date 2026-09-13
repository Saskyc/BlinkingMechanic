using System;
using System.Collections.Generic;
using ASS.Features;
using ASS.Features.Settings;
using BlinkingMechanic.API;
using CustomPlayerEffects;
using LabApi.Features.Wrappers;
using MEC;
using RueI.API;
using RueI.API.Elements;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;

namespace BlinkingMechanic.Features;

public class BlinkingCoroutine
{
    public static IEnumerator<float> Loop()
    {
        while (true)
        {
            try
            {
                foreach (var player in Player.ReadyList)
                {
                    Action(player);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            yield return Timing.WaitForSeconds(0.1f);
        }
    }

    public static void Action(Player player)
    {
        RueDisplay display = RueDisplay.Get(player);
        RueiConfiguration hintConfig =
            EntryPoint.Instance?.Config?.HintConfig ?? new RueiConfiguration();
        
        if (!player.IsAlive ||
            EntryPoint.Instance!.Config.BlacklistedRoles.Contains(player.Role) ||
            EntryPoint.Instance.Config.BlacklistedTeams.Contains(player.Team))
        {
            display.Remove(new Tag(hintConfig.EyeHintId));
            return;
        }

        PlayerData data = PlayerData.GetPlayerData(player);

        int opacity = Mathf.Clamp(
            (int)(100 - data.Elapsed.TotalSeconds /
                (EntryPoint.Instance?.Config?.TimeBlink ?? 3) * 100), 0, 100);

        if (data.Elapsed.TotalMilliseconds > (EntryPoint.Instance?.Config?.BlinkLasting ?? 500))
        {
            player.DisableEffect<Blindness>();
        }

        var configuration = EntryPoint.Instance?.Config?.SSSConfig ?? new SSSConfiguration();
        
        if (opacity <= 0 || !ASSNetworking.TryGetSetting(player, configuration.ShowEyeId, out ASSTwoButtons? twoButtons) || twoButtons.RightSelected)
        {
            display.Remove(new Tag(hintConfig.EyeHintId));
        }
        
        else if(!player.HasEffect<Blindness>() && twoButtons.LeftSelected)
        {
            Tag tag = new(hintConfig.EyeHintId);

            BasicElement basicHint = new(
                hintConfig.EyeYPos,
                hintConfig.EyeTextShown.Replace(
                    "%eyeRemainOpacity%",
                    $"{opacity * 255 / 100:X2}"));

            display.Show(tag, basicHint);
        }

        if (data.Elapsed.TotalSeconds > (EntryPoint.Instance?.Config?.TimeBlink ?? 3))
        {
            data.Blink(BlinkReason.Time);
        }
    }
}