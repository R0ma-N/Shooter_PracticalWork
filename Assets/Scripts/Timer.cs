
using UnityEngine;

namespace Shooter
{
    public class Timer
    {
        public float DistTime = 0;
        private float _curTime = 0;
        private float _random;
        private bool active;


        public bool TimeIsUp (float value)
        {
            if (DistTime == 0) 
            {
                DistTime = _curTime = value;
            }

            if (_curTime > 0)
            {
                _curTime -= Time.deltaTime;
                return false;
            }
            else
            {
                _curTime = DistTime;
                return true;
            }
        }

        public void Blink(ref bool valueForBlink, float blinkInterval)
        {
            if (valueForBlink)
            {
                if (TimeIsUp(blinkInterval))
                    valueForBlink = false;
            }
            else
            {
                if (TimeIsUp(blinkInterval))
                    valueForBlink = true;
            }
        }

        public bool BlinkRandom(float minValue, float maxValue)
        {
            if (active)
            {
                _random = Random.Range(minValue, maxValue);
                if (TimeIsUp(_random))
                {
                    active = false;
                }
                    return false;
            }
            else
            {
                _random = Random.Range(minValue, maxValue);
                if (TimeIsUp(_random))
                {
                    active = true;
                }
                    return true;
            }
        }
    }
}
