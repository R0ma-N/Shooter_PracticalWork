using UnityEngine;

namespace Shooter
{
    public class EnemyController : BaseController, IOnUpdate, IOnInitialize
    {
        public Enemy[] _drons;
        private Transform _player;
        private Player _playerScript;
        private EnemyStates _state = new EnemyStates();
        private ZoneOfDetect _zoneOfDetect;

        public void OnStart()
        {
            //_dron = GameObject.FindObjectOfType<Enemy>();
            _drons = GameObject.FindObjectsOfType<Enemy>();
            _player = GameObject.FindObjectOfType<Player>().CellForEnemy;
            _playerScript = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
            //_playerScript.Death.AddListener(OnPlayersDeath);

            IsActive = true;
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
            //if (!IsActive) return;

            //if (_drons.Length > 0)
            //{
            //    for (int i = 0; i < _drons.Length; i++)
            //    {
            //        if (!_drons[i].IsDead)
            //        {
            //            _drons[i].Patrol();

            //            if (_drons[i].PlayerDetected && _player)
            //            {
            //                _drons[i].Attack(_player);
            //            }
            //            else return;

            //            _drons[i].GotoNextPoint();
            //        }
            //    }
            }

            //if (!_drons) return;

            //_playerDetected = _zoneOfDetect.PlayerDetected;
            //_state.Patrol(_dron);

            //if (_playerDetected)
            //{
            //    _state.Attack(_dron, _player);
            //}
        //}

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

        //private void OnPlayersDeath()
        //{
        //    //_player = null;
        //    //_playerScript.Death.RemoveListener(OnPlayersDeath);
        //}
    }

}
