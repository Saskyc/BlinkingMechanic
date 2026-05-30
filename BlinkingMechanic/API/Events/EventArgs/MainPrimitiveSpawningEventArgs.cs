using AdminToys;
using BlinkingMechanic.API.Events.Interfaces;
using UnityEngine;

namespace BlinkingMechanic.API.Events.EventArgs;

public class MainPrimitiveSpawningEventArgs : System.EventArgs, IPlayerDataEvent, IPrimitiveOptionEvent
{
    public PlayerData Player { get; }
    public PrimitiveType Type { get; set; }
    public PrimitiveFlags Flags { get; set; }
    public Color Color { get; set; }
    public Vector3 LocalPosition { get; set; }
    public Quaternion LocalRotation { get; set; }
    public Vector3 Scale { get; set; }
    
    public MainPrimitiveSpawningEventArgs(PlayerData player, PrimitiveType type, PrimitiveFlags flags, Color color, 
        Vector3 localPosition, Quaternion localRotation, Vector3 scale)
    {
        Player = player;
        Type = type;
        Flags = flags;
        Color = color;
        LocalPosition = localPosition;
        LocalRotation = localRotation;
        Scale = scale;
    }
}