using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;
using Survival.Player;
using Survival.Enemy;
using Survival.Effects;
using Survival.Stats;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(HealthSystem))]
public sealed class HealthSystem : UpdateSystem
{
    [Inject] private EnemySpawner spawner;

    [Inject] private LosePopup losePopup;

    [Inject] private Player player;

    private Filter filter;

    private Filter uiHealthFilter;

    private Filter enemiesCounterFilter;

    private Filter playerHealthFilter;

    public override void OnAwake()
    {
        filter = World.Filter.With<EntityBodyComponent>().With<HealthComponent>();
        uiHealthFilter = World.Filter.With<HealthLineComponent>();
        enemiesCounterFilter = World.Filter.With<EnemiesCounterComponent>();
        playerHealthFilter = World.Filter.With<PlayerComponent>().With<HealthComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {

        foreach (var e in uiHealthFilter)
        {
            ref var line = ref e.GetComponent<HealthLineComponent>();

            foreach (var h in playerHealthFilter)
            {
                ref var health = ref h.GetComponent<HealthComponent>();

                line.healthLine.fillAmount = health.healthPoints / 100;
            }
        }

        foreach (var e in filter)
        {
            ref var health = ref e.GetComponent<HealthComponent>();
            ref var go = ref e.GetComponent<EntityBodyComponent>();

            if (health.healthPoints <= 0)
            {
                World.CreateEntity().SetComponent(new ExplosionComponent()
                {
                    location = go.body.transform.position
                });

                if (e.Has<EnemyComponent>())
                {
                    e.SetComponent(new DestroyObjectComponent()
                    {
                        gameObject = go.body
                    });

                    spawner.DecreaseCount();

                    foreach (var c in enemiesCounterFilter)
                    {
                        ref var counter = ref c.GetComponent<EnemiesCounterComponent>();
                        counter.counterLbl.text = (++counter.counter).ToString();
                    }
                }
                else
                {
                    losePopup.gameObject.SetActive(true);

                    GameSettings.isPause = true;

                    World.Clear();

                    //player.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }
}