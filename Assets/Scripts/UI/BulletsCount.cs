using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class BulletsCount : MonoBehaviour
    {
        public Text TxtBullets;
        public Image[] Images;
        public Image FlameThrowerImg;
        public Image PistolImg;

        private void Awake()
        {
            TxtBullets = GetComponentInChildren<Text>();
            Images = GetComponentsInChildren<Image>();
            FlameThrowerImg = Images[0];
            PistolImg = Images[1];
        }
    }
}
