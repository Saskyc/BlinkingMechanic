using BlinkingMechanic.API.Events.Interfaces;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.EventArgs;

public class PrimitiveHiddenEventArgs : System.EventArgs, IPlayerDataEvent, ITargetDataEvent, LabApi.Events.Arguments.Interfaces.ICancellableEvent, LabApi.Events.Arguments.Interfaces.IAdminToyEvent
{
    public PlayerData Player { get; }
    public PlayerData Target { get; }
    public bool IsAllowed { get; set; } = true;
    public AdminToy? AdminToy { get; }

    public PrimitiveHiddenEventArgs(PlayerData forPlayer, AdminToy? adminToy, PlayerData target)
    {
        Player = forPlayer; ;
        AdminToy = adminToy;
        Target = target;
    }
}