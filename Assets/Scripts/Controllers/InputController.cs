using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

namespace Shooter
{
    public class InputController : BaseController, IOnUpdate
    {
        private PostProcessProfile _pprofile;
        private FlashLightController _flashLightController = new FlashLightController();
        private WeaponController _weaponController = new WeaponController();
        private PlayerController _playerController = new PlayerController();
        private PauseScreen _pauseScreen;
        private SaveDataRepository _saveDataRepository = new SaveDataRepository();
        private CellPoint _cellPointUI;
        private Animator _playerAnimation;
        private Animator _camera;
        private PanelManager _panelManager;
        private Transform _player;
        private float sensitivity = 4;
        private bool _isPaused;

        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _save = KeyCode.C;
        private KeyCode _load = KeyCode.V;

        private KeyCode _left = KeyCode.A;
        private KeyCode _right = KeyCode.D;

        float rotationX = 0;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _playerAnimation = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Animator>();
            _camera = Camera.main.GetComponent<Animator>();
            _player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Transform>();
            _panelManager = GameObject.FindObjectOfType<PanelManager>();
            _cellPointUI = GameObject.FindObjectOfType<CellPoint>();
            _pauseScreen = GameObject.FindObjectOfType<PauseScreen>();
            _pprofile = GameObject.FindObjectOfType<ColorGraddingTrigger>().pprofile;
            IsActive = true;
        }
        
        public void OnUpdate()
        {
            if (IsActive)
            {

                if (Input.GetKeyDown(KeyCode.W))
                {
                    _playerAnimation.SetBool("forward", true);
                }
                else if (Input.GetKeyUp(KeyCode.W))
                {
                    _playerAnimation.SetBool("forward", false);
                }

                if (Input.GetKeyDown(_left))
                {
                    _playerAnimation.SetBool("Move Left", true);
                }
                else if (Input.GetKeyUp(_left))
                {
                    _playerAnimation.SetBool("Move Left", false);
                }

                if (Input.GetKeyDown(_right))
                {
                    _playerAnimation.SetBool("Move Right", true);
                }
                else if (Input.GetKeyUp(_right))
                {
                    _playerAnimation.SetBool("Move Right", false);
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    _camera.SetBool("IsShooting", true);
                    _playerAnimation.SetBool("Aiming", true);
                    _playerController.Aiming(true);
                    _weaponController._activeWeapon.IsVisible(true);
                }
                else if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    _camera.SetBool("IsShooting", false);
                    _playerAnimation.SetBool("Aiming", false);
                    _playerController.Aiming(false);
                    _weaponController._activeWeapon.IsVisible(false);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _playerAnimation.SetTrigger("Jump");
                }

                float yRot = Input.GetAxis("Mouse X") * sensitivity;
                float xRot = Input.GetAxis("Mouse Y") * sensitivity;
                _player.localRotation *= Quaternion.Euler(0f, yRot, 0f);

                rotationX += xRot;
                rotationX = Mathf.Clamp(rotationX, -30, 20);
                Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);


                if (Input.GetKeyDown(_activeFlashLight))
                {
                    _flashLightController.Switch();
                    bool isOn = _flashLightController._flashLight.IsOn;
                    _playerAnimation.SetBool("HandLightOn", isOn);
                    _camera.SetBool("IsShooting", isOn);
                    _playerController.Lighting(isOn);
                    Debug.Log(isOn);
                }
            }

            if (Input.GetKeyDown(_cancel))
            {
                _flashLightController.Off();
                
                Switch();
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

        private new void Switch()
        {
            if (!_isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                _panelManager.OpenPanel(_panelManager.Audio);
                Time.timeScale = 0;
                _isPaused = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                _panelManager.CloseCurrent();
                Time.timeScale = 1;
                _isPaused = false;
            }

            _pauseScreen.MakeDarkScreen(_isPaused);
            base.Switch();
        }

    }
}
