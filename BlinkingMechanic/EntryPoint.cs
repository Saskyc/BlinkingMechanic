using System;
using ASS.Features.Collections;
using BlinkingMechanic.API.Events.Test;
using BlinkingMechanic.EventHandler;
using BlinkingMechanic.Features;
using BlinkingMechanic.SSS;
using HarmonyLib;
using LabApi.Events;
using LabApi.Events.CustomHandlers;
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
        
        public PlayerEventHandler? PlayerEventHandler { get; private set; }
        
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

            ASS.Events.Handlers.SettingEvents.SettingTriggered += BlinkingMenu.Instance.OnSettingTriggered;
            CustomHandlersManager.RegisterEventsHandler(PlayerEventHandler ??= new PlayerEventHandler());
        }

        public override void Disable()
        {
            if(PlayerEventHandler != null)
                CustomHandlersManager.UnregisterEventsHandler(PlayerEventHandler);
            ASS.Events.Handlers.SettingEvents.SettingTriggered -= BlinkingMenu.Instance.OnSettingTriggered;
            
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