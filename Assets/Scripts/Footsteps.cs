using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    private AudioSource src;

    public AudioClip footstepSound;

    public void Step() {
        src.PlayOneShot(footstepSound);
    }

    void Start() {
        src = gameObject.GetComponent<AudioSource>();
    }
}
