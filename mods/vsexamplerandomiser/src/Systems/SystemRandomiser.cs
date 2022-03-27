using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using vsexamplerandomiser.src.Behaviors;

namespace vsexamplerandomiser.src.Systems
{
    public class SystemAbilities : ModSystem
    {
        ICoreServerAPI sapi;
        public override void StartServerSide(ICoreServerAPI api)
        {
            sapi = api;
            base.StartServerSide(api);
            api.RegisterEntityBehaviorClass("EntityBehaviorRandomHp", typeof(EntityBehaviorRandomHp));
        }
    }
}
