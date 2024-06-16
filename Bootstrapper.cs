using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bootstrapper
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void Execute()
	{
		var systems = Resources.Load("Systems");

		if (systems == null) return;
		Object.DontDestroyOnLoad(Object.Instantiate(systems));
	}
}