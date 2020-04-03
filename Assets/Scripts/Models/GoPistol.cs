using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class GoPistol : MonoBehaviour
    {
        public BulletsCount WeaponCanvas;

        private void Awake()
        {
            WeaponCanvas = GameObject.FindObjectOfType<BulletsCount>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                WeaponCanvas.OnEnable();
                player.GotWeaponSound();
                Destroy(this.gameObject);
            }
        }
    }
}
