using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
	// Scripts

	[HideInInspector]
	public Door door;

	public void CheckDoor (GameObject hitDoor)
	{
		door = hitDoor.GetComponent<Door> ();
	
		door.ChangeScene ();
	}
}
