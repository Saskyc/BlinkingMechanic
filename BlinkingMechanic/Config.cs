using System.Collections.Generic;
using System.ComponentModel;
using PlayerRoles;

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

        public List<RoleTypeId> BlacklistedRoles { get; set; } = 
        [
            RoleTypeId.Scp049,
            RoleTypeId.Scp0492,
            RoleTypeId.Scp079,
            RoleTypeId.Scp096,
            RoleTypeId.Scp106,
            RoleTypeId.Scp173,
            RoleTypeId.Scp939,
            RoleTypeId.Scp3114,
        ];

        public List<Team> BlacklistedTeams { get; set; } =
        [
            Team.SCPs,
        ];
    }
}