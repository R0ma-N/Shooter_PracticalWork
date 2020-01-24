using UnityEngine;

namespace Shooter
{
    public class InputController : BaseController, IOnUpdate
    {
        private FlashLightController _flashLightController = new FlashLightController();
        private WeaponController _weaponController = new WeaponController();

        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        public void OnUpdate()
        {
            if (Input.GetKeyDown(_activeFlashLight))
            {
                _flashLightController.Switch();
            }

            if (Input.GetKeyDown(_cancel))
            {
                _flashLightController.Off();
                _weaponController.Off();
            }
        }
    }
}
