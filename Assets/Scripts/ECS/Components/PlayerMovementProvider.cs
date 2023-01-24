using Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Survival.Player.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PlayerMovementProvider : MonoProvider<PlayerMovementComponent>
    {
    }
}