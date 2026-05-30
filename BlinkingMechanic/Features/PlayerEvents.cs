using BlinkingMechanic.API;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Arguments.Scp096Events;
using LabApi.Events.Arguments.Scp173Events;
using PlayerRoles.PlayableScps.Scp096;
using PlayerRoles.PlayableScps.Scp173;

namespace BlinkingMechanic.Features;

internal class PlayerEvents
{
    internal static void Subscribe()
    {
        LabApi.Events.Handlers.PlayerEvents.Joined += OnPlayerJoined;
    }

    internal static void Unsubscribe()
    {
        LabApi.Events.Handlers.PlayerEvents.Joined -= OnPlayerJoined;
    }

    internal static void OnPlayerJoined(PlayerJoinedEventArgs ev)
    {
        PlayerData.GetPlayerData(ev.Player).TryHideSetup();
    }
}