using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class EnemyController : BaseController, IOnUpdate, IOnInitialize
    {
        public Enemy _dron;
        private Transform _target;
        private EnemyStates _state = new EnemyStates();

        public void OnStart()
        {
            _dron = GameObject.FindObjectOfType<Enemy>();
            _target = GameObject.FindObjectOfType<CharacterController>().transform;
            _dron.Eye.EyeGetDamage.AddListener(Death);
            _dron.Body.BodyGetDamage.AddListener(GetDamage);
            _dron.Rigidbody.isKinematic = true;
            _dron.Explotion.Stop();
            Debug.Log("EnemyControl");
            _state.Patrol(_dron);
        }

        public void OnUpdate()
        {
            if (_dron)
            {
                //Debug.Log("dron");
                //_dron.Agent.SetDestination(_target.position);
                //_dron.Weapon.Fire();
                //_state.Patrol();
            //_state.Patrol(_dron);
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
            _dron.Eye.Light.enabled = false;
            _dron.Agent.enabled = false;
            _dron.Rigidbody.isKinematic = false;
            _dron.Body.Rigidbody.isKinematic = false;
            _dron.Explotion.Play();
            _dron.Destroy(2);
        }
    }
}
