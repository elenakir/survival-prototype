using Morpeh;
using UnityEngine;
using Zenject;
using Survival.Bullets;
using Survival.Enemy;

namespace Survival.Collisions
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionInitSystem))]
    public sealed class CollisionInitSystem : FixedUpdateSystem
    {
        [Inject] private EnemySpawner spawner;

        private Filter enemiesFilter;

        private Filter playerFilter;

        public override void OnAwake()
        {
            enemiesFilter = World.Filter.With<EnemyComponent>().With<EntityBodyComponent>().Without<CanCollideComponent>();
            playerFilter = World.Filter.With<PlayerComponent>().With<EntityBodyComponent>().Without<CanCollideComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity e in enemiesFilter)
            {
                ref var enemy = ref e.GetComponent<EntityBodyComponent>();
                MakeCanCollide(e, enemy.body);
            }

            foreach (Entity e in World.Filter.With<BulletComponent>().Without<CanCollideComponent>())
            {
                ref var bullet = ref e.GetComponent<BulletComponent>(); ;
                MakeCanCollide(e, bullet.body);
            }

            foreach (Entity e in playerFilter)
            {
                ref var player = ref e.GetComponent<EntityBodyComponent>();
                MakeCanCollide(e, player.body);
            }
        }

        private void MakeCanCollide(Entity entity, GameObject gameObject)
        {
            ref var canCollide = ref entity.AddComponent<CanCollideComponent>();
            canCollide.detector = gameObject.AddComponent<CollisionDetector>();
            canCollide.detector.Init(World, spawner);
            canCollide.detector.listener = entity;
        }
    }
}