using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;

namespace Survival.Effects
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ExplosionSystem))]
    public sealed class ExplosionSystem : UpdateSystem
    {
        private Filter filter;

        [Inject] private ExplosionSpawner spawner;

        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            if (!GameSettings.isPause)
            {
                filter = World.Filter.With<ExplosionComponent>();

                foreach (var e in filter)
                {
                    ref var exp = ref e.GetComponent<ExplosionComponent>();

                    spawner.CreateExplosion(exp.location);

                    e.RemoveComponent<ExplosionComponent>();
                }
            }
        }
    }
}