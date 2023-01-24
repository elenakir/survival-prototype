using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;

namespace Survival.Bullets
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BulletSpawnSystem))]
    public sealed class BulletSpawnSystem : UpdateSystem
    {
        [Inject] private BulletSpawner bullet;

        private Filter filter;

        public override void OnAwake()
        {
            filter = World.Filter.With<BulletSpawnComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var e in filter)
            {
                if (e.Has<BulletSpawnComponent>())
                {
                    bullet.CreateBullet();

                    e.RemoveComponent<BulletSpawnComponent>();
                }
            }
        }
    }
}