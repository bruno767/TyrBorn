using UnityEngine;
using System.Collections;

public class EvilSoundScript : MonoBehaviour {
    private AudioSource audioSource;

    public AudioClip evilSound;

    void Awake () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = evilSound;
        audioSource.PlayDelayed(1f);
    }
}
