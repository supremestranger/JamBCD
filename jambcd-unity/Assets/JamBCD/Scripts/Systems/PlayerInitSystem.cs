using Leopotam.Ecs;

namespace JamBCD
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private Configuration _config;
        private SceneData _sceneData;
        private EcsWorld _world;
        private RuntimeData _runtimeData;
        private CameraService _cameraService;
        
        public void Init()
        {
            var playerEntity = _world.NewEntity();
            
            ref var player = ref playerEntity.Get<Player>();
            ref var inputControl = ref playerEntity.Get<InputControl>();

            //runtimeData.playerTransform = sceneData.playerGameObject.transform;
            //runtimeData.playerEntity = playerEntity;
            
            player.PlayerView = _sceneData.PlayerView;
            player.PlayerView.World = _world;
            _cameraService.CameraZRot = _config.CameraZRot;
            //player.bunnyHoopInterval = staticData.bunnyHoopInterval;
            //player.baseMaxSpeedOnGround = config.BaseSpeedOnGround;
            player.CurrentMaxSpeedOnGround = _config.BaseSpeedOnGround;
            //player.SlowAirAcceleration = staticData.slowAirAcceleration;
            //player.baseAirAcceleration = staticData.baseAirAcceleration;
            //player.baseMaxSpeedInAir = config.baseMaxSpeedInAir;
            player.CurrentAirAcceleration = _config.AirAcceleration;
            player.DashSpeed = _config.DashSpeed;
            player.CurrentMaxSpeedInAir = _config.MaxSpeedInAir;
            player.GravitationalAcceleration = _config.GravitationalAcceleration;
            player.JumpHeight = _config.JumpHeight;
            player.GroundAcceleration = _config.GroundAcceleration;
            player.TargetFOV = 60f;
        }
    }
}