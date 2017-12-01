using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOption : MonoBehaviour {

    public string text;//text to reply/do in response to the npc's text

    public GameObject resultNode; //where this specific option leads
    public int nodeID;//the ID/index of where the result node is located in the dialogue
    //private TextNode textScript;//script for the node that this option leads to

    public int relationshipEffect;//how this option influences your score behind the scenes

    // Use this for initialization
    void Start () {
        gameObject.GetComponentInChildren<Text>().text = text;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag != "Phone")
            gameObject.GetComponentInChildren<Text>().text = text;
        else
            gameObject.GetComponent<PhoneTextMaker>().CalculateSpaceNeeded(text);
    }

    public void UpdateScore()
    {
        Debug.Log("score updating " + PlayerPrefs.GetFloat("score"));
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + relationshipEffect);
    }
}
