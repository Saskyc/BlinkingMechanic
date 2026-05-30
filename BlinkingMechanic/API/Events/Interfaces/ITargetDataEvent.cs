namespace BlinkingMechanic.API.Events.Interfaces;

public interface ITargetDataEvent
{
    public PlayerData Target { get; }
}