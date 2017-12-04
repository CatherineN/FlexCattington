using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNode : MonoBehaviour {

    public string text; //what npc says

    public int ID = -1; //identification of the node

    public GameObject container; //will hold the text for the npc

    public List<GameObject> Options; //ways you can respond to the text

	// Use this for initialization
	void Awake () {
        if (gameObject.tag != "Phone")
            gameObject.GetComponentInChildren<Text>().text = text;
        else
            gameObject.GetComponent<PhoneTextMaker>().CalculateSpaceNeeded(text);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag != "Phone")
            gameObject.GetComponentInChildren<Text>().text = text;
        else
            gameObject.GetComponent<PhoneTextMaker>().CalculateSpaceNeeded(text);

    }

    public void SetNPCText()
    {
        //update current text node to reflect this node's values
        container.GetComponent<TextNode>().text = text;
        container.GetComponent<TextNode>().Options = Options;
    }

    
}
