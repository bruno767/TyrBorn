using UnityEngine;
using System.Collections;

public class AmbientSoundScript : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip[] clips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake ()
    {
        StartCoroutine(PlaySounds());
    }

    IEnumerator PlaySounds()
    {
        audioSource = GetComponent<AudioSource>();
        while (true)
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }
}
