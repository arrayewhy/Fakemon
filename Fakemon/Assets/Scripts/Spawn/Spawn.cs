using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public void SpawnObject (GameObject obj, Vector2 spawnPosition, string newName)
	{
        GameObject spawnObject = Instantiate (obj, spawnPosition, Quaternion.identity);

        spawnObject.name = newName != "" ? newName : spawnObject.name;
	}
}
