
using UnityEngine;

namespace Shooter
{
    public class UIInterface
    {
        private BatteryCharge _batteryCharge;
        private BulletsCount _bulletsCount;

        public BatteryCharge BatteryCharge
        {
            get
            {
                if (!_batteryCharge)
                {
                    _batteryCharge = GameObject.FindObjectOfType<BatteryCharge>();
                }
                return _batteryCharge;
            }
            set
            {
                _batteryCharge = value;
            }

        }

        public BulletsCount BulletsCount
        {
            get
            {
                if (!_bulletsCount)
                {
                    _bulletsCount = GameObject.FindObjectOfType<BulletsCount>();
                }
                return _bulletsCount;
            }
            set
            {
                _bulletsCount = value;
            }
        }
    }
}
