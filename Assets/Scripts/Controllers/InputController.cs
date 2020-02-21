using UnityEngine;

namespace Shooter
{
    public class InputController : BaseController, IOnUpdate
    {
        private FlashLightController _flashLightController = new FlashLightController();
        private WeaponController _weaponController = new WeaponController();
        private SaveDataRepository _saveDataRepository = new SaveDataRepository();
        private Animator _playerAnimation;
        private Animator _camera;
        private Transform _player;
        private float sensitivity = 4;

        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _save = KeyCode.C;
        private KeyCode _load = KeyCode.V;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _playerAnimation = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Animator>();
            _camera = Camera.main.GetComponent<Animator>();
            _player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Transform>();
        }
        
        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _playerAnimation.SetBool("forward", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                _playerAnimation.SetBool("forward", false);
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _camera.SetBool("IsShooting", true);
                Debug.Log("On");
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                _camera.SetBool("IsShooting", false);
                Debug.Log("Off");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("OKKK");
                _playerAnimation.SetTrigger("Jump");
            }

            float yRot = Input.GetAxis("Mouse X") * sensitivity;
            _player.localRotation *= Quaternion.Euler(0f, yRot, 0f);


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
