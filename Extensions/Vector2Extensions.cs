using UnityEngine;
using Random = UnityEngine.Random;

namespace Fer.Tools
{
	public static class Vector2Extensions
	{
		public static float GetRandomValue(this Vector2 vector)
		{
			return Random.Range(vector.x, vector.y);
		}
	}
}