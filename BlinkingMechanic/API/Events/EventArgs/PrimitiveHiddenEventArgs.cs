using BlinkingMechanic.API.Events.Interfaces;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.EventArgs;

public class PrimitiveHiddenEventArgs : System.EventArgs, IPlayerDataEvent, ITargetDataEvent, LabApi.Events.Arguments.Interfaces.IAdminToyEvent
{
    public PlayerData Player { get; }
    public PlayerData Target { get; }
    public AdminToy? AdminToy { get; }

    public PrimitiveHiddenEventArgs(PlayerData player, AdminToy? adminToy, PlayerData target)
    {
        Player = player;
        AdminToy = adminToy;
        Target = target;
    }
}