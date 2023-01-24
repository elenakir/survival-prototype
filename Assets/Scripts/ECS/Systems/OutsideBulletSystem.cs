using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Survival.Bullets;
using Survival.Player;
using Zenject;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OutsideBulletSystem))]
public sealed class OutsideBulletSystem : UpdateSystem 
{
    private Filter bulletFilter;

    [Inject] private Player player;

    public override void OnAwake() { }

    public override void OnUpdate(float deltaTime) 
    {
        var filter = World.Filter.With<BulletComponent>();

        foreach (var e in filter)
        {
            ref var bullet = ref e.GetComponent<BulletComponent>();

            if (Vector3.Distance(player.transform.position, bullet.body.transform.position) > 20)
            {
                e.SetComponent(new DestroyObjectComponent()
                {
                    gameObject = bullet.body
                });
            }

        }
    }
}