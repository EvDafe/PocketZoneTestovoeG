using Assets.CodeBase.GameLogic.Yes;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.PlayerLogic
{
    public class PlayerMovement : ITickable
    {
        private Transform _transform;
        private float _speed;
        private Joystick _joystick;

        public PlayerMovement(Transform transform, float speed, Joystick joystick)
        {
            _transform = transform;
            _speed = speed;
            _joystick = joystick;
        }

        public void Tick(float delta)
        {
            if (CanMove())
                _transform.position += new Vector3(_joystick.Direction.x, _joystick.Direction.y) * _speed * delta;
        }

        private bool CanMove() =>
            _joystick.Direction != Vector2.zero;
    }
}
