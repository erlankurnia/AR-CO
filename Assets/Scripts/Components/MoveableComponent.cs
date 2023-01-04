using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
	public class MoveableComponent : MonoBehaviour
	{
		private Vector3 _destination;

		public void SetDestination(Vector3 destination)
		{
			//add implementation to move this object to destination
			//and destroy it when it reach the destination
			//desination must be some vector3 where y and z coordinate not change from current coordinate
			//only x coordinate change and to positive direction (to the right)
			_destination = destination;
			Debug.Log("destination: " + destination);
			StartCoroutine(Moving());
		}

		private IEnumerator Moving()
		{
			while (Vector3.Distance(transform.position, _destination) > 3f) {
				Debug.Log($"Distance:{Vector3.Distance(transform.position, _destination)}");
				transform.position = Vector3.Lerp(transform.position, new(_destination.x, transform.position.y, transform.position.z), Time.deltaTime * .5f);
				yield return null;
			}

			Debug.Log("Destroy");
			yield return null;
		}
	}
}