using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCard : MonoBehaviour
{
    public float waitTime; // time the card is visible
    public float fadeTime; // time the card takes to fade out

    private float timer; // keeps track of time
    private Image image; // acess to the color of the sprite

	// Use this for initialization
	void Start ()
    {
        image = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // increment time
        timer += Time.deltaTime;

        // begin to fade after a specified period of time
        if (timer >= waitTime)
            StartCoroutine(FadeOut());
	}
    
    IEnumerator FadeOut()
    {
        // take as long as specified in fadeTime
        for(float i = fadeTime; i > 0; i -= Time.deltaTime)
        {
            // calculate the opacity
            float value = i / fadeTime;

            Color c = image.color; // get the color
            c.a = i; // set the opacity
            image.color = c; // set the new color
            yield return null;
        }

        // delete the gameobject when it fades out
        GameObject.Destroy(gameObject);
    }
}
