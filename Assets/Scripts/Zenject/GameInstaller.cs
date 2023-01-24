using UnityEngine;
using Zenject;
using Survival.Player;
using Survival.Enemy;
using Survival.Effects;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    [SerializeField] private Player player;

    [SerializeField] private BulletSpawner bullets;

    [SerializeField] private EnemySpawner enemies;

    [SerializeField] private EnemiesConfig enemiesConfig;

    [SerializeField] private LosePopup losePopup;

    [SerializeField] private ExplosionSpawner explosions;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(player).AsSingle();
        Container.Bind<BulletSpawner>().FromInstance(bullets).AsSingle();
        Container.Bind<EnemySpawner>().FromInstance(enemies).AsSingle();
        Container.Bind<EnemiesConfig>().FromInstance(enemiesConfig).AsSingle();
        Container.Bind<LosePopup>().FromInstance(losePopup).AsSingle();
        Container.Bind<ExplosionSpawner>().FromInstance(explosions).AsSingle();
    }
}