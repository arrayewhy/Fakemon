using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	// Scripts

	public PrefabLibrary prefabLibrary;

	#region Spawn Objects ______________________________________________________

	void SpawnObject (GameObject obj, Vector2 spawnPosition)
	{
		Instantiate (obj, spawnPosition, Quaternion.identity);
	}

	public void SpawnPlayer (Vector2 spawnPosition)
	{
		SpawnObject (GetPlayer (), spawnPosition);
	}

	public void SpawnMon (Vector2 spawnPosition)
	{
		SpawnObject (GetMon (), spawnPosition);
	}

	#endregion

	#region Get Objects ________________________________________________________

	GameObject GetPlayer ()
	{
		return prefabLibrary.GetPlayer ();
	}

	GameObject GetMon ()
	{
		return prefabLibrary.GetMon ();
	}

	#endregion
}
