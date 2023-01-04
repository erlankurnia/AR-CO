using UnityEngine;

namespace Project.Hometown
{
	public class HouseView : MonoBehaviour
	{
		private HouseController _houseController;

		private void OnDisable()
		{
			//add implementation
			if (_houseController != null) _houseController.OnLevelUp -= HandleOnHouseLevelUp;
		}

		private void OnEnable()
		{
			//add implementation
			if (_houseController != null) _houseController.OnLevelUp += HandleOnHouseLevelUp;
		}

		public HouseView Setup(HouseController houseController)
		{
			_houseController = houseController;
			return this;
		}

		public void EnableScript()
		{
			//remember to enable script from context if needed
			enabled = true;
		}

		public void HandleOnHouseLevelUp(LevelupEventData data)
		{
			//add implementation
			Debug.Log($"{data.Level} <= {data.MaxLevel}");
			if (data.Level <= data.MaxLevel) {
				float scale = (float)data.Level * .75f;
				if (scale < 1) scale = 1;
				transform.localScale = new(scale, scale);
				Debug.Log($"{gameObject.name}:{transform.localScale}");
			}
			else {
				Debug.LogWarning("On max level!");
			}
		}
	}
}