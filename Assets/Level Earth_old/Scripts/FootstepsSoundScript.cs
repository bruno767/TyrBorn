using UnityEngine;
using System.Collections;

public class FootstepsSoundScript : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip[] clips;

    bool walking;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        StartCoroutine(PlaySounds());
    }

    public void StartWalking()
    {
        if (!this.walking)
        {
            this.walking = true;
            StartCoroutine(PlaySounds());
        }

    }

    public void StopWalking()
    {
        if (this.walking)
        {
            this.walking = false;
            StopCoroutine(PlaySounds());
        }
    }


    IEnumerator PlaySounds()
    {
        audioSource = GetComponent<AudioSource>();
        while (walking)
        {
			if (clips.Length > 0) {
				audioSource.clip = clips [Random.Range (0, clips.Length)];
				audioSource.Play ();
				yield return new WaitForSeconds (0.24f);
			}
        }
        
    }
}
