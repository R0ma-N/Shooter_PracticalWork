using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class EnemyHealthUI : MonoBehaviour
    {
        public TextMesh HealthValueUI;

        void Start()
        {
            HealthValueUI = GetComponentInChildren<TextMesh>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}
