using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInitiator : MonoBehaviour
{
    // Scripts

    BattlerDirectionCycleFull battlerDirectionCycle;
    AnimatorState animatorState;
    BattleSceneFade battleSceneFade;

    public Emotes emotes;
    public LoadBattleScene loadBattleScene;

	// Emote Variables

	int flashDuration = 1;

    // Enumerators

    IEnumerator initiateBattle;
    IEnumerator battleFlash;

    private void Start ()
    {
        // Scripts

        battlerDirectionCycle = GetComponentInParent<BattlerDirectionCycleFull> ();

        // REFACTOR
        // Consider static instancing.

        animatorState = GameObject.Find ("Brie").GetComponent<AnimatorState> ();

        // REFACTOR
        // Consider static instancing.

        battleSceneFade = GameObject.Find ("Scene Fader").GetComponent<BattleSceneFade> ();
	}

    #region On Triggers ________________________________________________________

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player") TriggerInitiateBattle ();
    }

    #endregion

    void TriggerInitiateBattle ()
    {
        initiateBattle = InitiateBattle ();
        StartCoroutine (initiateBattle);
    }

    #region Battle _____________________________________________________________

    IEnumerator InitiateBattle ()
	{
        StopDirectionCycle ();

        StopPlayerMovement ();

        yield return emotes.FlashEvil (flashDuration);

        yield return battleSceneFade.BattleFlash ();

        loadBattleScene.EnterBattleScene ();
	}

	#endregion

    #region Direction Cycle ____________________________________________________

    void StopDirectionCycle ()
    {
        battlerDirectionCycle.shouldCycle = false;
    }

    #endregion

    #region Player Busy ________________________________________________________

    void StopPlayerMovement ()
    {
        animatorState.BusyON ();
    }

    #endregion
}
