using System.IO;
using UnityEngine;

namespace Shooter
{
	public sealed class SaveDataRepository
	{
		private readonly IData<SerializableGameObject> _data;

		private const string _folderName = "dataSave";
		private const string _fileName = "data.bat";
		private readonly string _path;
		private Transform _player;

		public SaveDataRepository()
		{
			_data = new JsonData<SerializableGameObject>();
			_path = Path.Combine(Application.dataPath, _folderName);
			_player = GameObject.FindObjectOfType<CharacterController>().transform;
		}

		public void Save()
		{
			if (!Directory.Exists(Path.Combine(_path)))
			{
				Directory.CreateDirectory(_path);
			}
			var player = new SerializableGameObject
			{
				Pos = _player.position,
				Name = "New Player",
				IsEnable = true
			};

			_data.Save(player, Path.Combine(_path, _fileName));
		}

		public void Load()
		{
			var file = Path.Combine(_path, _fileName);
			if (!File.Exists(file)) return;
			var newPlayer = _data.Load(file);
			_player.position = newPlayer.Pos;
			_player.name = newPlayer.Name;
			_player.gameObject.SetActive(newPlayer.IsEnable);

			Debug.Log(newPlayer);
		}
	}
}
