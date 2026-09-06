using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text title;
    public Animator PauseAnimator;
    public Slider diceSpeedSlider;
    public Slider masterVolume;
    public static AudioListener AL;

    // Start is called before the first frame update
    public void Start()
    {
        //diceSpeedSlider.value = PlayerPrefs.GetFloat("MaxVelocity");
        AL = Camera.main.GetComponent<AudioListener>();
        string temp = "";
        if (LocalizationSettings.SelectedLocale.name == "en")
        {
            temp += "Stage";
        }
        else
        {
            temp += "스테이지";
        }
        temp += " " + SceneManager.GetActiveScene().name.Substring(0, 2);
        title.text = temp;
    }

    public void OnEnable()
    {
        diceSpeedSlider.value = PlayerPrefs.GetFloat("MaxVelocity");
        masterVolume.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    public void Pause()
    {
        PauseAnimator.SetBool("isPaused", true);
    }
    public void Resume()
    {
        PauseAnimator.SetBool("isPaused", false);
    }
    public void Home()
    {
        SceneManager.LoadScene("00.Start");
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetMaxTorque()
    {
        PlayerPrefs.SetFloat("MaxVelocity", diceSpeedSlider.value);
    }
    public void SetMasterVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume.value);
        float volume = AudioListener.volume;
        volume = masterVolume.value;
        AudioListener.volume = volume;
    }

    // Update is called once per frame
    public void quit()
    {
        Application.Quit();
    }
}
