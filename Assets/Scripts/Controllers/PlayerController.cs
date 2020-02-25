using UnityEngine;

namespace Shooter
{
    public class PlayerController : BaseController, IOnUpdate
    {
        private GameObject _player;
        private Animator _animator;
        private bool _aiming;
        private Player _playerModel;

        public PlayerController()
        {
            On();
            _player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            _playerModel = _player.GetComponent<Player>();
        }

        public void Aiming(bool state)
        {
            _playerModel.ikActive = state;
        }

        public void Move(Direction move)
        {
            if(move == Direction.Left)
            {
                _animator.SetBool("Move Left", true);
            }
        }
        
        public void OnUpdate()
        {
            if (!IsActive) return;
            //_action.Move();
        }
    }

    public enum Direction
    {
        Left = 1,
        Right,
        Forward,
        Back
    }
}
