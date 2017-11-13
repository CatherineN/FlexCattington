﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOption : MonoBehaviour {

    public string text;//text to reply/do in response to the npc's text

    public GameObject resultNode; //where this specific option leads

    public int relationshipEffect;//how this option influences your score behind the scenes

    // Use this for initialization
    void Start () {
        gameObject.GetComponentInChildren<Text>().text = text;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore()
    {
        Debug.Log("score updating " + PlayerPrefs.GetInt("score"));
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + relationshipEffect);
    }
}
