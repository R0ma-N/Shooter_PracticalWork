
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Inventory
    {
        public List<Object> inventory;
        public WeaponBase[] Weapons;
        public FlashLightModel FlashLight;
        public GameObject Player;

        public Inventory()
        {
            FlashLight = Object.FindObjectOfType<FlashLightModel>();
            Player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            Weapons = Player.GetComponentsInChildren<WeaponBase>();
            Debug.Log("Inventory " + Weapons.Length);
            
            foreach (WeaponBase weapon in Weapons)
            {
                weapon.ClipsCount = weapon.ClipsMaxCount;
                weapon.BulletsCount = weapon.BulletsInClip;
            }
        }

        public void AddNewWeapon()
        {
            Weapons = Player.GetComponentsInChildren<WeaponBase>();
        }
    }
}
