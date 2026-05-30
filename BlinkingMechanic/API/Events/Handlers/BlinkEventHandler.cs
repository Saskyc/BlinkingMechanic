using BlinkingMechanic.API.Events.EventArgs;
using LabApi.Events;

namespace BlinkingMechanic.API;

public static class PlayerEventHandler
{
    public static event LabEventHandler<BlinkingEventArgs>? OnBlinking;
    public static event LabEventHandler<BlinkedEventArgs>? OnBlinked;
}