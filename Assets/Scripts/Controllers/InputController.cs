using UnityEngine;

namespace Shooter
{
    public class InputController : BaseController, IOnUpdate
    {
        private FlashLightController _flashLightController = new FlashLightController();
        private WeaponController _weaponController = new WeaponController();
        private PlayerController _playerController = new PlayerController();
        private SaveDataRepository _saveDataRepository = new SaveDataRepository();
        private CellPoint _cellPointUI;
        private Animator _playerAnimation;
        private Animator _camera;
        private Transform _player;
        private float sensitivity = 4;

        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _save = KeyCode.C;
        private KeyCode _load = KeyCode.V;

        private KeyCode _left = KeyCode.A;
        private KeyCode _right = KeyCode.D;

        float rotationX = 0;
        float rotationY = 0;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _playerAnimation = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Animator>();
            _camera = Camera.main.GetComponent<Animator>();
            _player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).GetComponent<Transform>();
            _cellPointUI = GameObject.FindObjectOfType<CellPoint>();
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

            _playerAnimation.SetFloat("Blend", Input.GetAxis("Horizontal"));

            //{
            //    _playerAnimation.SetBool("Move Left", true);
            //}
            //else if (Input.GetKeyUp(_left))
            //{
            //    _playerAnimation.SetBool("Move Left", false);
            //}

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
                _cellPointUI.Canvas.enabled = true;
                _playerController.Aiming(true);
                Debug.Log("On");
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                _camera.SetBool("IsShooting", false);
                _playerAnimation.SetBool("Aiming", false);
                _cellPointUI.Canvas.enabled = false;
                _playerController.Aiming(false);
                Debug.Log("Off");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("OKKK");
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

        private Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            //angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);
            angleX = Mathf.Clamp(angleX, -90, 90);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
    }
}
