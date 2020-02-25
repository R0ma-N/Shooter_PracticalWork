using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class CellPoint : MonoBehaviour
    {
        public Canvas Canvas;

        void Awake()
        {
            Canvas = GetComponentInParent<Canvas>();
            Canvas.enabled = false;
        }
    }
}
