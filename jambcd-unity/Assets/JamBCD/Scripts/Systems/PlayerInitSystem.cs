using Leopotam.Ecs;

namespace JamBCD
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private Configuration config;
        private SceneData sceneData;
        private EcsWorld ecsWorld;
        private RuntimeData runtimeData;
        private CameraService _cameraService;
        
        public void Init()
        {
            var playerEntity = ecsWorld.NewEntity();
            
            ref var player = ref playerEntity.Get<Player>();
            ref var inputControl = ref playerEntity.Get<InputControl>();

            //runtimeData.playerTransform = sceneData.playerGameObject.transform;
            //runtimeData.playerEntity = playerEntity;
            
            player.PlayerView = sceneData.PlayerGO.GetComponent<PlayerView>();
            player.MouseSensitivity = config.MouseSensitivity;
            _cameraService.CameraZRot = config.CameraZRot;
            //player.bunnyHoopInterval = staticData.bunnyHoopInterval;
            //player.baseMaxSpeedOnGround = config.BaseSpeedOnGround;
            player.CurrentMaxSpeedOnGround = config.BaseSpeedOnGround;
            //player.SlowAirAcceleration = staticData.slowAirAcceleration;
            //player.baseAirAcceleration = staticData.baseAirAcceleration;
            //player.baseMaxSpeedInAir = config.baseMaxSpeedInAir;
            player.CurrentAirAcceleration = config.AirAcceleration;
            player.DashSpeed = config.DashSpeed;
            player.CurrentMaxSpeedInAir = config.MaxSpeedInAir;
            player.GravitationalAcceleration = config.GravitationalAcceleration;
            player.JumpHeight = config.JumpHeight;
            player.GroundAcceleration = config.GroundAcceleration;
            player.TargetFOV = 60f;
        }
    }
}