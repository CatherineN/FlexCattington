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
        convo = new Dialogue();
        ReadString(textFilePath);
        CreateConversation();
        Debug.Log(convo.Nodes.ToString());
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

    private void CreateConversation()
    {
        string[] sections = readIn.Split(new string[] { "!n" }, System.StringSplitOptions.None); //split based upon nodes
        foreach(string s in sections)
        {
            Debug.Log("Node number: " + s);
            string[] responses = s.ToString().Split(new string[] {"!o"}, System.StringSplitOptions.None);//split up section of conversation into node and options
            //first one will always be a node
            GameObject node = Instantiate(TextNode);
            TextNode nodeS = node.GetComponent<TextNode>();
            
            nodeS.Text = responses[0];
            if (responses.Length >= 1)
            {
                //set options for this node
                for (int i = 1; i < responses.Length; i++)
                {
                    Debug.Log("response number: " + i);
                    Debug.Log("parent node: " + node.name);
                    //next however many are options to respond with
                    nodeS.Options.Add(convo.AddOption(responses[i], node, null));//need to determine a way to point to destination even if it doesn't exist yet, ID?

                    //nodeS.Options.Add();//need to somehow get the Option gameobject
                }
            }
            
            convo.AddNode(node);
        }
    }
}
