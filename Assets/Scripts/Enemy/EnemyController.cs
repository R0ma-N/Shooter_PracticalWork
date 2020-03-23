using UnityEngine;

namespace Shooter
{
    public class EnemyController : BaseController, IOnUpdate, IOnInitialize
    {
        //public Enemy _dron = null;
        public Enemy[] _drons;
        private Transform _player;
        private EnemyStates _state = new EnemyStates();
        private ZoneOfDetect _zoneOfDetect;
        private bool _playerDetected;

        public void OnStart()
        {
            //_dron = GameObject.FindObjectOfType<Enemy>();
            _drons = GameObject.FindObjectsOfType<Enemy>();
            _player = GameObject.FindObjectOfType<Player>().CellForEnemy;
            //_zoneOfDetect = GameObject.FindObjectOfType<ZoneOfDetect>();
            //_dron.Eye.EyeGetDamage.AddListener(Death);
            //_dron.Body.BodyGetDamage.AddListener(GetDamage);
            //_dron.Explotion.Stop();
            //for (int i = 0; i < _drons.Length; i++)
            //{
            //    _drons[i].Eye.EyeGetDamage.AddListener(Death);
            //    _drons[i].Body.BodyGetDamage.AddListener(GetDamage);
            //    _drons[i].Explotion.Stop();
            //}
        }

        public void OnUpdate()
        {
            if(_drons.Length > 0)
            {
                for (int i = 0; i < _drons.Length; i++)
                {
                    _drons[i].State.Patrol(_drons[i]);

                    if (_drons[i].PlayerDetected)
                    {
                        _drons[i].State.Attack(_drons[i], _player);
                    }
                }
            }
            
            //if (!_drons) return;

            //_playerDetected = _zoneOfDetect.PlayerDetected;
            //_state.Patrol(_dron);

            //if (_playerDetected)
            //{
            //    _state.Attack(_dron, _player);
            //}
        }
        
        //private void GetDamage()
        //{
        //    _drons.Health -= _dron.Body.Damage;
        //    if(_dron.Health <= 0)
        //    {
        //        Death();
        //    }
        //}

        //private void Death()
        //{
        //    _dron.Eye.EyeGetDamage.RemoveAllListeners();
        //    _dron.Body.BodyGetDamage.RemoveAllListeners();
        //    _dron.Destroy(2);
        //}
    }
}
