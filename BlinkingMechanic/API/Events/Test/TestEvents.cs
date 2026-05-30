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
        
        BlinkEventHandler.MainPrimitiveSpawning += OnMainPrimitiveSpawning;
        BlinkEventHandler.MainPrimitiveSpawned += OnMainPrimitiveSpawned;
        
        BlinkEventHandler.PrimitiveHiding += OnPrimitiveHiding;
        BlinkEventHandler.PrimitiveHidden += OnPrimitiveHidden;
        
        BlinkEventHandler.PrimitiveShowing += OnPrimitiveShowing;
        BlinkEventHandler.PrimitiveShowed += OnPrimitiveShowed;
        
        Subscribed = true;
    }

    internal static void Unsubscribe()
    {
        if (!Subscribed) return;
        
        BlinkEventHandler.Blinking -= OnBlinking;
        BlinkEventHandler.Blinked -= OnBlinked;
        
        BlinkEventHandler.MainPrimitiveSpawning -= OnMainPrimitiveSpawning;
        BlinkEventHandler.MainPrimitiveSpawned -= OnMainPrimitiveSpawned;
        
        BlinkEventHandler.PrimitiveHiding -= OnPrimitiveHiding;
        BlinkEventHandler.PrimitiveHidden -= OnPrimitiveHidden;
        
        BlinkEventHandler.PrimitiveShowing -= OnPrimitiveShowing;
        BlinkEventHandler.PrimitiveShowed -= OnPrimitiveShowed;
        
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

    internal static void OnMainPrimitiveSpawning(MainPrimitiveSpawningEventArgs ev)
    {
        Logger.Info("Main primitive is spawning");
    }

    internal static void OnMainPrimitiveSpawned(MainPrimitiveSpawnedEventArgs ev)
    {
        Logger.Info("Main primitive spawned");
    }

    internal static void OnPrimitiveHiding(PrimitiveHidingEventArgs ev)
    {
        if (ev.Player.Player.TryGetTarget(out Player player) && ev.Target.Player.TryGetTarget(out Player target))
        {
            if (player == target)
            {
                Logger.Info($"Hiding primitive for {player.Nickname} that he owns.");
            }
            else
            {
                Logger.Info($"Hiding primitive owned by {player.Nickname} for {target.Nickname}.");
            }
        }
        else
        {
            Logger.Info("Couldn't get the primitive that was being hidden.");
        }
    }
    
    internal static void OnPrimitiveHidden(PrimitiveHiddenEventArgs ev)
    {
        if (ev.Player.Player.TryGetTarget(out Player player) && ev.Target.Player.TryGetTarget(out Player target))
        {
            if (player == target)
            {
                Logger.Info($"Hidden primitive for {player.Nickname} that he owns.");
            }
            else
            {
                Logger.Info($"Hidden primitive owned by {player.Nickname} for {target.Nickname}.");
            }
        }
        else
        {
            Logger.Info("Couldn't get the primitive that was hidden.");
        }
    }

    internal static void OnPrimitiveShowing(PrimitiveShowingEventArgs ev)
    {
        if (ev.Player.Player.TryGetTarget(out Player player))
        {
            Logger.Info($"Showing primitive for {player.Nickname}");
        }
        else
        {
            Logger.Info("Couldn't get player that the primitive was showing for.");
        }
    }
    
    internal static void OnPrimitiveShowed(PrimitiveShowedEventArgs ev)
    {
        if (ev.Player.Player.TryGetTarget(out Player player))
        {
            Logger.Info($"Showed primitive for {player.Nickname}");
        }
        else
        {
            Logger.Info("Couldn't get player that the primitive was showed for.");
        }
    }
}