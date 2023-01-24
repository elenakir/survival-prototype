using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

namespace Survival.Player
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(PlayerInitializer))]
    public class PlayerInitializer : Initializer
    {
        public override void OnAwake()
        {
            var e = World.CreateEntity();
        }
    }
}
