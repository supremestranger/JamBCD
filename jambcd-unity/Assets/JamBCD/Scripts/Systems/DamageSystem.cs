using Leopotam.Ecs;

namespace JamBCD
{
    sealed class DamageSystem : IEcsRunSystem
    {
        private EcsFilter<Health, DamageEvent> _events;
        
        public void Run()
        {
            foreach (var i in _events)
            {
                ref var hp = ref _events.Get1(i);
                ref var dmg = ref _events.Get2(i);

                hp.Value -= dmg.Value;
            }
        }
    }
}