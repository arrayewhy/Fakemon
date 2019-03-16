using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChangeDoorPicker : MonoBehaviour
{
    public GameObject ActiveDoor ()
    {
        return gameObject.transform.Find (ActiveDoorName ()).gameObject;
    }

    string ActiveDoorName ()
    {
        return PersistantDataHandler.ActiveDoorName != null ? PersistantDataHandler.ActiveDoorName : BackUpDoor ();
    }

	string BackUpDoor ()
	{
		string door = transform.GetChild (0).name;

		Debug.LogWarning ("Default Door: " + door);

		return door;
	}
}