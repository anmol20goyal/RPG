using System;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
	public class Mover : MonoBehaviour
	{
		#region GameObjects

		private NavMeshAgent navMeshAgent;
		private Animator animator;
	
		#endregion

		private void Start()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
			animator = GetComponent<Animator>();
		}

		private void Update()
		{
			UpdateAnimations();
		}

		public void MoveTo(Vector3 destination)
		{
			navMeshAgent.destination = destination;
			navMeshAgent.isStopped = false;
		}

		public void Stop()
		{
			navMeshAgent.isStopped = true;
		}
	
		private void UpdateAnimations()
		{
			Vector3 velocity = navMeshAgent.velocity;
			Vector3 localVelocity = transform.InverseTransformDirection(velocity);
			float speed = localVelocity.z;
			animator.SetFloat("forwardSpeed", speed);
		}
	}
}