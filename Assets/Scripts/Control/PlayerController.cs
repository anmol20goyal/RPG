using System;
using RPG.Combat;
using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
	public class PlayerController : MonoBehaviour
	{
		private Camera mainCamera;
		private Mover _mover;

		private void Start()
		{
			_mover = GetComponent<Mover>();
			mainCamera = Camera.main;
		}

		private void Update()
		{
			if (InteractWithCombat()) return;
			if (InteractWithMovement()) return;
		}

		private bool InteractWithCombat()
		{
			var hits = Physics.RaycastAll(GetMouseRay());
			foreach (var hit in hits)
			{
				var target = hit.transform.GetComponent<CombatTarget>();
				if (target == null) continue;
				
				if (Input.GetMouseButtonDown(0))
				{
					target.GetComponent<Fighter>().Attack(target);
				}

				return true;
			}

			return false;
		}
		
		private bool InteractWithMovement()
		{
			RaycastHit hit;
			bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
			if (hasHit)
			{
				if (Input.GetMouseButton(0))
				{
					_mover.MoveTo(hit.point);
				}

				return true;
			}

			return false;
		}

		private Ray GetMouseRay()
		{
			return mainCamera.ScreenPointToRay(Input.mousePosition);
		}
	}
}