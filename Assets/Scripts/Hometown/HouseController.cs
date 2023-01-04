using Project.Components;
using System;
using UnityEngine;

namespace Project.Hometown
{
	public class HouseController : IController, IUpgradeable, ICanTriggerSpawn
	{
		public event Action<LevelupEventData> OnLevelUp;
		public event Action TriggerSpawn;

		private HometownContext _hometownContext;
		private string _itemName;
		private UpgradeableData _upgradeableData;

		private HouseView houseView;

		public void OnContextDispose()
		{
			//add implementation
		}

		public HouseController(HometownContext hometownContext, string upgradeableItemName, InputManager inputManager)
		{
			_hometownContext = hometownContext;
			_itemName = upgradeableItemName;

			//add implementation
			(new UpgradeableRepository(_hometownContext)).GetUpgradeableData((UpgradeableData data) =>
			{
				_upgradeableData = data;
			});
		}

		public void Upgrade()
		{
			//add implementation
			if (_upgradeableData.Level < _upgradeableData.MaxLevel) {
				_upgradeableData.LevelUp();
				Debug.Log($"Handle Upgrade {_itemName}");
				OnLevelUp?.Invoke(new(_upgradeableData.Level, _upgradeableData.MaxLevel));
			}
			else {
				Debug.Log("Spawn Tank!");
				TriggerSpawn?.Invoke();
			}
		}

		public void HandleOnInputTouch()
		{
			//add implementation
		}
	}
}