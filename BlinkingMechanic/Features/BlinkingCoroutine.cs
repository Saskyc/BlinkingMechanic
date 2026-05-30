using System;
using System.Collections.Generic;
using BlinkingMechanic.API;
using LabApi.Features.Wrappers;
using MEC;
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
        if (!player.IsAlive) return;
        var data = PlayerData.GetPlayerData(player);
        data.TryHideSetup();
        
        if (data.Elapsed.TotalMilliseconds > EntryPoint.Instance!.Config.BlinkLasting && data.PrimitiveSetupped && data.PrimitiveObjectToy?.GameObject && data.Shown)
        {
            data.Hide();
        }

        if (data.Elapsed.TotalSeconds > EntryPoint.Instance!.Config.TimeBlink)
        {
            data.Blink(BlinkReason.Time);
        }
    }
}