using Morpeh;
using System;
using TMPro;
using Unity.IL2CPP.CompilerServices;

namespace Survival.Enemy
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct EnemiesCounterComponent : IComponent
    {
        public TextMeshProUGUI counterLbl;

        public int counter;
    }
}