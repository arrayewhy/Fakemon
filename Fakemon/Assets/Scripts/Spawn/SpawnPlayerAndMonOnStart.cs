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
        spawn = GetComponent<Spawn> ();
    }

    public void Spawn ()
    {
        SpawnPlayer ();
        SpawnMon ();
    }

    void SpawnPlayer ()
    {
        spawn.SpawnObject (GetPlayer (), PlayerSpawnPosition (), PlayerType ());
    }

    void SpawnMon ()
    {
        spawn.SpawnObject (GetMon (), MonSpawnPosition (), MonName ());
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

    Vector2 PlayerSpawnPosition ()
    {
        return roomChangeDoorPicker.ActiveDoor ().transform.position;
    }

    Vector2 MonSpawnPosition ()
    {
        return PlayerSpawnPosition ();
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
