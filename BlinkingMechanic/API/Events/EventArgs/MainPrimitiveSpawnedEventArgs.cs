using BlinkingMechanic.API.Events.Interfaces;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.EventArgs;

public class MainPrimitiveSpawnedEventArgs : System.EventArgs, IPlayerDataEvent, LabApi.Events.Arguments.Interfaces.IAdminToyEvent
{
    public PlayerData Player { get; }
    public AdminToy? AdminToy { get; }
    
    public MainPrimitiveSpawnedEventArgs(PlayerData player, AdminToy adminToy)
    {
        Player = player;
        AdminToy = adminToy;
    }

    
}