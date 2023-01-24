using Morpeh;
using Unity.IL2CPP.CompilerServices;
using System;

namespace Survival.Stats
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct StatsComponent : IComponent
    {
        public int damage;

        public int defence;

        public int speed;
    }
}