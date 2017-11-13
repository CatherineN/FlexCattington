using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionScreen : MonoBehaviour
{
    public Sprite screen1;
    public Sprite screen2;

    public Button next;
    public Button back;
    public Button play;

    private SpriteRenderer sRender;
	// Use this for initialization
	void Start ()
    {
        sRender = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void NextScreen()
    {
        sRender.sprite = screen2;
        next.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
    }

    public void PreviousScreen()
    {
        sRender.sprite = screen1;
        next.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Waldo");
    }
}
