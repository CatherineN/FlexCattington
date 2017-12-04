using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMessageManager : MonoBehaviour
{
    public GameObject parent; // script this is attatched to
    public GameObject outgoing; // outgoing (blue) message prefab
    public GameObject incomimng; // incoming (grey) message prefab
    public GameObject thought; // potential message
    public Transform canvas;
    public GameObject waiting;
    public GameObject nextButton;

    private float totalHeight = 0.0f; // total height occupied by messages and buffer
    private float heightBuffer = 5.0f; // space between texts
    private float heightMax = 454.4f; // phone screen height
    private float top; // top of the convo
    private int count = 0;


	// Use this for initialization
	void Start ()
    {
        // save the top
        top = parent.transform.position.y;
        /*
        // make 10 messages
		for(int i = 0; i < 5; i++)
        {
            // spawn a blue message
            GameObject message1 = Instantiate(outgoing, parent.transform);
            PhoneTextMaker maker1 = message1.GetComponent<PhoneTextMaker>();
            RectTransform rect1 = message1.GetComponent<RectTransform>();

            // set the vertical position of the message
            rect1.localPosition = new Vector3(rect1.localPosition.x, -totalHeight, rect1.localPosition.z);

            // add this message's height to totalHeight
            totalHeight += maker1.heightDetermined + heightBuffer;

            // spawn a grey message
            GameObject message2 = Instantiate(incomimng, parent.transform);
            PhoneTextMaker maker2 = message2.GetComponent<PhoneTextMaker>();
            RectTransform rect2 = message2.GetComponent<RectTransform>();

            // set the vertical position of the message
            rect2.localPosition = new Vector3(rect2.localPosition.x, -totalHeight, rect2.localPosition.z);

            // add this message's height to totalHeight
            totalHeight += maker2.heightDetermined + heightBuffer;
        }*/
        GameObject node1 = Instantiate(incomimng, parent.transform);
        PhoneTextMaker maker1 = node1.GetComponent<PhoneTextMaker>();
        RectTransform rect1 = node1.GetComponent<RectTransform>();
        TextDialogueManager t = GameObject.Find("SceneManager").GetComponent<TextDialogueManager>();
        maker1.CalculateSpaceNeeded(t.nodes[0].text);
        rect1.localPosition = new Vector3(rect1.localPosition.x, -totalHeight - (maker1.heightDetermined * 0.5f), rect1.localPosition.z);
        totalHeight += maker1.heightDetermined + heightBuffer;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // don't analyze clicks when the title card is up
        if (GameObject.Find("TitleCard") != null)
            return;
        else if(count == 0)
        {
            MakeThoughts(GameObject.Find("SceneManager").GetComponent<TextDialogueManager>().nodes[0].options);
            count++;
        }
        // check for scrolling
        if (Input.mouseScrollDelta.y != 0 && totalHeight > heightMax)
        {
            // scroll to the new position
            parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + (-Input.mouseScrollDelta.y * 15.0f), parent.transform.position.z);

            // check if we went too far up
            if (parent.transform.position.y < top)
                parent.transform.position = new Vector3(parent.transform.position.x, top, parent.transform.position.z);

            // check if we went too far down
            else if(parent.transform.position.y > top + totalHeight - heightMax)
                parent.transform.position = new Vector3(parent.transform.position.x, top + totalHeight - heightMax, parent.transform.position.z);
        }
	}

    public void MakeThoughts(List<Option> opts)
    {
        if (opts.Count == 0)
        {
            nextButton.SetActive(true);
            return;
        }
        for (int i = 0; i < opts.Count; i++)
        {
            GameObject test = Instantiate(thought, canvas);
            test.GetComponent<PhoneTextMaker>().CalculateSpaceNeeded(opts[i].text);
            test.GetComponent<RectTransform>().localScale = new Vector3(2.0f, 2.0f, 2.0f);
            test.GetComponent<TextThoughtMovement>().SetTime(Random.Range(0, 6));
            test.GetComponent<TextOption>().relationshipEffect = opts[i].scoreEffect;
            test.GetComponent<TextOption>().nodeID = opts[i].resultID;
            test.GetComponent<TextOption>().text = opts[i].text;
        }
    }

    public void AddMessage(string t)
    {
        GameObject node1 = Instantiate(outgoing, parent.transform);
        PhoneTextMaker maker1 = node1.GetComponent<PhoneTextMaker>();
        RectTransform rect1 = node1.GetComponent<RectTransform>();
        maker1.CalculateSpaceNeeded(t);
        rect1.localPosition = new Vector3(rect1.localPosition.x, -totalHeight - (maker1.heightDetermined * 0.5f), rect1.localPosition.z);
        totalHeight += maker1.heightDetermined + heightBuffer;
    }

    public IEnumerator Typing(TextOption opt)
    {
        
        GameObject node1 = Instantiate(incomimng, parent.transform);
        PhoneTextMaker maker1 = node1.GetComponent<PhoneTextMaker>();
        RectTransform rect1 = node1.GetComponent<RectTransform>();
        maker1.CalculateSpaceNeeded(". . .");
        rect1.localPosition = new Vector3(rect1.localPosition.x, -totalHeight - (maker1.heightDetermined * 0.5f), rect1.localPosition.z);
        totalHeight += maker1.heightDetermined + heightBuffer;

        

        yield return new WaitForSeconds(1.5f);

        totalHeight -= maker1.heightDetermined + heightBuffer;
        Destroy(node1);

        GameObject node2 = Instantiate(incomimng, parent.transform);
        PhoneTextMaker maker2 = node2.GetComponent<PhoneTextMaker>();
        RectTransform rect2 = node2.GetComponent<RectTransform>();
        TextDialogueManager t = GameObject.Find("SceneManager").GetComponent<TextDialogueManager>();
        maker2.CalculateSpaceNeeded(t.nodes[opt.nodeID].text);
        rect2.localPosition = new Vector3(rect2.localPosition.x, -totalHeight - (maker2.heightDetermined * 0.5f), rect2.localPosition.z);
        totalHeight += maker2.heightDetermined + heightBuffer;

        MakeThoughts(t.nodes[opt.nodeID].options);
    }
}
