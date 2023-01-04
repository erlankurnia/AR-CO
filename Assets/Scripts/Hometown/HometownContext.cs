using Project.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Hometown
{
	[RequireComponent(typeof(InputManager), typeof(Spawner))]
	public class HometownContext : MonoBehaviour
	{
		[SerializeField]
		private InputManager _inputManager;
		[SerializeField]
		private Spawner _spawner;

		public HouseController HouseController { get; private set; }

		private HouseView _houseView;

		private void Awake()
		{
			if (_inputManager == null) {
				_inputManager = GetComponent<InputManager>();
			}

			if (_spawner == null) {
				_spawner = GetComponent<Spawner>();
			}

			//add implementation
			//	Upgrade Rumah
			_houseView = GetComponentInChildren<HouseView>();
			HouseController = new(this, _houseView.name, _inputManager);
			_houseView = _houseView.Setup(HouseController);
			_inputManager.OnInputTouch += HouseController.Upgrade;
			_houseView.EnableScript();

			//	Tank Movement
			HouseController.TriggerSpawn += _spawner.HandleOnSpawnTriggered;
			_spawner.Setup(HouseController);
		}

		private void OnDestroy()
		{
			//add implementation
			//	Upgrade Rumah
			_inputManager.OnInputTouch -= HouseController.Upgrade;

			//	Tank Movement
			HouseController.TriggerSpawn -= _spawner.HandleOnSpawnTriggered;
		}
	}
}