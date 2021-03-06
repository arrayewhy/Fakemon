﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
	// Scripts

    public SceneFade sceneFade;

	public IEnumerator ChangeScene (string door, string targetScene)
	{
    	// Record Door Name

    	SetActiveDoorName (door);

        // Hide Scene

        yield return sceneFade.HideScene ();

    	// Load Scene

    	LoadScene (targetScene);

    	yield return null;
	}

	void LoadScene (string targetScene)
	{
		SceneManager.LoadScene (targetScene);
	}

	void SetActiveDoorName (string door)
	{
		PersistantDataHandler.ActiveDoorName = door;
	}
}
