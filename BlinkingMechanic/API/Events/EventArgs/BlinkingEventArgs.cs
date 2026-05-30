using System;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.EventArgs;

public class OnBlinking : System.EventArgs
{
    public PlayerData Player { get; }
    public bool IsAllowed { get; }
    
    public OnBlinking(Player player, bool isAllowed)
    {
        Player = PlayerData.GetPlayerData(player);
        IsAllowed = isAllowed;
    }
}