using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Animators;

namespace Shooter.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        CharAnimator charAnimator;
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] Weapon defaultWeapon = null;
        [SerializeField] Weapon currentWeapon = null;
        void Start()
        {
            charAnimator = GetComponent<CharAnimator>();
            EquipWeapon(defaultWeapon);    
        }
        
        void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            if(weapon == null) return;
            weapon.Spawn(rightHandTransform, leftHandTransform);
        }

        public void Cancel()
        {
            charAnimator.SetAttackBool(false);
        }
    }

}