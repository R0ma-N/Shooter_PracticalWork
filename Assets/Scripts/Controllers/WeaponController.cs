using UnityEngine;
using UnityEngine.Events;

namespace Shooter
{
    public class WeaponController :  BaseController, IOnUpdate
    {
        public WeaponBase ActiveWeapon;
        public UnityEvent WeaponChanged = new UnityEvent();
        public bool IsArmed;
        private Timer _timer;
        private int _index = 1;
        private KeyCode _fire = KeyCode.Mouse0;
        private KeyCode _reload = KeyCode.R;
        private MenuGamePause _pauseMenu;
        private float MouseScrollWheelValue;

        public WeaponController()
        {
            ActiveWeapon = Inventory.Weapons[1];
            _timer = new Timer();
            ///ActiveWeapon.IsVisible(false);
            _pauseMenu = GameObject.FindObjectOfType<MenuGamePause>();
            IsActive = true;
            _pauseMenu.PressedClose.AddListener(Switch);
            IsArmed = false;
        }

        public void OnUpdate()
        {
            if (IsActive)
            {
                if (IsArmed)
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

                    if (Input.GetKeyDown(_reload))
                    {
                        if (ActiveWeapon.ClipsCount == 0)
                            return;
                        ActiveWeapon.ClipsCount--;
                        ActiveWeapon.BulletsCount = ActiveWeapon.BulletsInClip;
                    }

                    MouseScrollWheelValue = Input.GetAxis("Mouse ScrollWheel");
                    if (MouseScrollWheelValue > 0)
                    {
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
            
                    if (MouseScrollWheelValue < 0)
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
                }
                else
                {
                    MouseScrollWheelValue = Input.GetAxis("Mouse ScrollWheel");
                    if (MouseScrollWheelValue > 0)
                    {
                        if (_index < Inventory.Weapons.Length - 1)
                        {
                            ChangeWeaponInvisible(_index + 1);
                            return;
                        }

                        if (_index == Inventory.Weapons.Length - 1)
                        {
                            ChangeWeaponInvisible(0);
                        }
                    }

                    if (MouseScrollWheelValue < 0)
                    {
                        if (_index > 0)
                        {
                            ChangeWeaponInvisible(_index - 1);
                            return;
                        }

                        if (_index == 0)
                        {
                            ChangeWeaponInvisible(Inventory.Weapons.Length - 1);
                        }
                    }
                }
            }

            UIInterface.BulletsCount.TxtBullets.text = $"{ActiveWeapon.ClipsCount}/{ActiveWeapon.BulletsCount}";

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Switch();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                IsArmed = true;
                foreach (var weapon in Inventory.Weapons)
                {
                    weapon.IsVisible(false);
                }
                
                ActiveWeapon.IsVisible(true);
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                IsArmed = false;
            }
        }

        private void ChangeWeapon(int index)
        {
            if (ActiveWeapon) ActiveWeapon.IsVisible(false);
            UIInterface.BulletsCount.Images[_index].enabled = false;
            _index = index;
            UIInterface.BulletsCount.Images[_index].enabled = true;
            ActiveWeapon = Inventory.Weapons[_index];
            ActiveWeapon.IsVisible(true);
            WeaponChanged?.Invoke();
            Debug.Log(ActiveWeapon);
        }

        private void ChangeWeaponInvisible(int index)
        {
            UIInterface.BulletsCount.Images[_index].enabled = false;
            _index = index;
            UIInterface.BulletsCount.Images[_index].enabled = true;
            ActiveWeapon = Inventory.Weapons[_index];
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
