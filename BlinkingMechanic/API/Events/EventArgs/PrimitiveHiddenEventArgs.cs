using BlinkingMechanic.API.Events.Interfaces;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Events.EventArgs;

public class OnPrimitiveHidden : System.EventArgs, IPlayerDataEvent, LabApi.Events.Arguments.Interfaces.ICancellableEvent, LabApi.Events.Arguments.Interfaces.IAdminToyEvent
{
    public PlayerData Player { get; }
    public bool IsAllowed { get; set; } = true;
    public AdminToy? AdminToy { get; }

    public OnPrimitiveHidden(PlayerData forPlayer, AdminToy? adminToy)
    {
        Player = forPlayer; ;
        AdminToy = adminToy;
    }
}