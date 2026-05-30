using BlinkingMechanic.API;
using CustomPlayerEffects;
using PlayerRoles.PlayableScps.Scp173;
using HarmonyLib;
using LabApi.Features.Wrappers;
using PlayerRoles.PlayableScps.Scp173;

namespace BlinkingMechanic.Features;

[HarmonyPatch(typeof(Scp173ObserversTracker), nameof(Scp173ObserversTracker.IsObservedBy))]
public static class Scp173ObserverPatch
{
    public static bool Prefix(ReferenceHub target, float widthMultiplier, ref bool __result)
    {
        if (Player.Get(target).HasEffect<Blindness>())
        {
            __result = false;
            return false;
        }

        return true;
    }
}