using Morpeh;
using System;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.UI;

namespace Survival.Stats
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct HealthLineComponent : IComponent
    {
        public Image healthLine;
    }
}