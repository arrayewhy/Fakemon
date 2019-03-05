using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
	public void FlipSprite (Transform trans)
	{
		Vector2 tempScale = trans.localScale;
		tempScale.x *= -1;
		trans.localScale = tempScale;
	}
}
