using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace vsexamplerandomiser.src.Behaviors
{
    public class EntityBehaviorRandomHp : EntityBehavior
    {
        ICoreServerAPI sapi;
        public override string PropertyName() { return "EntityBehaviorRandomHp"; }
        public EntityBehaviorRandomHp(Entity entity) : base(entity) { }

        public override void Initialize(EntityProperties properties, JsonObject attributes)
        {
            if (entity != null && entity.Api.Side == EnumAppSide.Server)
                sapi = entity.Api as ICoreServerAPI;

            base.Initialize(properties, attributes);
        }

        public override void OnEntitySpawn()
        {
            base.OnEntitySpawn();
            if (entity is EntityItem)
                return;

            RandomiseMaxHealth();
        }

        public override void OnEntityLoaded()
        {
            base.OnEntityLoaded();
            if (entity is EntityItem)
                return;

            RandomiseMaxHealth();
        }

        private void RandomiseMaxHealth()
        {
            if (IsHealthRandomised())
                return;

            if (!entity.HasBehavior<EntityBehaviorHealth>())
                return;

            var behavior = entity.GetBehavior<EntityBehaviorHealth>();
            if (behavior != null)
            {
                behavior.BaseMaxHealth = CalculateMaxHealth(behavior.MaxHealth);
                entity.WatchedAttributes.SetBool("randomisedhp", true);
                behavior.UpdateMaxHealth();
            }
        }

        public bool IsHealthRandomised()
        {
            return entity.WatchedAttributes.GetBool("randomisedhp", false);
        }

        private float CalculateMaxHealth(float defaultMaxHealth)
        {
            // do some stuff here
            int min = (int)defaultMaxHealth - 10;
            int max = (int)defaultMaxHealth + 10;
            float result = Randomise.Instance.Random.Next(min, max);
            if (result < 0)
                return 1;

            if (result > float.MaxValue)
                return float.MaxValue;

            return result;
        }
    }
}
