using Features.Player.StatsData.Components;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Features.Player.Attack.View
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/AttackRangeViewUpdate", fileName = "AttackRangeViewUpdate")]
    public class AttackRangeViewUpdateSystem : UpdateSystem
    {
        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            var filter = World.Filter
                .With<AttackRangeViewComponent>()
                .With<AttackStatsComponent>();

            foreach (var player in filter)
            {
                ref var view = ref player.GetComponent<AttackRangeViewComponent>();
                ref var stats = ref player.GetComponent<AttackStatsComponent>();

                view.RangeView.SetRange(stats.Stats.AttackRadius);
            }
        }
    }
}