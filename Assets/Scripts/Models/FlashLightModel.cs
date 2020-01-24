
using UnityEngine;

namespace Shooter
{
    public sealed class FlashLightModel : BaseObjectModel
    {
        public Light Light { get; private set; }
        public bool IsOn;
        public float MaxCharge = 10;
        public float CurrentCharge;

        Timer Timer;
        
        protected override void Awake()
        {           
            Light = GetComponent<Light>();
            IsOn = false;
            Timer = new Timer();
        }
    }
}
