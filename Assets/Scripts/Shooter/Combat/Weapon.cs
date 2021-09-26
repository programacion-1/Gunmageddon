using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponFireRate = 1f;
        [SerializeField] GameObject equippedPrefab;
        [SerializeField] private bool isRightHanded = true;

        const string weaponName = "Weapon";

        public void Spawn(Transform rightHand, Transform leftHand)
        {
            DestroyOldWeapon(rightHand, leftHand);
            
            if(equippedPrefab != null)
            {
                Transform handTransform = GetTransform(rightHand, leftHand);
                GameObject newWeapon = Instantiate(equippedPrefab, handTransform);
                newWeapon.name = weaponName;
            }
        }

        private void DestroyOldWeapon(Transform rightHand, Transform leftHand)
        {
            Transform oldWeapon = rightHand.Find(weaponName);
            if(oldWeapon == null) oldWeapon = leftHand.Find(weaponName);
            if(oldWeapon == null) return;

            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }

        private Transform GetTransform(Transform rightHand, Transform leftHand)
        {
            Transform handTransform;
            if (isRightHanded) handTransform = rightHand;
            else handTransform = leftHand;
            return handTransform;
        }

         public float GetWeaponRange()
        {
            return weaponRange;
        }
        public float GetWeaponDamage()
        {
            return weaponDamage;
        }
        public float GetWeaponFireRate()
        {
            return weaponFireRate;
        }

        public bool CheckIsRightHanded()
        {
            return isRightHanded;
        }

    }
}