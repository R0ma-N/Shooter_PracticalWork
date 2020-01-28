using UnityEngine;
using UnityEngine.Events;

namespace Shooter
{
    public abstract class WeaponBase : BaseObjectModel
    {
        public Ammunition Ammunition;
        public float ShootInterval;
        public bool IsReady = true;
        public int ClipsMaxCount;
        public int BulletsInClip;
        public static UnityEvent GotNewWeapon = new UnityEvent();

        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 999;
        [SerializeField] protected float _rechargeTime = 0.2f;

        [HideInInspector] public int ClipsCount;
        [HideInInspector] public int BulletsCount;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(TagManager.PLAYER))
            {
                transform.parent = Camera.main.transform;
                GotNewWeapon?.Invoke();
                Transform weaponPosition = GameObject.FindGameObjectWithTag(TagManager.WeaponPosition).transform;
                transform.position = weaponPosition.position;
                transform.rotation = weaponPosition.rotation;
                Collider.enabled = false;
            }
        }

        public abstract void Fire();
        public abstract void StopFire();
    }
}
