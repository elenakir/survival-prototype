using Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Survival.Bullets
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class BulletProvider : MonoProvider<BulletComponent>
    {

    }
}