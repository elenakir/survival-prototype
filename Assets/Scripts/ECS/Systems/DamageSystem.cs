using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;
using Survival.Enemy;

namespace Survival.Stats
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DamageSystem))]
    public sealed class DamageSystem : UpdateSystem
    {
        [Inject] private EnemySpawner spawner;

        private Filter filter;

        public override void OnAwake() {
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var e in World.Filter.With<EntityBodyComponent>().With<HealthComponent>().With<DamageComponent>())
            {
                ref var health = ref e.GetComponent<HealthComponent>();
                ref var damage = ref e.GetComponent<DamageComponent>();

                health.healthPoints -= damage.value;

                e.RemoveComponent<DamageComponent>();
            }
        }
    }
}