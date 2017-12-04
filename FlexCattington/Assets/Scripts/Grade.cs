using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grade : MonoBehaviour {

    public Sprite happy;
    public Sprite sad;

    // Use this for initialization
    void Start () {
        int finalScore = (int)PlayerPrefs.GetFloat("score");

        if (finalScore >= 90)
        {
            GameObject.Find("Text").GetComponent<Text>().text = "A";
            GameObject.Find("Flex").GetComponent<Image>().sprite = happy;
        }
        else if (finalScore >= 80)
        {
            GameObject.Find("Text").GetComponent<Text>().text = "B";
            GameObject.Find("Flex").GetComponent<Image>().sprite = happy;
        }
        else if (finalScore >= 70)
        {
            GameObject.Find("Text").GetComponent<Text>().text = "C";
            GameObject.Find("Flex").GetComponent<Image>().sprite = sad;
        }
        else if (finalScore >= 60)
        {
            GameObject.Find("Text").GetComponent<Text>().text = "D";
            GameObject.Find("Flex").GetComponent<Image>().sprite = sad;
        }
        else
        {
            GameObject.Find("Text").GetComponent<Text>().text = "F, Really?";
            GameObject.Find("Flex").GetComponent<Image>().sprite = sad;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
