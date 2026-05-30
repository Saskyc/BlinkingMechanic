using BlinkingMechanic.Features;
using LabApi.Features.Wrappers;

namespace BlinkingMechanic.API.Extensions;

public static class PlayerExtension
{
    public static void Blink(this Player player, BlinkReason reason)
    {
        PlayerData.GetPlayerData(player)?.Blink(reason);
    }
}