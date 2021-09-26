using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Animators
{
    public class CharAnimator : MonoBehaviour
    {
        Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            anim.SetFloat("moveSpeed", moveSpeed);
        }

        public void SetAttackBool(bool isShooting)
        {
            anim.SetBool("isShooting", isShooting);
        }

        public void SetHitTrigger()
        {
            anim.SetTrigger("hitTrigger");
        }

        public void SetDeadTrigger()
        {
            anim.SetTrigger("deadTrigger");
        }

        
    }

}