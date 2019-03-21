using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTextStarter : MonoBehaviour
{
    // Linked Game Objects

    public bool showBattleText;

    private void Start ()
    {
        if (showBattleText)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild (i).gameObject.SetActive (true);
            }
        }
    }
}
