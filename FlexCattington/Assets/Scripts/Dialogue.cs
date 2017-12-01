using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public List<GameObject> nodes;
    public GameObject optionPrefab;

	// Use this for initialization
	void Awake () {
        nodes = new List<GameObject>(); 
	}
	
	// Update is called once per frame
	void Update () {

    }

    //public List<GameObject> Nodes { get { return nodes; } set { nodes = value; } }

    public void AddNode(GameObject node)
    {
        //if the node is null we can skip adding it
        if (node == null)
            return;

        //Add the node to the list of nodes
        nodes.Add(node);

        //Give the node an ID
        node.GetComponent<TextNode>().ID = nodes.IndexOf(node);

    }

    public GameObject AddOption(string text, GameObject parent, GameObject destination)
    {
        //add destination node to list if it doesn't already exist
        if (!nodes.Contains(parent))
            nodes.Add(parent);

        //add destination node to list if it doesn't already exist
        if (!nodes.Contains(destination))
            nodes.Add(destination);

        GameObject option = Instantiate(optionPrefab);
        TextOption opt = option.GetComponent<TextOption>();

        //create an option object
        if (destination == null)
        {
            opt.text = text;
            opt.resultNode = destination;
        }
        return option;
    }

}
