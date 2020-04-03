using System.Collections;
using System.Collections.Generic;
using Shooter;
using UnityEngine;

public class MedPack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.Healing();
            Destroy(gameObject);
        }
    }
}
