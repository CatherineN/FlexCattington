﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNode : MonoBehaviour {

    public string text; //what npc says

    public int ID = -1; //identification of the node

    public List<GameObject> Options; //ways you can respond to the text

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponentInChildren<Text>().text = text;
    }

    
}
