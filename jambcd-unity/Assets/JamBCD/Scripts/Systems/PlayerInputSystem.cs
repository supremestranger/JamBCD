using Leopotam.Ecs;
using UnityEngine;

namespace JamBCD {
    public class PlayerInputSystem : IEcsRunSystem {
        private EcsFilter<Player> _players;

        public void Run() {
            foreach (var i in _players) {
                ref var player = ref _players.Get1(i);

                player.MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, (Input.GetAxisRaw("Vertical")));
                player.WantCrouch = Input.GetKey(KeyCode.LeftControl);
                player.WantSlide = Input.GetKeyDown(KeyCode.LeftAlt);
                player.FireInputDown = Input.GetMouseButtonDown(0);
                player.WantJump = Input.GetKeyDown(KeyCode.Space);
                player.WantDash = Input.GetKeyDown(KeyCode.LeftShift);
                player.MouseX = Input.GetAxis("Mouse X");
                player.MouseY = Input.GetAxis("Mouse Y");
            }
        }
    }
}