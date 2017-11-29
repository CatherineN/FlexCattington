using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public List<Text> Nodes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddNode(GameObject node)
    {
        //if the node is null we can skip adding it
        if (node == null)
            return;

        //Add the node to the list of nodes
        //Nodes.Add(node);

        //Give the node an ID
        //node.GetComponent<TextNode>().ID = Nodes.IndexOf(node);

    }

    public void AddOption(string text, GameObject parent, GameObject destination)
    {
        //add destination node to list if it doesn't already exist
        /*if (!Nodes.Contains(parent))
            Nodes.Add(parent);

        //add destination node to list if it doesn't already exist
        if (!Nodes.Contains(destination))
            Nodes.Add(destination);*/

        TextOption opt;


    }

}
