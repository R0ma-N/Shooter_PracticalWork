using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class EnemyController 
    {
        private Enemy _enemy = new Enemy();
        private Firearms weapon = new Firearms();

        public void getDamage(float damage)
        {
            //_enemy.Health -= damage;
            //_enemy._eyeLight.enabled = true;

            //if (Health <= 0)
            //{
            //    OnDeath();
            //}
        }

        private void Fire()
        {
            //var tempAmmunation = Instantiate(_enemy.Ammunition, _barrel.position, _barrel.rotation);
            //tempAmmunation.AddForce(_barrel.forward * _force);
        }
    }
}
