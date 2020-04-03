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
        public Canvas canvas;

        private void Awake()
        {
            TxtBullets = GetComponentInChildren<Text>();
            Images = GetComponentsInChildren<Image>();
            canvas = GetComponent<Canvas>();
            FlameThrowerImg = Images[0];
            PistolImg = Images[1];
        }

        private void Start()
        {
            canvas.enabled = false;
        }

        public void OnEnable()
        {
            canvas.enabled = true;
        }
    }
}
