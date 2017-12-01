using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public List<GameObject> Nodes;
    public GameObject optionPrefab;

	// Use this for initialization
	void Start () {
        Nodes = new List<GameObject>();
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
        Nodes.Add(node);

        //Give the node an ID
        node.GetComponent<TextNode>().ID = Nodes.IndexOf(node);

    }

    public GameObject AddOption(string text, GameObject parent, GameObject destination)
    {
        Debug.Log(parent.name);
        Debug.Log(Nodes.Count);
        //add destination node to list if it doesn't already exist
        if (!Nodes.Contains(parent))
            Nodes.Add(parent);

        //add destination node to list if it doesn't already exist
        if (!Nodes.Contains(destination))
            Nodes.Add(destination);

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
