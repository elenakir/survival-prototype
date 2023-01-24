using System;
using Morpeh;
using UnityEngine;
using Survival.Stats;
using Survival.Enemy;

namespace Survival.Collisions
{
    public class CollisionDetector : MonoBehaviour
    {
        public Entity listener;

        private EnemySpawner spawner;

        private Filter playerFilter;

        private World world;

        public void Init(World world, EnemySpawner spawner)
        {
            this.world = world;
            this.spawner = spawner;

            playerFilter = world.Filter.With<PlayerComponent>().With<StatsComponent>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!GameSettings.isPause)
            {
#if DEBUG
                if (listener == null || !listener.Has<CanCollideComponent>())
                {
                    throw new Exception($"{nameof(listener)} should have {nameof(CanCollideComponent)}");
                }
#endif

                Entity entity = world.CreateEntity();
                ref var e = ref entity.AddComponent<CollisionEventComponent>();
                e.collision = other;
                e.first = listener;

                var otherDetector = other.gameObject.GetComponent<CollisionDetector>();
                e.second = otherDetector != null ? otherDetector.listener : null;

                if (e.first.Has<EnemyComponent>())
                {
                    //нанесен урон player'у
                    if (e.second.Has<PlayerComponent>())
                    {
                        e.second.SetComponent(new DamageComponent()
                        {
                            value = e.first.GetComponent<StatsComponent>().damage * e.second.GetComponent<StatsComponent>().defence,
                        });

                        e.first.SetComponent(new DestroyObjectComponent()
                        {
                            gameObject = gameObject
                        });

                        spawner.DecreaseCount();
                    }
                    else
                    {
                        var playerStats = playerFilter.GetEntity(0).GetComponent<StatsComponent>();

                        //в enemy попал bullet
                        e.first.SetComponent(new DamageComponent()
                        {
                            value = playerStats.damage * e.first.GetComponent<StatsComponent>().defence
                        });

                        e.second.SetComponent(new DestroyObjectComponent()
                        {
                            gameObject = other.gameObject
                        });
                    }
                }
            }
        }
    }
}