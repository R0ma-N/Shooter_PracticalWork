using UnityEngine;

namespace Shooter
{
    public class EnemyController : BaseController, IOnUpdate, IOnInitialize
    {
        public Enemy _dron;
        private Transform _player;
        private EnemyStates _state = new EnemyStates();
        private ZoneOfDetect _zoneOfDetect;
        private bool _playerDetected;

        public void OnStart()
        {
            _dron = GameObject.FindObjectOfType<Enemy>();
            _player = GameObject.FindObjectOfType<CharacterController>().transform;
            _zoneOfDetect = GameObject.FindObjectOfType<ZoneOfDetect>();
            _dron.Eye.EyeGetDamage.AddListener(Death);
            _dron.Body.BodyGetDamage.AddListener(GetDamage);
            _dron.Explotion.Stop();
        }

        public void OnUpdate()
        {
            if (!_dron) return;

            _playerDetected = _zoneOfDetect.PlayerDetected;
            _state.Patrol(_dron);

            if (_playerDetected)
            {
                _state.Attack(_dron, _player);
            }
        }
        
        private void GetDamage()
        {
            _dron.Health -= _dron.Body.Damage;
            if(_dron.Health <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            _dron.Eye.EyeGetDamage.RemoveAllListeners();
            _dron.Body.BodyGetDamage.RemoveAllListeners();
            _dron.Destroy(2);
        }
    }
}
