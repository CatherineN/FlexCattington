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
        //node.GetComponent<TextNode>().container = GameObject.Find("NPC Talk");

    }

    public GameObject AddOption(string text, GameObject parent, int destinationIndex = -1)
    {
        ////add destination node to list if it doesn't already exist -- was messing up due to the parent node being added after the options were added
        //if (!nodes.Contains(parent))
        //    nodes.Add(parent);

        GameObject option = Instantiate(optionPrefab, GameObject.Find("Canvas").transform);
        TextOption opt = option.GetComponent<TextOption>();

        //create an option object
        if (destinationIndex != -1)
        {
            opt.text = text;
            opt.nodeID = destinationIndex;
            //opt.resultNode = nodes[opt.nodeID];
        }
        return option;
    }

}
