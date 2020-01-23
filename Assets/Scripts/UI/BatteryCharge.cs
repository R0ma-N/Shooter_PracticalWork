using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class BatteryCharge : MonoBehaviour
    {
        public Canvas Canvas;
        private Image[] Devisions;

        private Color32 orange = new Color32(225, 112, 52, 255);
        private Color32 green = new Color32(0, 147, 17, 255);

        private void Awake()
        {
            Canvas = GetComponentInParent<Canvas>();
            Devisions = GetComponentsInChildren<Image>();
        }

        public void Charge100Percents()
        {
            foreach (var devision in Devisions)
            {
                devision.enabled = true;
                devision.color = green;
            }
        }

        public void Charge80Percents()
        {
            for (int i = 0; i < 4; i++)
            {
                Devisions[i].enabled = true;
                Devisions[i].color = green;
            }

            Devisions[5].enabled = false;
        }

        public void Charge64Percents()
        {
            for (int i = 0; i < 3; i++)
            {
                Devisions[i].enabled = true;
                Devisions[i].color = green;
            }

            for (int i = 4; i < 5; i++)
            {
                Devisions[i].enabled = false;
            }
        }

        public void Charge50Percents()
        {
            for (int i = 0; i < 2; i++)
            {
                Devisions[i].enabled = true;
                Devisions[i].color = green;
            }

            for (int i = 3; i < 5; i++)
            {
                Devisions[i].enabled = false;
            }
        }

        public void Charge32Percents()
        {

            Devisions[0].color = Devisions[1].color = orange;
            Devisions[0].enabled = Devisions[1].enabled = true;

            for (int i = 2; i < 5; i++)
            {
                Devisions[i].enabled = false;
            }
        }

        public void Charge16Percents()
        {
            Devisions[0].enabled = true;
            Devisions[0].color = Color.red;

            for (int i = 1; i < 5; i++)
            {
                Devisions[i].enabled = false;
            }
        }
    }
}
