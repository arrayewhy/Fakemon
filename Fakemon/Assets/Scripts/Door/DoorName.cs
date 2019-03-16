using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorName : MonoBehaviour
{
	// Door Name Variables

	public bool getFromParent;

	// Debug
	[Space (10)]
	public bool debug;

	public string GetDoorName ()
	{
		string door = getFromParent ? transform.parent.name : gameObject.name;

		if (debug) print ("Current Door: " + door + " | Persistant Active Door: " + PersistantDataHandler.ActiveDoorName);

		return getFromParent ? transform.parent.name : gameObject.name;
	}
}
