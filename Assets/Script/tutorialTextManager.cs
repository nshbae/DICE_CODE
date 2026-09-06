using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public enum tutState
{
    idle,
    beforeStart,
    progressing,
    end
}

public class tutorialTextManager : MonoBehaviour
{
    public tutState tutState;
    public GameObject panel;
    public int nowInd;
    public List<string> tutTexts;
    public TMP_Text tutTMP;
    public float timePerChar;
    public GameObject okBtn;

    public GameObject slider;
    public float maxSizeX;

    public float timer;
    public float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        tutState = tutState.idle;
        nowInd = 0;
        tutTMP.text = "환영합니다";
        //okBtn.SetActive(true);
        maxSizeX = slider.transform.localScale.x;
        slider.SetActive(false);

        if (!PlayerPrefs.HasKey("tutorialed"))
        {
            PlayerPrefs.SetInt("tutorialed", 1);

            tutState = tutState.beforeStart;
            nowInd = 0;
            panel.SetActive(true);
            tutTMP.text = "환영합니다";
            //okBtn.SetActive(true);
            slider.SetActive(false);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void clickOK()
    {
        if (tutState == tutState.end)
        {
            panel.SetActive(false);
        }
        else if (tutState==tutState.beforeStart)
        {
            tutState = tutState.progressing;
            Next();
        } else if (tutState == tutState.progressing)
        {
            Next();
        }
    }

    // Update is called once per frame
    public void Next()
    {
        if (okBtn.activeSelf)
        {
            //okBtn.SetActive(false);
        }

        tutTMP.text = tutTexts[nowInd];
        if (nowInd + 1 == tutTexts.Count)
        {
            tutState = tutState.end;
            //okBtn.SetActive(true);
        }
        else
        {
            nextTime = timePerChar * tutTexts[nowInd].Length;
            nowInd++;
        }
    }

    private void Update()
    {
        if(nextTime > 0 && tutState==tutState.progressing)
        {
            nextTime -= Time.deltaTime;
        }
        else if (tutState==tutState.progressing)
        {
            nextTime = 999f;
            Next();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            tutState = tutState.beforeStart;
            nowInd = 0;
            panel.SetActive(true);
            tutTMP.text = "환영합니다";
            //okBtn.SetActive(true);
            slider.SetActive(false);
        }
        if (tutState == tutState.progressing && nowInd > 0)
        {
            slider.SetActive(true);
            slider.transform.localScale = new Vector3(maxSizeX * nextTime/(timePerChar * tutTexts[nowInd-1].Length), slider.transform.localScale.y, slider.transform.localScale.z);
        }
        else if(tutState == tutState.progressing && slider.activeSelf)
        {
            slider.SetActive(false);
        }
    }
}
