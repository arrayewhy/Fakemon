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
        return PersistantDataHandler.ActiveDoorName != null ? PersistantDataHandler.ActiveDoorName : "HomeOutside";
    }
}