using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOption : MonoBehaviour {

    public string text;//text to reply/do in response to the npc's text

    public bool isText;

    public GameObject resultNode; //where this specific option leads
    public int nodeID;//the ID/index of where the result node is located in the dialogue
    //private TextNode textScript;//script for the node that this option leads to

    public Sprite n;
    public Sprite g;
    public Sprite b;

    public int relationshipEffect;//how this option influences your score behind the scenes

    void Start()
    {
        if(isText == false)
        StartCoroutine(LateStart(.00001f));
    }

    // Use this for initialization
    void Initialize () {
        gameObject.GetComponentInChildren<Text>().text = text;
        resultNode = GameObject.Find("SceneManager").GetComponent<Dialogue>().nodes[0];
        ChangeNode();
    }

    //has to be a late start so that the list of nodes is populated before the method is called
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Initialize();
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("ID: " + nodeID);
        if (nodeID != -1 && isText == false)
            resultNode = GameObject.Find("SceneManager").GetComponent<Dialogue>().nodes[nodeID];
        else
            resultNode = null;
        //Debug.LogWarning(gameObject.name + "'s result: " + resultNode.GetComponent<TextNode>().text);
        if (isText == false)
            gameObject.GetComponentInChildren<Text>().text = text;
        
            
    }

    public void UpdateScore()
    {
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + relationshipEffect);
        if(isText == false)
        {
            switch (relationshipEffect)
            {
                case -10:
                    GameObject.Find("Chester J. Prick reactions").GetComponent<Image>().sprite = b;
                    break;
                case 0:
                    GameObject.Find("Chester J. Prick reactions").GetComponent<Image>().sprite = n;
                    break;
                case 10:
                    GameObject.Find("Chester J. Prick reactions").GetComponent<Image>().sprite = g;
                    break;
            }
        }
    }

    /// <summary>
    /// Should be called when this option is choosen in the dialogue tree
    /// Will edit the existing text to match the node in narration box
    /// </summary>
    public void ChangeNode()
    {
        if (resultNode == null)
        {
            GameObject.Find("Chester").AddComponent<FinalScore>();
            return;
        }
        resultNode.GetComponent<TextNode>().SetNPCText();
        UpdateOptions();
    }

    /// <summary>
    /// Will update the options you can choose from for new node
    /// </summary>
    private void UpdateOptions()
    {
        if(resultNode.GetComponent<TextNode>().Options.Count > 1)
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
        else if (resultNode.GetComponent<TextNode>().Options.Count == 1)
        {
            GameObject.Find("Option 1").SetActive(false);
            GameObject.Find("Option 3").SetActive(false);
            GameObject.Find("Option 2").GetComponent<TextOption>().text = "Finish your coffee";
            GameObject.Find("Option 2").GetComponent<TextOption>().nodeID = -1;
            GameObject.Find("Option 2").GetComponent<TextOption>().relationshipEffect = 0;
        }
        
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
