﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaiterScript : MonoBehaviour {

    public bool correctCoffee;
    public float score;
    public GameObject wrong;
    public GameObject right;
    public enum States
    {
        waiterApproach,
        questionPopped,
        possession,
        aftermath,
    }
    private Transform waiterTrans;
    private States gameState;
    
    private bool leaving = false;
	// Use this for initialization
	void Start () {
        waiterTrans = gameObject.transform;
        gameState = States.waiterApproach;
        correctCoffee = false;
        score = PlayerPrefs.GetFloat("score");
    }
	
	// Update is called once per frame
	void Update () {
        if (leaving)
        {
            Leave();
        }
        CheckForTransition();
		
	}
    void Leave()
    {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-5, 0));
        
    }
    void CheckForTransition()
    {
        if (!correctCoffee && gameObject.transform.position.x < -1.7)
            wrong.SetActive(true);
        else if (correctCoffee && gameObject.transform.position.x < -1.7)
            right.SetActive(true);
        if (gameObject.transform.position.x < -13)
        {
            CoffeeScore();
            PlayerPrefs.SetFloat("score", score);
            SceneManager.LoadScene("Conversation");
        }
    }

    public void CoffeeScore()
    {
        if (!correctCoffee)
            score -= 10;
        else
            score += 15;

    }
}
