using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class ZoneOfDetect : MonoBehaviour
    {
        public bool PlayerDetected;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(TagManager.PLAYER))
            {
                PlayerDetected = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(TagManager.PLAYER))
            {
                PlayerDetected = false;
            }
        }
    }
}
