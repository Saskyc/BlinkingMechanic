using System.Collections.Generic;
using BlinkingMechanic.SSS;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.EventHandler;

public class PlayerEventHandler : CustomEventsHandler
{
    public override void OnPlayerJoined(PlayerJoinedEventArgs ev)
    {
        BlinkingMenu.Instance.Add(ev.Player);
    }

    public override void OnPlayerLeft(PlayerLeftEventArgs ev)
    {
        BlinkingMenu.Instance.Remove(ev.Player);
        base.OnPlayerLeft(ev);
    }
}