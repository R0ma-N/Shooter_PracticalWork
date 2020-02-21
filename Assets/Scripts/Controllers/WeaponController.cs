using UnityEngine;

namespace Shooter
{
    public class WeaponController : BaseController, IOnUpdate
    {
        private WeaponBase _activeWeapon;
        private Timer _timer;
        private KeyCode _fire = KeyCode.Mouse0;
        private KeyCode _reload = KeyCode.R;
        private int _index = 1;
        private Animator _playerAnimation;
        
        public WeaponController()
        {
            _activeWeapon = Inventory.Weapons[0];
            _playerAnimation = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Animator>();
            _timer = new Timer();
            //WeaponBase.GotNewWeapon.AddListener(NewWeapon);
        }

        public void OnUpdate()
        {
            


            if (Input.GetKey(_fire))
            {
                if(_activeWeapon.BulletsCount > 0)
                {
                    _activeWeapon.Fire();
                    _activeWeapon.IsReady = _timer.TimeIsUp(_activeWeapon.ShootInterval);
                }
                else return;
                _playerAnimation.SetBool("Shoot", true);
                Debug.Log("fire");
            }
            else if (Input.GetKeyUp(_fire))
            {
                _activeWeapon.IsReady = true;
                _timer.DistTime = 0;
                _playerAnimation.SetBool("Shoot", false);
                Debug.Log("STOPfire");
                if (_activeWeapon is Flamethrower)
                {
                    _activeWeapon.StopFire();
                }
            }

            float mv = Input.GetAxis("Mouse ScrollWheel");
            if (mv > 0)
            {
                Debug.Log(_index);
                if (_index < Inventory.Weapons.Length - 1)
                {
                    ChangeWeapon(_index + 1);
                    return;
                }
                
                if (_index == Inventory.Weapons.Length - 1)
                {
                    ChangeWeapon(0);
                }
            }
            
            if (mv < 0)
            {
                if (_index > 0)
                {
                    ChangeWeapon(_index - 1);
                    return;
                }

                if (_index == 0)
                {
                    ChangeWeapon(Inventory.Weapons.Length - 1);
                }
            }

            if (Input.GetKeyDown(_reload))
            {
                if (_activeWeapon.ClipsCount == 0)
                    return;
                _activeWeapon.ClipsCount--;
                _activeWeapon.BulletsCount = _activeWeapon.BulletsInClip;
            }

            UIInterface.BulletsCount.TxtBullets.text = $"{_activeWeapon.ClipsCount}/{_activeWeapon.BulletsCount}  {Inventory.Weapons.Length}";
        }

        private void ChangeWeapon(int index)
        {
            if (_activeWeapon) _activeWeapon.IsVisible(false);
            _index = index;
            _activeWeapon = Inventory.Weapons[_index];
            _activeWeapon.IsVisible(true);
        }

        private void NewWeapon()
        {
            Inventory.AddNewWeapon();
            ChangeWeapon(Inventory.Weapons.Length - 1);
            _activeWeapon.ClipsCount = _activeWeapon.ClipsMaxCount;
            _activeWeapon.BulletsCount = _activeWeapon.BulletsInClip;
        }
    }
}
