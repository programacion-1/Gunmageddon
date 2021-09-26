using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Shooter.Animators;
using Shooter.Combat;
using Shooter.Core;
using Shooter.Move;

namespace Shooter.Control
{
    public class CharControl : MonoBehaviour
    {
        AgentMover agentMover;
        CharAnimator charAnimator;
        ActionScheduler actionScheduler;
        Fighter fighter;
        void Start()
        {
            agentMover = GetComponent<AgentMover>();
            charAnimator = GetComponent<CharAnimator>();
            actionScheduler = GetComponent<ActionScheduler>();
            fighter = GetComponent<Fighter>();
        }

        public void StartMoveBehaviour()
        {
            actionScheduler.StartAction(agentMover);
            MoveBehaviour();
        }

        void MoveBehaviour()
        {
            agentMover.Move();
        }

        void AttackBehaviour()
        {
            actionScheduler.CancelCurrentAction();
            charAnimator.SetAttackBool(true);
        }

        private void DeathBehaviour()
        {
            actionScheduler.CancelCurrentAction();
            charAnimator.SetDeadTrigger();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
            if(Input.GetKeyDown(KeyCode.Z)) StartMoveBehaviour();
            if(Input.GetKeyDown(KeyCode.X)) AttackBehaviour();
            if(Input.GetKeyDown(KeyCode.C)) DeathBehaviour();
        }

        void UpdateAnimator()
        {
            charAnimator.SetMoveSpeed(agentMover.SetMoveSpeed());
        }
    }

}