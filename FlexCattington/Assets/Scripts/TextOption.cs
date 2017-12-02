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
        //Debug.Log("ID: " + nodeID);
        resultNode = GameObject.Find("SceneManager").GetComponent<Dialogue>().nodes[nodeID];
        //Debug.LogWarning(gameObject.name + "'s result: " + resultNode.GetComponent<TextNode>().text);
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

    /// <summary>
    /// Should be called when this option is choosen in the dialogue tree
    /// Will edit the existing text to match the node in narration box
    /// </summary>
    public void ChangeNode()
    {
        resultNode.GetComponent<TextNode>().SetNPCText();
        UpdateOptions();
    }

    /// <summary>
    /// Will update the options you can choose from for new node
    /// </summary>
    private void UpdateOptions()
    {
        GameObject.Find("Option 1").GetComponent<TextOption>().nodeID = resultNode.GetComponent<TextNode>().Options[0].GetComponent<TextOption>().nodeID;
        GameObject.Find("Option 1").GetComponent<TextOption>().text = resultNode.GetComponent<TextNode>().Options[0].GetComponent<TextOption>().text;
        GameObject.Find("Option 1").GetComponent<TextOption>().relationshipEffect = resultNode.GetComponent<TextNode>().Options[0].GetComponent<TextOption>().relationshipEffect;

        GameObject.Find("Option 2").GetComponent<TextOption>().nodeID = resultNode.GetComponent<TextNode>().Options[1].GetComponent<TextOption>().nodeID;
        GameObject.Find("Option 2").GetComponent<TextOption>().text = resultNode.GetComponent<TextNode>().Options[1].GetComponent<TextOption>().text;
        GameObject.Find("Option 2").GetComponent<TextOption>().relationshipEffect = resultNode.GetComponent<TextNode>().Options[1].GetComponent<TextOption>().relationshipEffect;

        GameObject.Find("Option 3").GetComponent<TextOption>().nodeID = resultNode.GetComponent<TextNode>().Options[2].GetComponent<TextOption>().nodeID;
        GameObject.Find("Option 3").GetComponent<TextOption>().text = resultNode.GetComponent<TextNode>().Options[2].GetComponent<TextOption>().text;
        GameObject.Find("Option 3").GetComponent<TextOption>().relationshipEffect = resultNode.GetComponent<TextNode>().Options[2].GetComponent<TextOption>().relationshipEffect;
    }

    /// <summary>
    /// should be called in the canvas once you choose this option as your response
    /// will create a new node
    /// </summary>
    public void AddPhoneNode()
    {

        UpdatePhoneOptions();
    }

    /// <summary>
    /// Will update the options you can choose from for new node
    /// </summary>
    private void UpdatePhoneOptions()
    {
        
    }
}
