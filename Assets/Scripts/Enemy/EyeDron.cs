using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shooter
{
    public class EyeDron : BaseObjectModel, IDamageable
    {
        public Light Light;
        public UnityEvent EyeGetDamage = new UnityEvent();
        public float Damage;

        override protected void Awake()
        {
            base.Awake();
            Light = GetComponent<Light>();
        }

        public void getDamage(float damage)
        {
            EyeGetDamage?.Invoke();
            Damage = damage;
        }
    }
}
