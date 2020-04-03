using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class GetFlamethrower : MonoBehaviour
    {
        private InputController _inputController;
        private WeaponController _weaponController;

        private void Awake()
        {
            _inputController = new InputController();
            _weaponController = new WeaponController();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                _inputController.isFlamethrower();
                _weaponController.ChangeWeapon(0);
                _weaponController.ActiveWeapon.IsVisible(false);
                player.GotWeaponSound();
                Destroy(this.gameObject);
            }
        }
    }
}
