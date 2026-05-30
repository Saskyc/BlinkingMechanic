using System;
using BlinkingMechanic.API.Events.Test;
using BlinkingMechanic.Features;
using HarmonyLib;
using LabApi.Loader.Features.Plugins;
using MEC;

namespace BlinkingMechanic
{
    public class EntryPoint : Plugin<Config>
    {
        public override string Name { get; } = "BlinkingMechanic";
        public override string Description { get; } = "Mechanic introducing blinking into SCP:SL";
        public override string Author { get; } = "Saskyc";
        public override Version Version { get; } = new Version(1, 1, 0);
        public override Version RequiredApiVersion { get; } = new Version(1, 1, 6, 0);
        public static EntryPoint? Instance { get; private set; }
        public CoroutineHandle? Coroutine { get; private set; }
        public Harmony? Harmony { get; private set; }
        
        public override void Enable()
        {
            Instance = this;
            
            if (Config.IsDebug)
            {
                TestEvents.Subscribe();
            }
            Coroutine = Timing.RunCoroutine(BlinkingCoroutine.Loop());
            Harmony = new Harmony("BlinkingMechanic.com");
            Harmony.PatchAll();
        }

        public override void Disable()
        {
            if (Harmony != null)
            {
                Harmony.UnpatchAll();
                Harmony = null;
            }
            
            if (Coroutine.HasValue)
            {
                Timing.KillCoroutines(Coroutine.Value);
                Coroutine = null;
            }
            
            TestEvents.Unsubscribe();
            Instance = null;
        }
    }
}