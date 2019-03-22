using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIn : MonoBehaviour
{
	// Components

	Transform _transform;

	// Slide In Variables

	Vector2 targetPos;
	int displacement = -10;
	int speed = 4;

	private void Start ()
	{
		// Components

		_transform = transform;

		#region Start Operations ...............................................

		targetPos = _transform.position;

		_transform.position = new Vector3 (_transform.position.x, _transform.position.y + displacement, _transform.position.z);

		#endregion
	}

	private void Update ()
	{
		if (Vector3.Distance (_transform.position, targetPos) > 0.1f)
		{
			_transform.position = Vector2.Lerp (_transform.position, targetPos, Time.deltaTime * speed);
		}
	}
}
