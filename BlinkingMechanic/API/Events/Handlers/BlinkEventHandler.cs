using BlinkingMechanic.API.Events.EventArgs;
using LabApi.Events;

namespace BlinkingMechanic.API.Events.Handlers;

public static class BlinkEventHandler
{
    public static event LabEventHandler<BlinkingEventArgs>? Blinking;
    public static event LabEventHandler<BlinkedEventArgs>? Blinked;
    
    public static void OnBlinking(BlinkingEventArgs args)
    {
        Blinking?.InvokeEvent(args);
    }

    public static void OnBlinked(BlinkedEventArgs args)
    {
        Blinked?.InvokeEvent(args);
    }
}