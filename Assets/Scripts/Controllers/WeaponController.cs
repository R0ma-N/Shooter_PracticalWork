using UnityEngine;
using UnityEngine.Events;

namespace Shooter
{
    public class WeaponController :  BaseController, IOnUpdate
    {
        public WeaponBase ActiveWeapon;
        public UnityEvent WeaponChanged = new UnityEvent();
        private Timer _timer;
        private int _index = 0;
        private KeyCode _fire = KeyCode.Mouse0;
        private KeyCode _reload = KeyCode.R;
        private MenuGamePause _pauseMenu;

        public WeaponController()
        {
            ActiveWeapon = Inventory.Weapons[0];
            _timer = new Timer();
            ActiveWeapon.IsVisible(false);
            _pauseMenu = GameObject.FindObjectOfType<MenuGamePause>();
            IsActive = true;
            _pauseMenu.PressedClose.AddListener(Switch);
        }

        public void OnUpdate()
        {
            if (IsActive)
            {
                if (Input.GetKey(_fire))
                {
                    if(ActiveWeapon.BulletsCount > 0)
                    {
                        ActiveWeapon.Fire();
                        ActiveWeapon.IsReady = _timer.TimeIsUp(ActiveWeapon.ShootInterval);
                    }
                    else return;
                    Debug.Log("fire");
                }
                else if (Input.GetKeyUp(_fire))
                {
                    ActiveWeapon.IsReady = true;
                    _timer.DistTime = 0;
                    Debug.Log("STOPfire");
                    if (ActiveWeapon is Flamethrower)
                    {
                        ActiveWeapon.StopFire();
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
                    if (ActiveWeapon.ClipsCount == 0)
                        return;
                    ActiveWeapon.ClipsCount--;
                    ActiveWeapon.BulletsCount = ActiveWeapon.BulletsInClip;
                }

                UIInterface.BulletsCount.TxtBullets.text = $"{ActiveWeapon.ClipsCount}/{ActiveWeapon.BulletsCount}  {Inventory.Weapons.Length}";
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Switch();
            }
        }

        private void ChangeWeapon(int index)
        {
            if (ActiveWeapon) ActiveWeapon.IsVisible(false);
            _index = index - 1;
            ActiveWeapon = Inventory.Weapons[_index];
            ActiveWeapon.IsVisible(true);
            WeaponChanged?.Invoke();
            Debug.Log(ActiveWeapon);
        }

        private void NewWeapon()
        {
            Inventory.AddNewWeapon();
            ChangeWeapon(Inventory.Weapons.Length - 1);
            ActiveWeapon.ClipsCount = ActiveWeapon.ClipsMaxCount;
            ActiveWeapon.BulletsCount = ActiveWeapon.BulletsInClip;
        }
    }
}
