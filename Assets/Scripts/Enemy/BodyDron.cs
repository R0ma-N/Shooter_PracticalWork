using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shooter
{
    public class BodyDron : BaseObjectModel, IDamageable
    {
        public UnityEvent BodyGetDamage = new UnityEvent();
        public float Damage;
        public Material MaterialLights;

        protected override void Awake()
        {
            base.Awake();
            MaterialLights = GetComponent<MeshRenderer>().material;
        }
        
        public void getDamage(float damage)
        {
            BodyGetDamage?.Invoke();
            Damage = damage;
            print("invoke");
        }
    }
}
