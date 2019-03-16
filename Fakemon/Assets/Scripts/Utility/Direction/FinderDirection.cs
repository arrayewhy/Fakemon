using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinderDirection : MonoBehaviour
{
	// Components

	Transform _transform;

	// Finder Direction Variables

	int rotateAmount = 90;

	private void Start ()
	{
		// Components

		_transform = transform;

		// Component Checker

		ComponentChecker.RecordComponent ();
	}

	#region Rotate _____________________________________________________________

	public void RotateClockwise ()
	{
		_transform.Rotate (new Vector3 (0, 0, -rotateAmount));
	}

	#endregion
}
