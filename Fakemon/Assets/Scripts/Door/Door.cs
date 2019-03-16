using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	// Scripts

	DoorName doorName;

	public SceneExit sceneExit;

    // Door Variables

    public string destination;

	// Enumerators

	IEnumerator changeScene;

	private void Start ()
	{
		// Scripts

		doorName = GetComponent<DoorName> ();
	}

	public void ChangeScene ()
	{
		changeScene = sceneExit.ChangeScene (DoorName (), destination);
		StartCoroutine (changeScene);
	}

	string DoorName ()
	{
		return doorName.GetDoorName ();
	}
}
