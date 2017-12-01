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
        char[] separator = "!n".ToCharArray();
        string[] sections = readIn.Split(separator); //split based upon nodes
        foreach(string s in sections)
        {
            char[] separator1 = "!o".ToCharArray();
            string[] responses = s.ToString().Split(separator1);//split up section of conversation into node and options
            
            //first one will always be a node
            GameObject node = Instantiate(TextNode);
            TextNode nodeS = node.GetComponent<TextNode>();
            nodeS.Text = responses[0];
            //set options for this node
            for (int i = 1; i < responses.Length; i++)
            {
                //next however many are options to respond with

            }

            
            convo.AddNode(node);
        }
    }
}
