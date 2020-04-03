using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

namespace Shooter
{
    public class InputController : BaseController, IOnUpdate, IOnInitialize
    {
        private PostProcessProfile _pprofile;
        private FlashLightController _flashLightController = new FlashLightController();
        private WeaponController _weaponController = new WeaponController();
        private PlayerController _playerController = new PlayerController();
        private Player _playerScript;
        private PauseScreen _pauseScreen;
        private SaveDataRepository _saveDataRepository = new SaveDataRepository();
        private CellPoint _cellPointUI;
        private Animator _playerAnimation;
        private Animator _camera;
        private Timer _timer;
        private PanelManager _panelManager;
        private Transform _player;
        private MenuGamePause _pauseMenu;
        private float sensitivity = 4;
        private bool _isPaused;
        private bool _isFlameThrower;
        private bool _playerIsDead = false;

        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _kneeling = KeyCode.LeftControl;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _save = KeyCode.C;
        private KeyCode _load = KeyCode.V;

        float rotationX = 0;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _timer = new Timer();
            _playerAnimation = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Animator>();
            _camera = Camera.main.GetComponent<Animator>();
            _player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Transform>();
            _playerScript = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Player>();
            _panelManager = GameObject.FindObjectOfType<PanelManager>();
            _cellPointUI = GameObject.FindObjectOfType<CellPoint>();
            _pauseScreen = GameObject.FindObjectOfType<PauseScreen>();
            _pprofile = GameObject.FindObjectOfType<ColorGraddingTrigger>().pprofile;
            _pauseMenu = GameObject.FindObjectOfType<MenuGamePause>();
            _weaponController.WeaponChanged.AddListener(isFlamethrower);
            _playerScript.Death.AddListener(OffController);
        }
        
        public void OnStart()
        {
            IsActive = true;
            _playerIsDead = false;
            Time.timeScale = 1;
        }

        public void OnUpdate()
        {
            if (IsActive)
            {
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                Move(x, y);

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    _camera.SetBool("IsShooting", true);
                    _playerAnimation.SetBool("Aiming", true);
                    _playerAnimation.SetLayerWeight(1, 1);
                    _playerAnimation.SetLayerWeight(2, 1);

                    _playerController.Aiming(true);
                    _weaponController.ActiveWeapon.IsVisible(true);
                }
                else if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    _camera.SetBool("IsShooting", false);
                    _playerController.Aiming(false);

                    _playerAnimation.SetBool("Aiming", false);
                    _playerAnimation.SetLayerWeight(1, 0);
                    _playerAnimation.SetLayerWeight(2, 0);
                    
                    for (int i = 0; i < Inventory.Weapons.Length; i++)
                    {
                        Inventory.Weapons[i].IsVisible(false); 
                    }
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _playerAnimation.SetTrigger("Jump");
                }

                if (Input.GetKey(_kneeling))
                {
                    _playerAnimation.SetBool("Kneeling", true);
                }
                else
                {
                    _playerAnimation.SetBool("Kneeling", false);
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
                
                if (Input.GetKeyDown(_save))
                {
                    _saveDataRepository.Save();
                }

                if (Input.GetKeyDown(_load))
                {
                    _saveDataRepository.Load();
                }

                if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0)
                {
                    isFlamethrower();
                }
            }

            if (Input.GetKeyDown(_cancel))
            {
                _flashLightController.Off();
                _pauseMenu.PressedClose.AddListener(SwitchPause);
                SwitchPause();
            }

        }

        public void SwitchPause()
        {
            if (!_isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _isPaused = true;
                Time.timeScale = 0;
                _pauseMenu.OpenSound();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _panelManager.CloseCurrent();
                _isPaused = false;
                _pauseMenu.PressedClose.RemoveListener(SwitchPause);
                Time.timeScale = 1;
                _pauseMenu.CloseSound();
            }

            if (!_playerIsDead)
            {
                base.Switch();
            }

            _pauseMenu.Animator.SetBool("Open", _isPaused);
            _pauseScreen.MakeDarkScreen(_isPaused);
        }

        public void isFlamethrower()
        {
            if(_isFlameThrower == false)
            {
                _isFlameThrower = true;
            }
            else { _isFlameThrower = false; };

            _playerAnimation.SetBool("FlameT", _isFlameThrower);
        }

        private void Move(float x, float y)
        {
            _playerAnimation.SetFloat("VelX", x);
            _playerAnimation.SetFloat("VelY", y);
        }

        public void OffController()
        {
            _playerAnimation.SetLayerWeight(1, 0);
            _playerAnimation.SetLayerWeight(2, 0);
            base.Switch();
            _playerIsDead = true;
        }
    }
}
