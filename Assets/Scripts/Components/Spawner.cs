using UnityEngine;

namespace Project.Components
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField]
		private MoveableComponent _moveableComponent;

		private void OnDisable()
		{
			//add implementation
		}

		private void OnEnable()
		{
			//add implementation
		}

		public void Setup(ICanTriggerSpawn spawnTrigger)
		{
			//add implementation
		}

		public void EnableScript()
		{
			//remember to enable script from context if needed
			enabled = true;
		}

		public void HandleOnSpawnTriggered()
		{
			//add implementation
			Debug.Log("HandleOnSpawnTriggered");
			if (!FindObjectOfType<MoveableComponent>()) SpawnMoveableObject();
		}

		private void SpawnMoveableObject()
		{
			//add implementation
			Transform parent = transform.GetChild(0);
			MoveableComponent mc = Instantiate(_moveableComponent, new(parent.position.x / 2, parent.position.y, parent.position.z), Quaternion.identity, parent);
			mc.SetDestination(new((parent.GetComponent<SpriteRenderer>().size.x) + mc.transform.position.x, 0, 0));
		}
	}
}