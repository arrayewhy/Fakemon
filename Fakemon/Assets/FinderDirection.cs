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
	}

	#region Rotate _____________________________________________________________

	void RotateClockwise ()
	{
		_transform.Rotate (new Vector3 (0, 0, -rotateAmount));
	}

	void RotateAntiClockWise ()
	{
		_transform.Rotate (new Vector3 (0, 0, rotateAmount));
	}

	#endregion
}
