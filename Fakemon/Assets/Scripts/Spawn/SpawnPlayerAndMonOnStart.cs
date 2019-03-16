using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerAndMonOnStart : MonoBehaviour
{
    // Scripts

    Spawn spawn;

    public PrefabLibrary prefabLibrary;
    public RoomChangeDoorPicker roomChangeDoorPicker;

    private void Start ()
    {
		// Scripts

        spawn = GetComponent<Spawn> ();
	}

    public void Spawn ()
    {
		Vector2 spawnPos = SpawnPosition ();

        SpawnPlayer (spawnPos);
        SpawnMon (spawnPos);
    }

    void SpawnPlayer (Vector2 spawnPos)
    {
        spawn.SpawnObject (GetPlayer (), spawnPos, PlayerType ());
    }

    void SpawnMon (Vector2 spawnPos)
    {
        spawn.SpawnObject (GetMon (), spawnPos, MonName ());
    }

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

    #region Spawn Position _____________________________________________________

    Vector2 SpawnPosition ()
    {
        return roomChangeDoorPicker.ActiveDoor ().transform.position;
    }

    #endregion

    #region Names ______________________________________________________________

    string PlayerType ()
    {
        return "Brie";
    }

    string MonName ()
    {
        return "Bulbabro";
    }

    #endregion
}
