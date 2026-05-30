using BlinkingMechanic.API.Events.EventArgs;
using BlinkingMechanic.API.Events.Handlers;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.Test;

internal class TestEvents
{
    internal static bool Subscribed = false;
    
    internal static void Subscribe()
    {
        if (Subscribed) return;

        BlinkEventHandler.Blinking += OnBlinking;
        BlinkEventHandler.Blinked += OnBlinked;
        
        Subscribed = true;
    }

    internal static void Unsubscribe()
    {
        if (!Subscribed) return;
        
        BlinkEventHandler.Blinking -= OnBlinking;
        BlinkEventHandler.Blinked -= OnBlinked;
        
        Subscribed = false;
    }

    internal static void OnBlinking(BlinkingEventArgs ev)
    {
        if (ev.Player.Player.TryGetTarget(out Player player))
        {
            Logger.Info($"Player: {player.Nickname} is blinking.");
        }
        else
        {
            Logger.Info("Couldn't get Player who is blinking");
        }
    }
    
    internal static void OnBlinked(BlinkedEventArgs ev)
    {
        if (ev.Player.Player.TryGetTarget(out Player player))
        {
            Logger.Info($"Player: {player.Nickname} blinked.");
        }
        else
        {
            Logger.Info("Couldn't get Player who blinked");
        }
    }
}