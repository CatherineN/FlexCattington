using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {
    private int finalScore;

	// Use this for initialization
	void Start () {
        finalScore = (int)PlayerPrefs.GetFloat("score");

        if(finalScore >= 80)
        {
            GoodEnding();
        }
        else if (finalScore >= 50)
        {
            OkayEnding();
        }
        else
        {
            BadEnding();
        }
        CleanUp();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void CleanUp()
    {
        GameObject.Find("Charge's speech bubble").SetActive(false);
        GameObject.Find("Option 2").GetComponent<TextOption>().text = "Head home";

        //clicking option 2 which now says Head home, will take you to the grade screen
        Button b = GameObject.Find("Option 2").GetComponent<Button>();
        if(finalScore >= 80)
            b.onClick.AddListener(() => SceneManager.LoadScene("PhoneConvo"));
        else
            b.onClick.AddListener(() => SceneManager.LoadScene("Grade"));
    }

    /// <summary>
    /// Smooth moves there bud
    /// </summary>
    private void GoodEnding()
    {
        Debug.Log("good ending");
        GameObject.Find("NPC Talk").GetComponent<TextNode>().text = "The two linger, and it is pretty obvious that they want to spend more time with each other. As they finally say goodbye, they set up their next arrangement. A visit to a bookstore this coming Thursday afternoon. They smile and shake hands before parting ways. You can tell that both Chester and your charge have a giddy aura surrounding them. You beam to yourself. A smashing job! Flex Cattington will definitely give you a big thumbs up at this success!";
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    /// <summary>
    /// You are bad and you should feel bad
    /// </summary>
    private void BadEnding()
    {
        Debug.Log("bad ending");
        GameObject.Find("NPC Talk").GetComponent<TextNode>().text = "Chester harrumphs and stands abruptly. He announces to your charge that while it was nice meeting them, they were not quite what they were looking for. He shakes their hand coldly and then marches out the cafe. It’s quite clear that Chester won’t ever be contacting your charge again. You sure botched this one...you can feel Flex Cattington shaking his head at your feeble effort.";
        gameObject.GetComponent<LeavingScript>().enabled = true;
    }

    /// <summary>
    /// Perfectly Adequate
    /// </summary>
    private void OkayEnding()
    {
        Debug.Log("okay ending");
        GameObject.Find("NPC Talk").GetComponent<TextNode>().text = "The two both get up and take care of their cups before saying goodbye to each other. The two shake hands firmly and smile a bit. Chester says that they should get together again, whether for another date or as friends. Either way, there seems to be a rather friendly feeling in the air, so you’re off to a fair start. Flex Cattington would give you an approving, but underwhelming, nod.";
    }

    public void Reset()
    {
        SceneManager.LoadScene("Title");
    }
}
