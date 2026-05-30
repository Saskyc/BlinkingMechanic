using System.ComponentModel;

namespace BlinkingMechanic
{
    public class Config
    {
        [Description("If Debug is enabled [You might have a lot of logs in console after this]")]
        public bool IsDebug { get; set; } = false;
        
        [Description("Time between blinks. [IN SECONDS]")]
        public float TimeBlink { get; set; } = 3;
        
        [Description("Time that blinking is lasting. [IN MILISECONDS]")]
        public float BlinkLasting { get; set; } = 500;
    }
}