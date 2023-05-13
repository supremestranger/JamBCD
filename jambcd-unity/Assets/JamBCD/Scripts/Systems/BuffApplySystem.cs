using Leopotam.Ecs;

namespace JamBCD
{
    sealed class BuffApplySystem : IEcsRunSystem
    {
        private EcsFilter<ApplyBuff> _events;
        
        public void Run()
        {
            foreach (var i in _events)
            {
                ref var e = ref _events.Get1(i);
                switch (e.RandomValue)
                {
                    case <= 30 and > 0:
                        break;
                    case <= 50 and > 30:
                        break;
                    case <= 70 and > 50:
                        break;
                    case <= 90 and > 70:
                        break;
                    case > 90:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}