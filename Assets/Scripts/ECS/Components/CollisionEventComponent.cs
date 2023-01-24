using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using System;

namespace Survival.Collisions
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct CollisionEventComponent : IComponent
    {
        public Collision collision;
        public Entity first;
        public Entity second;
    }
}