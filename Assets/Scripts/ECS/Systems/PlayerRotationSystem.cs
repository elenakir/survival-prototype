using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;
using Survival.Player;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerRotationSystem))]
public sealed class PlayerRotationSystem : UpdateSystem 
{
    [Inject] private Player player;

    public override void OnAwake() { }

    public override void OnUpdate(float deltaTime) 
    {
        player.SetRotation();
    }
}