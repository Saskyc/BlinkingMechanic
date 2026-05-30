using BlinkingMechanic.API.Events.Interfaces;
using BlinkingMechanic.Features;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.EventArgs;

public class BlinkedEventArgs : System.EventArgs, IPlayerDataEvent, IBlinkReasonEvent
{
    public PlayerData Player { get; }
    public BlinkReason Reason { get; set; }
    
    public BlinkedEventArgs(Player player, BlinkReason reason)
    {
        Player = PlayerData.GetPlayerData(player);
        Reason = reason;
    }
}