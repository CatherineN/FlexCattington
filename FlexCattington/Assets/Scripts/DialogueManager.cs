using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Manages the dialogues in this scene
/// Eventually want it to read in content from text file instead of hard-coding
/// </summary>
public class DialogueManager : MonoBehaviour {

    public string textFilePath;
    public GameObject TextNode;
    private Dialogue convo;//holds all possible text content and responses
    private static string readIn;//holds all the read in file

    // Use this for initialization
    void Start () {
        convo = GetComponent<Dialogue>();
        Debug.Log(convo.gameObject.name);
        ReadString(textFilePath);
        CreateConversation();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static void ReadString(string textFilePath)
    {
        string path = "Assets/Resources/" + textFilePath;

        //Read the text directly from the text file
        StreamReader reader = new StreamReader(path);
        readIn = reader.ReadToEnd();
        reader.Close();//close the stream when done
    }

    private void CreateConversation()//last node has no options so need to resolve that
    {
        string[] sections = readIn.Split(new string[] { "!n" }, System.StringSplitOptions.None); //split based upon nodes
        foreach(string s in sections)
        {
            Debug.Log("Node number: " + s);
            string[] responses = s.ToString().Split(new string[] {"!o"}, System.StringSplitOptions.None);//split up section of conversation into node and options
            //first one will always be a node
            GameObject node = Instantiate(TextNode, GameObject.Find("Canvas").transform);
            TextNode nodeS = node.GetComponent<TextNode>();
            
            nodeS.text = responses[0];
            if (responses.Length > 1)
            {
                //set options for this node
                for (int i = 1; i < responses.Length; i++)
                {
                    //determine if good, bad, or neutral and set relationship effect variable appropriately
                    string[] score = responses[i].ToString().Split(new string[] { "!s", "!i" }, System.StringSplitOptions.None);//split up response based upon what is response and what is score

                    Debug.Log("response number: " + i + ", response: " + score[0] + " score: " + score[1] + " result node index: " + score[2]);
                    Debug.LogWarning(int.Parse(score[1]));

                    //next however many are options to respond with
                    nodeS.Options.Add(convo.AddOption(score[0], node, int.Parse(score[2])));//used IDs as a way to point to destination even if it doesn't exist yet 
                    //Debug.LogWarning(nodeS.Options.ToString());

                    //Debug.LogWarning(int.Parse(score[1]));
                    //Debug.LogWarning(convo.nodes.Count - 1);
                    //set value of score effect for the option
                    nodeS.Options[nodeS.Options.Count-1].GetComponent<TextOption>().relationshipEffect = int.Parse(score[1]);//set the score effect for each option
                }
            }
            else
            {
                //create end option
                nodeS.Options.Add(convo.AddOption("Finish Coffee", node));//used IDs as a way to point to destination even if it doesn't exist yet 
            }
            
            convo.AddNode(node);
            Debug.LogWarning("triggered");
        }
    }
}
