using UnityEngine;

namespace Shooter
{
	public class MiniMap : MonoBehaviour
	{
		private Transform _player;
		float storedShadowDistance;

		private void OnPreRender()
		{
			storedShadowDistance = QualitySettings.shadowDistance;
			QualitySettings.shadowDistance = 0;
		}

		private void OnPostRender()
		{
			QualitySettings.shadowDistance = storedShadowDistance;
		}

		private void Start()
		{
			//_player = Camera.main.transform;
			var rt = Resources.Load<RenderTexture>("Minimap");
			GetComponent<Camera>().targetTexture = rt;
		}

		//private void LateUpdate()
		//{
		//	var newPosition = _player.position;
		//	newPosition.y = transform.position.y;
		//	transform.position = newPosition;
		//	transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
		//}
	}

}