using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AdminToys;
using BlinkingMechanic.API.Events.EventArgs;
using BlinkingMechanic.API.Events.Handlers;
using BlinkingMechanic.Features;
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
    public bool HideSetup = false;
    
    public bool Shown = false;
    public bool PrimitiveSetupped = false;
    public PrimitiveObjectToy? PrimitiveObjectToy { get; set; }
    
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
        if (!blinking.IsAllowed) return;
        OnBlinked(reason);
    }

    public void TryHideSetup()
    {
        if (HideSetup || !Player.TryGetTarget(out var target)) return;
        
        if(!PrimitiveSetupped) TrySpawnPrimitive();
        foreach (var plr in LabApi.Features.Wrappers.Player.ReadyList)
        {
            if (plr == target) continue;
            Hide(plr);
            GetPlayerData(plr).Hide(target);
        }

        HideSetup = true;
    }
    
    public void TrySpawnPrimitive()
    {
        if (!Player.TryGetTarget(out var data)) return;
        PrimitiveShowingEventArgs showingEventArgs;
        if (!PrimitiveSetupped)
        {
            var eventArgs = new MainPrimitiveSpawningEventArgs(this, PrimitiveType.Cube, PrimitiveFlags.Visible, Color.black, 
                new Vector3(0, 0.5f, 1), Quaternion.identity, new Vector3(1, 1.5f, 1.5f));
            BlinkEventHandler.OnMainPrimitiveSpawning(eventArgs);
            
            PrimitiveObjectToy primitiveObjectToy = PrimitiveObjectToy.Create(null, false);
            NetworkServer.Spawn(primitiveObjectToy.GameObject);
            primitiveObjectToy.Transform.parent = data.GameObject!.transform;

            primitiveObjectToy.Type = eventArgs.Type;
            primitiveObjectToy.Flags = eventArgs.Flags;
            primitiveObjectToy.Color = eventArgs.Color;

            primitiveObjectToy.GameObject.transform.localPosition = eventArgs.LocalPosition;
            primitiveObjectToy.Rotation = eventArgs.LocalRotation;
            primitiveObjectToy.Scale = eventArgs.Scale;
            
            PrimitiveObjectToy = primitiveObjectToy;
            PrimitiveSetupped = true;
            
            BlinkEventHandler.OnMainPrimitiveSpawned(new MainPrimitiveSpawnedEventArgs(this, primitiveObjectToy));
            
            Shown = true;
            showingEventArgs = new PrimitiveShowingEventArgs(this, primitiveObjectToy);
            BlinkEventHandler.OnPrimitiveShowing(showingEventArgs);
            if (!showingEventArgs.IsAllowed)
            {
                Hide();
            }
            else
            {
                BlinkEventHandler.OnPrimitiveShowed(new PrimitiveShowedEventArgs(this, PrimitiveObjectToy));
            }
            
            return;
        }

        if (Shown || !data.Connection.isReady) return;
        
        showingEventArgs = new PrimitiveShowingEventArgs(this, PrimitiveObjectToy);
        BlinkEventHandler.OnPrimitiveShowing(showingEventArgs);
        if (!showingEventArgs.IsAllowed) return;
        
        Shown = true;
        if (ShowMethod != null)
        {
            ShowMethod.Invoke(null, [PrimitiveObjectToy!.Base.netIdentity, data.Connection]);
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                Logger.Error("[BLINKING MECHANIC] THE SHOW METHOD IS NON EXISTENT, PLEASE REPORT THIS ISSUE TO SASKYC ASAP, PLUGIN SHUTDOWN");
            }
            EntryPoint.Instance.Disable();
        }
        
        BlinkEventHandler.OnPrimitiveShowed(new PrimitiveShowedEventArgs(this, PrimitiveObjectToy));
    }

    public void Hide(Player? player = null)
    {
        if (player == null && !Player.TryGetTarget(out player)) return;
        
        PrimitiveHidingEventArgs hiding = new PrimitiveHidingEventArgs(this, PrimitiveObjectToy, GetPlayerData(player));
        BlinkEventHandler.OnPrimitiveHiding(hiding);
        if (!hiding.IsAllowed) return;
        
        if(!PrimitiveSetupped) TrySpawnPrimitive();
        Shown = false;
        ObjectHideMessage message = new ObjectHideMessage()
        {
            netId = PrimitiveObjectToy.Base.netIdentity.netId
        };
        player.Connection.Send(message);
        
        BlinkEventHandler.OnPrimitiveHidden(new PrimitiveHiddenEventArgs(this, PrimitiveObjectToy, GetPlayerData(player)));
    }

    public void OnBlinked(BlinkReason reason = BlinkReason.Forced)
    {
        if (!Player.TryGetTarget(out var data) || data == null) return;
        TrySpawnPrimitive();
        
        //PrimitiveObjectToy?.Scale = new Vector3(1, 1.5f, 1.5f);
        LastBlink = DateTime.Now;
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