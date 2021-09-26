using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Shooter.Move
{
    
    public class AgentMover : MonoBehaviour, IMovable, IAction
    {
        NavMeshAgent agent;
        [SerializeField] Transform destination;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void SetTarget(Transform target)
        {
            destination = target;
        }
        
        public void Move()
        {
            agent.destination = destination.position;
            agent.isStopped = false;
        }

        public float SetMoveSpeed()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 LocalVelocity = transform.InverseTransformDirection(velocity);
            float speed = LocalVelocity.z;
            return speed;
        }

        public void Cancel()
        {
            agent.isStopped = true;
        }
    }
}
