using System;
using UnityEngine;

namespace RPG.Core
{
	public class CameraFollow : MonoBehaviour
	{
		#region GameObjects

		[SerializeField] private Transform player;

		#endregion

		private void Start()
		{
			transform.position = player.position;
		}

		private void LateUpdate()
		{
			transform.position = player.position;
		}
	}
}