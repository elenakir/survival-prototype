using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Survival.Bullets;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MouseClickSystem))]
public sealed class MouseClickSystem : UpdateSystem 
{
    private Filter filter;

    public override void OnAwake() 
    {
        filter = World.Filter.With<InputMouseClickComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var e in filter)
        {
            ref var component = ref e.GetComponent<InputMouseClickComponent>();

            var entity = World.CreateEntity();
            entity.AddComponent<BulletSpawnComponent>();

            e.RemoveComponent<InputMouseClickComponent>();
        }
    }
}