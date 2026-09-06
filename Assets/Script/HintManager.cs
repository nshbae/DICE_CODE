using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class HintManager : MonoBehaviour
{
    public Button HintBut;
    public TMP_Text Text_timer;
    public Image Slider;

    public Animator Popup_controller;

    public float Hint_Time;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        HintBut.interactable = false;
        if (!MainManager.AM.isStageSelect)
        {
            timer = Hint_Time;
        }
        else if (!PlayerPrefs.HasKey("tutorial"))
        {
            PlayerPrefs.SetInt("tutorial", 1);
            showHint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            HintBut.interactable = true;
            Text_timer.enabled = false;
            this.enabled = false;
        }
        Text_timer.text = (int)(timer / 60) + ":" + ((int)(timer % 60) < 10 ? "0" + (int)(timer % 60) : (int)(timer % 60));
        Slider.fillAmount = 1f - (timer / Hint_Time);
    }

    public void showHint()
    {
        Popup_controller.SetBool("showing", true);
    }

    public void closeHint()
    {
        Popup_controller.SetBool("showing", false);
    }
    public void LoadLocale(string languageIdentifier)
    {
        LocaleIdentifier localeCode = new LocaleIdentifier(languageIdentifier);
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            Locale aLocale = LocalizationSettings.AvailableLocales.Locales[i];
            LocaleIdentifier anIdentifier = aLocale.Identifier;
            if (anIdentifier == localeCode)
            {
                LocalizationSettings.SelectedLocale = aLocale;
            }
        }
    }

    public void setKor()
    {
        LoadLocale("ko");
    }
    public void setEng()
    {
        LoadLocale("en");
    }

}
