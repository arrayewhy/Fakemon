using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	// Scripts

	public SceneExit sceneExit;

	// Door Variables

	public string doorTo = "Home";

	// Enumerators

	IEnumerator changeScene;

	public void ChangeScene ()
	{
		changeScene = sceneExit.ChangeScene (doorTo);

		StartCoroutine (changeScene);
	}
}
