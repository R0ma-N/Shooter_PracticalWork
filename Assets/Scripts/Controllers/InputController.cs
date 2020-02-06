using UnityEngine;

namespace Shooter
{
    public class InputController : BaseController, IOnUpdate
    {
        private FlashLightController _flashLightController = new FlashLightController();
        private WeaponController _weaponController = new WeaponController();
        private SaveDataRepository _saveData = new SaveDataRepository();

        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _save = KeyCode.C;
        private KeyCode _load = KeyCode.V;

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

            if (Input.GetKeyDown(_save))
            {
                _saveData.Save();
            }

            if (Input.GetKeyDown(_load))
            {
                _saveData.Load();
            }
        }
    }
}
