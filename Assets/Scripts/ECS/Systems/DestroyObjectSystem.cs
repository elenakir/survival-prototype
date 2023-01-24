using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DestroyObjectSystem))]
public sealed class DestroyObjectSystem : UpdateSystem 
{
    public override void OnAwake() {
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (Entity e in World.Filter.With<DestroyObjectComponent>())
        {
            ref var obj = ref e.GetComponent<DestroyObjectComponent>();

            Destroy(obj.gameObject);

            World.RemoveEntity(e);
        }
    }
}