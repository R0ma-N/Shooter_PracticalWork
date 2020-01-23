using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class BulletsCount : MonoBehaviour
    {
        public Text TxtBullets;
        private void Awake()
        {
            TxtBullets = GetComponent<Text>();
        }
    }
}
