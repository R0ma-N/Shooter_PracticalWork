
using UnityEngine;

namespace Shooter
{
    public class FlashLightController: BaseController , IOnInitialize, IOnUpdate
    {
        private FlashLightModel _flashLight;
        private BatteryCharge _batteryUI;
        private Timer _timer;

        private Color32 orange = new Color32(225, 112, 52, 255);
        private Color32 green = new Color32(0, 147, 17, 255);

        public FlashLightController()
        {
            _flashLight = Inventory.FlashLight;
            _batteryUI = UIInterface.BatteryCharge;
            _timer = new Timer();
        }

        public void OnStart()
        {
            _flashLight.CurrentCharge = _flashLight.MaxCharge;
            _flashLight.Light.enabled = false;
            _batteryUI.Canvas.enabled = false;
        }
        
        public void OnUpdate()
        {
            if (_flashLight.IsOn && _flashLight.CurrentCharge > 0)
            {
                DecreaseCharge();
            }
            else Off();

            if (!_flashLight.IsOn && _flashLight.CurrentCharge < _flashLight.MaxCharge)
            {
                IncreaseCharge();
            }
        }
        
        public override void On()
        {
            Switch(true);
        }
        public override void Off()
        {
            Switch(false);
        }

        public override void Switch()
        {
            if (_flashLight.IsOn)
            {
                Off();
            }
            else
            {
                On();
            }
        }

        private void Switch(bool value)
        {
            _flashLight.Light.enabled = value;
            _flashLight.IsOn = value;
            _batteryUI.Canvas.enabled = value;
        }

        //   +----------------------------------------+
        //   |   +--+  +--+  +--+  +--+  +--+  +--+   |
        //   |   |**|  |**|  |**|  |**|  |**|  |**|   +--+
        //   |   |**|  |**|  |**|  |**|  |**|  |**|      |
        //   |   |**|  |**|  |**|  |**|  |**|  |**|      |
        //   |   |**|  |**|  |**|  |**|  |**|  |**|   +--+
        //   |   +--+  +--+  +--+  +--+  +--+  +--+   |
        //   +----------------------------------------+
        //   

        private void DecreaseCharge()
        {
            if(_flashLight.CurrentCharge >= _flashLight.MaxCharge)
            {
                _batteryUI.Charge100Percents();
            }

            _flashLight.CurrentCharge -= Time.deltaTime;

            if (_flashLight.CurrentCharge < _flashLight.MaxCharge - _flashLight.MaxCharge / 6)
            {
                _batteryUI.Charge80Percents();

                if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 2)
                {
                    _batteryUI.Charge64Percents();

                    if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 3)
                    {
                        _batteryUI.Charge50Percents();

                        if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 4)
                        {
                            _batteryUI.Charge32Percents();

                            if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 5)
                            {
                                _batteryUI.Charge16Percents();
                                
                                _flashLight.Light.enabled = _timer.BlinkRandom(0.01f, 0.1f);
                                
                                if(_flashLight.CurrentCharge == 0)
                                {
                                    Off();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void IncreaseCharge()
        {
            _flashLight.CurrentCharge += Time.deltaTime;
        }
    }
}
