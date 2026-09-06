using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct slotAns
{
    public List<slotValue> slotValues;
}

public class AnswerManager : MonoBehaviour
{
    public string NextSceneName;
    public bool isStageSelect;
    public int selectedStage;
    public List<string> StageName;

    public List<SlotManager> slots;
    public List<slotAns> answer;
    AudioSource sor;

    public float lerpSpeed;
    public float clearHeight;
    public Vector3 errorDist;
    public Animator mapAnim;
    public Material clearDiceMat;
    public GameObject clearParticleSystem;

    public GameObject camContainer;

    public bool isCorrect;
    public bool loadClicked;
    // Start is called before the first frame update
    void Awake()
    {
        SaveDataSet();
        selectedStage = -1;
        isCorrect = false;    
        loadClicked = false;
        sor = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (loadClicked)
        {
            if (mapAnim.enabled)
            {
                Vector3 pos = camContainer.transform.position;
                Quaternion rot = camContainer.transform.rotation;
                mapAnim.enabled = false;
                camContainer.transform.position = pos;
                camContainer.transform.rotation = rot;
                MainManager.DM.gameObject.GetComponent<MeshRenderer>().material = clearDiceMat;
            }
            lerpCam();
        }
    }

    public void lerpCam()
    {
        float diceYrot = MainManager.DM.gameObject.transform.rotation.eulerAngles.y;
        while (diceYrot < 0f)
        {
            diceYrot += 90f;
        }
        while (diceYrot > 90f)
        {
            diceYrot -= 90f;
        }
        Invoke("loadNextScene", 3f);
        camContainer.transform.position = Vector3.Lerp(camContainer.transform.position, MainManager.DM.gameObject.transform.position + Vector3.up * clearHeight + errorDist, lerpSpeed * Time.deltaTime);
        camContainer.transform.rotation = Quaternion.Lerp(camContainer.transform.rotation, Quaternion.Euler(Vector3.right * 34.18f + diceYrot * Vector3.up), lerpSpeed * Time.deltaTime * 1.2f);
    }

    public void loadNextScene()
    {
        if (!isStageSelect)
        {
            SceneManager.LoadScene(NextSceneName);
        }
        else
        {
            SceneManager.LoadScene(StageName[selectedStage]);
        }
    }

    // Update is called once per frame
    public void OnSlotValueChange()
    {
        if (!isStageSelect)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                for (int j = 0; j < answer[i].slotValues.Count; j++)
                {
                    if (slots[i].slotValue == answer[i].slotValues[j])
                    {
                        //Debug.Log("answer confirmed");
                        break;
                    }
                    else if (j == answer[i].slotValues.Count - 1)
                    {
                        isCorrect = false;
                        SetLed();
                        return;
                    }
                }
            }
            isCorrect = true;
            SetLed();
        }
        else if(isStageSelect)
        {
            for(int i = 0; i < StageName.Count; i++)
            {
                if (slots[i].slotValue != slotValue.empty && i != selectedStage)
                {
                    if (StageName[i] != "")
                    {
                        selectedStage = i;
                        isCorrect = true;
                        clearParticleSystem.SetActive(true);
                    }
                    else
                    {
                        selectedStage = -1;
                        isCorrect = false;
                        clearParticleSystem.SetActive(false);
                    }
                    for (int j = 0; j < StageName.Count; j++)
                    {
                        if (j != selectedStage)
                        {
                            slots[j].clearSlot(false);
                        }
                    }
                    break;
                }
                if (slots[i].slotValue == slotValue.empty && i == selectedStage)
                {
                    selectedStage = -1;
                    isCorrect = false;
                    clearParticleSystem.SetActive(false);
                }
            }
            SetLed();
        }
    }

    public void SetLed()
    {
        ledState color;
        if(!isStageSelect)
        {
            if (isCorrect)
            {
                color = ledState.green;
                clearParticleSystem.SetActive(true);
            }
            else
            {
                color = ledState.red;
                clearParticleSystem.SetActive(false);
            }

            if (slots.Count > 0 && slots[0].gameObject.GetComponentInChildren<LEDbehave>().ledState != color)
            {
                sor.Play();
            }

            foreach (SlotManager slot in slots)
            {
                slot.gameObject.GetComponentInChildren<LEDbehave>().UpdateLED(color);
            }
        }
        else if (isStageSelect)
        {
            sor.Play();
            for (int i=0;i<slots.Count;i++)
            {
                if (slots[i].slotValue != slotValue.empty)
                {
                    slots[i].gameObject.GetComponentInChildren<LEDbehave>().UpdateLED(ledState.green);
                }
                else if (StageName[i] == "")
                {
                    slots[i].gameObject.GetComponentInChildren<LEDbehave>().UpdateLED(ledState.off);
                }
                else
                {
                    slots[i].gameObject.GetComponentInChildren<LEDbehave>().UpdateLED(ledState.red);
                }
            }
        }
    }

    public void readyLoad()
    {
        MainManager.CM.cam_controller.SetBool("clear", true);
        loadClicked = true;
    }

    public void SaveDataSet()
    {
        if (!PlayerPrefs.HasKey("MaxVelocity"))
        {
            PlayerPrefs.SetFloat("MaxVelocity", 0.05f);
        }
        if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1f);
        }
    }
}
