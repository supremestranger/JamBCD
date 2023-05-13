using Leopotam.Ecs;

namespace JamBCD
{
    public class DrunkCameraShakeSystem : IEcsRunSystem
    {
        private EcsFilter<Drunk> _drunk;
        private CameraService _cameraService;
        
        public void Run()
        {
            
        }
    }
}