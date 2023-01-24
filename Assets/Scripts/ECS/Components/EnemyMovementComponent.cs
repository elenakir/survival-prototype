using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using System;

namespace Survival.Enemy
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct EnemyMovementComponent : IComponent
    {
        public Transform enemyTransform;
    }
}