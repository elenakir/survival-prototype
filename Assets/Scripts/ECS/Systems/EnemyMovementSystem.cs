using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;
using Survival.Player;
using Survival.Stats;
using Survival.Enemy;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyMovementSystem))]
public sealed class EnemyMovementSystem : UpdateSystem
{
    private Filter filter;

    [Inject] private Player player;

    public override void OnAwake() 
    {
        filter = World.Filter.With<EnemyMovementComponent>().With<HealthComponent>().With<StatsComponent>();
    }

    public override void OnUpdate(float deltaTime) 
    {
        if (!GameSettings.isPause)
        {
            foreach (var e in filter)
            {
                ref var movement = ref e.GetComponent<EnemyMovementComponent>();
                ref var stats = ref e.GetComponent<StatsComponent>();

                movement.enemyTransform.position =
                    Vector3.MoveTowards(movement.enemyTransform.position, player.transform.position, stats.speed * Time.deltaTime);

            }
        }
    }
}