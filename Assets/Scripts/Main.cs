using Helper;
using UnityEngine;

namespace Shooter
{
    public class Main : MonoBehaviour
    {
        [System.Serializable]
        public struct SceneDate
        {
            public SceneField MainMenu;
            public SceneField Game;
        }

        public SceneDate Scenes;

        //private PlayerController _playerController;
        private InputController _inputController;
        private FlashLightController _flashLightController;
        private WeaponController _weaponController;
        private EnemyController _enemyController;
        private Player _player;
        private IOnUpdate[] _controllersUpdate;
        private IOnInitialize[] _controllersInit;

        private void Awake()
        {
            //_playerController = new PlayerController();
            _inputController = new InputController();
            _flashLightController = new FlashLightController();
            _weaponController = new WeaponController();
            _enemyController = new EnemyController();
            _player = GameObject.FindObjectOfType<Player>();
            
            _controllersInit = new IOnInitialize[4];
            _controllersInit[0] = _flashLightController;
            _controllersInit[1] = _player;
            _controllersInit[2] = _enemyController;
            _controllersInit[3] = _inputController;
            
            _controllersUpdate = new IOnUpdate[4];
            _controllersUpdate[0] = _inputController;
            //_controllersUpdate[1] = _playerController;
            _controllersUpdate[1] = _flashLightController;
            _controllersUpdate[2] = _weaponController;
            _controllersUpdate[3] = _enemyController;
        }
        void Start()
        {
            for (int i = 0; i < _controllersInit.Length; i++)
            {
                var controller = _controllersInit[i];
                controller.OnStart();
            }
        }

        void Update()
        {
            for (int i = 0; i < _controllersUpdate.Length; i++)
            {
                var controller = _controllersUpdate[i];
                controller.OnUpdate();
            }
        }
    }
}
