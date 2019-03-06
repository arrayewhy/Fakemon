using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLibrary : MonoBehaviour
{
	// Prefabs

	public GameObject[] player;
	public GameObject[] mon;

	public GameObject GetPlayer ()
	{
		return player[0];
	}

	public GameObject GetMon ()
	{
		return mon[0];
	}
}
