using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentChecker : MonoBehaviour
{
	// Component Checker Variables

	public static int componentsLoaded;
	public int targetComponentCount;

	// Enumerators

	IEnumerator checkComponents;

	// Debug

	public bool debug;

	public IEnumerator CheckComponents ()
	{
		print (componentsLoaded);

		float timer = 0;

		while (!TargetComponentCountReached ())
		{
			if (debug)
			{
				if (Time.time > timer + 2)
				{
					PrintComponentCount ();

					timer = Time.time;
				}
			}

			yield return null;
		}

		if (debug)
		{
			ComponentsReady ();

			ClearComponentCount ();
		}
	}

	public static void RecordComponent ()
	{
		componentsLoaded++;
	}

	bool TargetComponentCountReached ()
	{
		return componentsLoaded == targetComponentCount;
	}

	void ClearComponentCount ()
	{
		componentsLoaded = 0;

		print ("Components cleared to " + componentsLoaded);
	}

	#region Debug _____________________________________________________________

	void PrintComponentCount ()
	{
		Debug.LogWarning ("Loaded: " + componentsLoaded + " | Target: " + targetComponentCount);
	}

	void ComponentsReady ()
	{
		print ("Components ready! " + componentsLoaded + " | " + targetComponentCount);
	}

	#endregion
}
