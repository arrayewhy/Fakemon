using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBattleScene : MonoBehaviour
{
    public void EnterBattleScene ()
    {
        // Record Door Name

        SetActiveDoorName (ArenaDoor ());

        // Load Scene

        LoadScene (ArenaType ());
    }

    void LoadScene (string targetScene)
    {
        SceneManager.LoadScene (targetScene);
    }

    void SetActiveDoorName (string door)
    {
        PersistantDataHandler.ActiveDoorName = door;
    }

    string ArenaDoor ()
    {
        return "Entrance";
    }

    string ArenaType ()
    {
        return "Arena";
    }
}
