using UnityEngine;

namespace Shooter
{
    public class InputController : BaseController, IOnUpdate
    {
        private FlashLightController _flashLightController = new FlashLightController();
        private WeaponController _weaponController = new WeaponController();
        private SaveDataRepository _saveDataRepository = new SaveDataRepository();
        private Animator _playerAnimation;

        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _save = KeyCode.C;
        private KeyCode _load = KeyCode.V;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _playerAnimation = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Animator>();
        }
        
        public void OnUpdate()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _playerAnimation.SetBool("forward", true);
                return;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                _playerAnimation.SetBool("forward", false);
            }
            
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
                _saveDataRepository.Save();
            }

            if (Input.GetKeyDown(_load))
            {
                _saveDataRepository.Load();
            }


        }
    }
}
