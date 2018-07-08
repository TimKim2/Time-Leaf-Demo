using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckScore : MonoBehaviour
{
    public float fadeTime;
    public Color fadeColor = new Color(0, 0, 0, 1);

    public int checkTrue = 0; //완료된거 확인
    int trueScore = 0;
    int subTrue;

    public Sprite[] rank = new Sprite[6];

    GameObject Go;
    CheckChallenge checkChallenge;

    public Text txt;

    bool stop;

    float imgChangeDelay = 0.1f;
    float scoreChangeDelay = 0.3f;

    RectTransform tr;
    Image img;

    public void Score()
    {
        if(checkTrue >= 21)
        {
            img.sprite = rank[5];
        }

        else if(checkTrue >= 18)
        {
            img.sprite = rank[4];
        }

        else if(checkTrue >= 15)
        {
            img.sprite = rank[3];
        }

        else if(checkTrue >= 12)
        {
            img.sprite = rank[2];
        }

        else if(checkTrue >= 9)
        {
            img.sprite = rank[1];
        }

        else
        {
            img.sprite = rank[0];
        }

        txt.text = checkTrue.ToString();
    }

	void Start ()
    {
        FSLocator.fadeDisplayer.FadeIn(fadeColor, fadeTime);

        Go = GameObject.Find("CheckChallenge");

        if(Go)
        {
            checkChallenge = Go.GetComponent<CheckChallenge>();

            Destroy(checkChallenge.gameObject);
        }

        img = GetComponent<Image>();
        tr = GetComponent<RectTransform>();

        StartCoroutine(ScoreMachine());
        StartCoroutine(TrueScore());
	}
    
    IEnumerator ScoreMachine()
    {
        int i = 0;

        while(true)
        {
            img.sprite = rank[i];

            yield return new WaitForSeconds(imgChangeDelay);

            i++;

            if (i > 5)
                i = 0;
        }
    }

    IEnumerator TrueScore()
    {
        while (true)
        {
            txt.text = trueScore.ToString();

            yield return new WaitForSeconds(scoreChangeDelay);

            trueScore++;
        }
    }

    void Update()
    {
        subTrue = checkTrue - trueScore;

        if (subTrue >= 4 && subTrue < 6)
        {
            imgChangeDelay = 0.3f;
            scoreChangeDelay = 0.6f;
        }

        else if(subTrue >= 2 && subTrue < 4)
        {
            imgChangeDelay = 0.7f;
            scoreChangeDelay = 0.8f;
        }

        else if(subTrue == 1)
        {
            imgChangeDelay = 1f;
            scoreChangeDelay = 1f;
        }

        else if(subTrue == 0 && !stop)
        {
            stop = true;

            StopAllCoroutines();
            Score();

            StartCoroutine(LoadMainScene());
            StartCoroutine(Size());
        }
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(2.0f);

        FSLocator.fadeDisplayer.FadeOut(fadeColor, 2.5f);

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("MainScene");
    }

    IEnumerator Size()
    {
        yield return new WaitForSeconds(1.0f);

        tr.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
}
