using UnityEngine;
using RPG.Movement;
using System;

namespace RPG.Combat
{
	public class Fighter : MonoBehaviour
	{
		#region GameObjects

		private Transform target;
		private Mover _mover;

		#endregion

		#region Variables

		[Range(1, 5)] 
		[SerializeField] private float weaponRange = 2.0f;
		private bool isInRange;

		#endregion

		private void Start()
		{
			_mover = GetComponent<Mover>();
		}

		private void Update()
		{
			if (target != null)
			{
				isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
			}
			// isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
			
			if (target != null && !isInRange)
			{
				// move to the position within the range
				_mover.MoveTo(target.position);
			}
			else
			{
				_mover.Stop();
			}
		}

		public void Attack(CombatTarget combatTarget)
		{
			target = combatTarget.transform;
		}
	}
}