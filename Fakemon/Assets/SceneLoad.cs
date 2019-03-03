using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour {

	// Enumerators

	IEnumerator startOperations;

	private void Start () {

		#region Start Operations ...............................................

		startOperations = StartOperations ();
		StartCoroutine (startOperations);

		#endregion
	}

	IEnumerator StartOperations () {
		yield return null;
	}
}
