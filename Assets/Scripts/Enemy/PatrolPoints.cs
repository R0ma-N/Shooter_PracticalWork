using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class PatrolPoints : MonoBehaviour
    {
        public Transform[] points;

        private void Awake()
        {
            points = GetComponentsInChildren<Transform>();
        }
    }
}
