using Morpeh;
using System;
using Unity.IL2CPP.CompilerServices;

namespace Survival.Stats
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct HealthComponent : IComponent
    {
        public float healthPoints;
    }
}