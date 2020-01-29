using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class EnemyStates
    {
        public Transform[] _patrolPoints;
        public Enemy _enemy;
        

        public EnemyStates()
        {
            _patrolPoints = Object.FindObjectOfType<PatrolPoints>().points;
            _enemy = GameObject.FindObjectOfType<Enemy>();
            Debug.Log(_patrolPoints[0].position);
            Debug.Log(_enemy.transform.position);
            Ray ray = new Ray(_enemy.transform.position, _enemy.transform.forward);
        }

        public void Patrol(Enemy enemy)
        {
            Debug.Log("void");
            Debug.DrawLine(_enemy.transform.position, _enemy.transform.forward);
            enemy.Agent.SetDestination(_patrolPoints[1].position);
            //if (enemy.Collider)
            //{
            //    enemy.Agent.SetDestination(_patrolPoints[2].position);
            //}
            enemy.Eye.Light.color = Color.green;
        }
    }
}
