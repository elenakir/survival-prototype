using System;
using Morpeh;

namespace Survival.Collisions
{
    [Serializable]
    public struct CanCollideComponent : IComponent
    {
        public CollisionDetector detector;
    }
}