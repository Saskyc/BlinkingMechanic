namespace BlinkingMechanic;

public class RueiConfiguration
{
    public string EyeHintId { get; set; } = "remainingTime_untilBlink";
    public float EyeYPos { get; set; } = 100;
    public string EyeTextShown { get; set; } = "<alpha=#%eyeRemainOpacity%>👀<alpha=#FF>";
}