using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsScript : MonoBehaviour {

    public Sprite empty;
    public Sprite normal;

    private int numberStars = -1;
    private int maximumStars = 4;

    Image[] sprites;

    void Start()
    {
        sprites = GetComponentsInChildren<Image>();
    }

    public void IncreaseStars ()
    {
        sprites[numberStars + 1].sprite = normal;
        numberStars++;
	}

    public void DecreaseStars()
    {
        sprites[numberStars - 1].sprite = normal;
        numberStars--;
    }

    public void ResetStars()
    {
        numberStars = 0;

        

        for(int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sprite = empty;
        }
    }
}
