using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
	// Scripts

	[HideInInspector]
	public Door door;

    SoundBank soundBank;

    private void Start ()
    {
        // Scripts

        // REFACTOR

        soundBank = GameObject.Find ("Sound Player").GetComponent<SoundBank> ();
    }

    public void CheckDoor (GameObject hitDoor)
	{
		door = hitDoor.GetComponent<Door> ();
	
		door.ChangeScene ();

        soundBank.PlayDoorSound ();
	}
}
