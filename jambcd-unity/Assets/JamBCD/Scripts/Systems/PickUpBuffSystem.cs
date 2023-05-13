using Leopotam.Ecs;

namespace JamBCD
{
    public class PickUpBuffSystem : IEcsRunSystem
    {
        private EcsFilter<PickedUpBuff> _events;
        private RuntimeData _runtimeData;

        public void Run()
        {
            foreach (var i in _events)
            {
                _runtimeData.BuffCount++;
                // todo update ui
            }
        }
    }
}