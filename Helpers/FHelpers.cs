using UnityEngine;

namespace Fer.Tools.Helpers
{
	public static class FHelpers
	{
		private static Camera _camera;

		public static Camera Camera
		{
			get
			{
				if (_camera == null) _camera = Camera.main;
				return _camera;
			}
		}

		public static Vector2 GetCanvasElementWorldPosition(RectTransform element)
		{
			RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, Camera,
				out var result);
			return result;
		}
	}
}