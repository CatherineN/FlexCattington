using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {
    private int finalScore;

	// Use this for initialization
	void Start () {
        finalScore = PlayerPrefs.GetInt("score");

        if(finalScore == 120)
        {
            GoodEnding();
        }
        else if (finalScore >= 100)
        {
            OkayEnding();
        }
        else
        {
            BadEnding();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Smooth moves there bud
    /// </summary>
    private void GoodEnding()
    {
        Debug.Log("good ending");
        GameObject.Find("End").transform.Find("Summary Box").GetComponentInChildren<Text>().text = "The two linger, and it is quite clear they want to spend more time with each other. As they finally say goodbyes, they set up their next arrangement. A walk in the park this coming Thursday. They smile and hug before parting ways. You can tell that both Dave and your charge have a giddy aura surrounding them. You beam at your partner. A smashing job! Flex Cattington will definitely give you a big thumbs up at this success!";
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    /// <summary>
    /// You are bad and you should feel bad
    /// </summary>
    private void BadEnding()
    {
        Debug.Log("bad ending");
        GameObject.Find("End").transform.Find("Summary Box").GetComponentInChildren<Text>().text = "Dave gets up rather hurriedly, maybe in the hopes of escaping soon. The two awkwardly exchange goodbyes, with Dave giving a noncommittal “Maybe I’ll see you again” before briskly heading to the door. That was, to say the least, a failure. Flex Cattington will most definitely be unimpressed.";
        gameObject.GetComponent<LeavingScript>().enabled = true;
    }

    /// <summary>
    /// Perfectly Adequate
    /// </summary>
    private void OkayEnding()
    {
        Debug.Log("okay ending");
        GameObject.Find("End").transform.Find("Summary Box").GetComponentInChildren<Text>().text = "The two both get up and take care of their cups before saying goodbye to each other. The two shake hands firmly and smile a bit. Dave says that they should get together again, whether for another date or as friends. Either way, there seems to be a rather friendly feeling in the air, so you’re off to a fair start. Flex Cattington would give you an approving, but underwhelming, nod.";
    }

    public void Reset()
    {
        SceneManager.LoadScene("Instructions");
    }
}
