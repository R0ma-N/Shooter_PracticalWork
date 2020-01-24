using UnityEngine;

namespace Shooter
{
    public class PlayerController : BaseController, IOnUpdate
    {
        private GameObject _player;
        private UnitMotor _action;

        public PlayerController()
        {
            On();
            _player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            _action = new UnitMotor(_player.transform);
        }

        public void OnUpdate()
        {
            if (!IsActive) return;
            _action.Move();
        }
    }
}
