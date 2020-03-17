using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class GetFlamethrower : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagManager.PLAYER))
            {
                Destroy(gameObject);
            }
        }
    }
}
