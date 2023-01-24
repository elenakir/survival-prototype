using Morpeh;
using System;
using Unity.IL2CPP.CompilerServices;

namespace Survival.Bullets
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct BulletSpawnComponent : IComponent {
    }
}