using BlinkingMechanic.API.Events.Interfaces;
using BlinkingMechanic.Features;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.EventArgs;

public class BlinkingEventArgs : System.EventArgs, IPlayerDataEvent, LabApi.Events.Arguments.Interfaces.ICancellableEvent, IBlinkReasonEvent
{
    public PlayerData Player { get; }
    public bool IsAllowed { get; set; } = true;
    public BlinkReason Reason { get; set; }

    public BlinkingEventArgs(Player player, BlinkReason reason)
    {
        Player = PlayerData.GetPlayerData(player);
        Reason = reason;
    }
}