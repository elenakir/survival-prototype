using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;
using Survival.Stats;

namespace Survival.Player.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerMovementSystem))]
    public sealed class PlayerMovementSystem : UpdateSystem
    {
        private Filter filter;

        [Inject] private Player player;

        public override void OnAwake()
        {
            filter = World.Filter.With<PlayerMovementComponent>().With<HealthComponent>().With<StatsComponent>(); ;
        }

        public override void OnUpdate(float deltaTime)
        {
            if (!GameSettings.isPause)
            {
                foreach (var e in filter)
                {
                    ref var component = ref e.GetComponent<PlayerMovementComponent>();

                    float moveHorizontal = Input.GetAxis("Horizontal");
                    float moveVertical = Input.GetAxis("Vertical");

                    Vector3 movement = new(moveHorizontal * Time.deltaTime, 0.0f, moveVertical * Time.deltaTime);

                    ref var stats = ref e.GetComponent<StatsComponent>();
                    player.SetPosition(movement, stats.speed);
                }
            }
        }
    }
}