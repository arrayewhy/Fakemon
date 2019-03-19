using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    // Components

    Camera mainCam;

    // Sound Bank Variables

    public AudioClip door;

    float fullVolume = 1f;
    float halfVolume = 0.5f;
    float lowVolume = 0.2f;

    private void Start ()
    {
        // Components

        mainCam = Camera.main.GetComponent<Camera> ();
    }

    public void PlayDoorSound ()
    {
        AudioSource.PlayClipAtPoint (door, mainCam.transform.position, lowVolume);
    }
}
