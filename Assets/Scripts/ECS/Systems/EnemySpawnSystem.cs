using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;
using Survival.Stats;
using Survival.Enemy;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemySpawnSystem))]
public sealed class EnemySpawnSystem : UpdateSystem 
{
    [Inject] private EnemySpawner spawner;

    private Filter filter;

    public override void OnAwake()
    {
        filter = World.Filter.With<HealthComponent>().With<StatsComponent>();
    }

    public override void OnUpdate(float deltaTime) 
    {
        spawner.Spawn();       
    }
}