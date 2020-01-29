using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class PatrolPoints : MonoBehaviour
    {
        public Transform[] Points;

        private void Awake()
        {
            Points = GetComponentsInChildren<Transform>();
            Debug.Log(Points.Length);
        }
    }
}
