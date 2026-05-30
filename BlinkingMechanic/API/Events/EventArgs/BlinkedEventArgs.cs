using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.EventArgs;

public class OnBlinked : System.EventArgs
{
    public PlayerData Player { get; }
    public OnBlinked(Player player)
    {
        Player = PlayerData.GetPlayerData(player);
    }
}