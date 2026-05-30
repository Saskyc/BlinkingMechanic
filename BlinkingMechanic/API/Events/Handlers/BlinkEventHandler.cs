using BlinkingMechanic.API.Events.EventArgs;
using LabApi.Events;

namespace BlinkingMechanic.API.Events.Handlers;

public static class BlinkEventHandler
{
    public static event LabEventHandler<BlinkingEventArgs>? Blinking;
    public static event LabEventHandler<BlinkedEventArgs>? Blinked;

    public static event LabEventHandler<MainPrimitiveSpawningEventArgs>? MainPrimitiveSpawning; 
    public static event LabEventHandler<MainPrimitiveSpawnedEventArgs>? MainPrimitiveSpawned;
    public static event LabEventHandler<PrimitiveHidingEventArgs>? PrimitiveHiding;
    public static event LabEventHandler<PrimitiveHiddenEventArgs>? PrimitiveHidden;
    public static event LabEventHandler<PrimitiveShowingEventArgs>? PrimitiveShowing;
    public static event LabEventHandler<PrimitiveShowedEventArgs>? PrimitiveShowed;
    
    public static void OnBlinking(BlinkingEventArgs args)
    {
        Blinking?.InvokeEvent(args);
    }

    public static void OnBlinked(BlinkedEventArgs args)
    {
        Blinked?.InvokeEvent(args);
    }

    public static void OnMainPrimitiveSpawning(MainPrimitiveSpawningEventArgs ev)
    {
        MainPrimitiveSpawning.InvokeEvent(ev);
    }

    public static void OnMainPrimitiveSpawned(MainPrimitiveSpawnedEventArgs ev)
    {
        MainPrimitiveSpawned?.InvokeEvent(ev);
    }

    public static void OnPrimitiveHiding(PrimitiveHidingEventArgs ev)
    {
        PrimitiveHiding?.InvokeEvent(ev);
    }
    
    public static void OnPrimitiveHidden(PrimitiveHiddenEventArgs ev)
    {
        PrimitiveHidden?.InvokeEvent(ev);
    }

    public static void OnPrimitiveShowing(PrimitiveShowingEventArgs ev)
    {
        PrimitiveShowing?.InvokeEvent(ev);
    }
    
    public static void OnPrimitiveShowed(PrimitiveShowedEventArgs ev)
    {
        PrimitiveShowed?.InvokeEvent(ev);
    }
}