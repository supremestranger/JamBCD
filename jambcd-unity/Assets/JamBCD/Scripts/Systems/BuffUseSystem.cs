using Leopotam.Ecs;
using UnityEngine;

namespace JamBCD
{
    public class BuffUseSystem : IEcsRunSystem
    {
        private EcsFilter<TryDrink> _events;
        private RuntimeData _runtimeData;
        private CameraService _cameraService;
        
        private float _drunk;
        private const float FrequencyRatio = 0.75f; // во сколько раз частота меньше амплитуды

        public void Run()
        {
            if (!_events.IsEmpty() && _runtimeData.BuffCount > 0)
            {
                _runtimeData.BuffCount--;
                foreach (var i in _events)
                {
                    ref var e = ref _events.GetEntity(i).Get<ApplyBuff>();
                    e.RandomValue = Random.Range(0, 101);
                }
                _drunk += 5f;
            }
            
            if (_drunk <= 0f)
            {
                _drunk = 0f;
                _cameraService.CinemachineNoise.m_AmplitudeGain = 0f;
                _cameraService.CinemachineNoise.m_FrequencyGain = 0f;
                return;
            }

            _cameraService.CinemachineNoise.m_AmplitudeGain = _drunk;
            _cameraService.CinemachineNoise.m_FrequencyGain = _drunk * FrequencyRatio;
            _drunk -= Time.deltaTime;
        }

    }
}