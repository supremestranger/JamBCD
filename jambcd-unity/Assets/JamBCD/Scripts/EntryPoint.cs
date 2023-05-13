using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace JamBCD
{
    sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Configuration Config;
        [SerializeField] private SceneData SceneData;
        
        private EcsWorld _world;
        private EcsSystems _systems;


        void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            var cs = new CameraService(Camera.main);
            var rd = new RuntimeData();
            Application.targetFrameRate = 144; // remove this
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .OneFrame<TryDrink>()
                .Add(new PlayerAnalyzeInputSystem())
                .Add(new PlayerGroundCheckSystem())
                .Add(new CameraLookRotationSystem())
                .Add(new PlayerStandingMoveSystem())
                .Add(new PlayerAirMoveSystem())
                .Add(new PlayerApplyMoveSystem())
                .Add(new PlayerDashingSystem())
                .Add(new PlayerJumpSystem())
                .Add(new PlayerChangeHeightSystem())
                .Add(new DrunkCameraShakeSystem())
                .Add(new PickUpBuffSystem())
                .OneFrame<PickedUpBuff>()
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(Config)
                .Inject(SceneData)
                .Inject(rd)
                .Inject(cs)
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}