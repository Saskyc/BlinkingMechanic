using AdminToys;
using UnityEngine;

namespace BlinkingMechanic.API.Events.Interfaces;

public interface IPrimitiveOptionEvent
{
    public PrimitiveType Type { get; set; }
    public PrimitiveFlags Flags { get; set; }
    public Color Color { get; set; }
    public Vector3 LocalPosition { get; set; }
    public Quaternion LocalRotation { get; set; }
    public Vector3 Scale { get; set; }
}