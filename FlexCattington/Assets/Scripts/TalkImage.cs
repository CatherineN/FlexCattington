using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkImage : MonoBehaviour {

    public List<Sprite> images;
    private int nodeCount = -1;
    private GameObject currentImage;

	// Use this for initialization
	void Start () {
        currentImage = GameObject.Find("speech bubble").transform.GetChild(0).gameObject;
        UpdateImage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Updates the count of which branch of dialogue we are on
    /// </summary>
    public void UpdateImage()
    {
        nodeCount++;
        if (nodeCount < images.Count)
            currentImage.GetComponent<Image>().sprite = images[nodeCount];
        else
            currentImage.transform.parent.gameObject.SetActive(false);
    }
}
