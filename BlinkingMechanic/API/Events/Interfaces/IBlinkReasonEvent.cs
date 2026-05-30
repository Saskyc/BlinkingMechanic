using BlinkingMechanic.Features;

namespace BlinkingMechanic.API.Events.Interfaces;

public interface IBlinkReasonEvent
{
    public BlinkReason Reason { get; set; }
}