using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    private AudioSource m_audioSource;

    public AudioClip clickSound;

    public void NewGame()
    {
        PlayClickSound();
        StartCoroutine(LoadScene(clickSound.length));
    }

    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.clip = clickSound;
    }

    public void PlayClickSound()
    {
        m_audioSource.Play();
    }

    IEnumerator LoadScene(float length)
    {
        yield return new WaitForSeconds(length);
        SceneManager.LoadScene("EarthLevel");
    }

}
