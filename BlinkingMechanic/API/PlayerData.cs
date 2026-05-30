using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AdminToys;
using BlinkingMechanic.API.Events.EventArgs;
using BlinkingMechanic.API.Events.Handlers;
using BlinkingMechanic.Features;
using CustomPlayerEffects;
using LabApi.Features.Wrappers;
using Mirror;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;
using PrimitiveObjectToy = LabApi.Features.Wrappers.PrimitiveObjectToy;

namespace BlinkingMechanic.API;

public class PlayerData
{
    public static readonly MethodInfo? ShowMethod = typeof(NetworkServer).GetMethod(
        "SendSpawnMessage",
        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
        null,
        new[]
        {
            typeof(NetworkIdentity),
            typeof(NetworkConnection)
        },
        null);
    
    public static ConditionalWeakTable<Player, PlayerData> PlayerDataTable { get; } = new();
    public DateTime LastBlink { get; private set; }
    public TimeSpan Elapsed => DateTime.Now - LastBlink;
    
    public WeakReference<Player> Player { get; }
    
    public PlayerData(Player player)
    {
        Player = new WeakReference<Player>(player);
        LastBlink = DateTime.Now;
    }

    public void Blink(BlinkReason reason)
    {
        if (!Player.TryGetTarget(out var data) || data == null) return;
        BlinkingEventArgs blinking = new BlinkingEventArgs(data, reason);
        BlinkEventHandler.OnBlinking(blinking);
        
        LastBlink = DateTime.Now;
        if (!blinking.IsAllowed) return;
        OnBlinked(reason);
        
    }

    public void OnBlinked(BlinkReason reason = BlinkReason.Forced)
    {
        if (!Player.TryGetTarget(out var data) || data == null) return;
        if (!data.HasEffect<Blindness>())
        {
            data.EnableEffect<Blindness>(255, EntryPoint.Instance!.Config.BlinkLasting / 100);
        }
        BlinkEventHandler.OnBlinked(new BlinkedEventArgs(data, reason));
    }
    
    public static PlayerData GetPlayerData(Player player)
    {
        if (PlayerDataTable.TryGetValue(player, out var data)) return data;
        data = new PlayerData(player);
        PlayerDataTable.Add(player, data);
        return data;
    }

    public static PlayerData GetPlayerData(ReferenceHub player) =>
        GetPlayerData(LabApi.Features.Wrappers.Player.Get(player));
}