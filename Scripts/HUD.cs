using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameMan gameMan;
    public AudioManager audioManager;
    public TextMeshProUGUI locationText;
    public TextMeshProUGUI daysSurvived;
    public Slider hungerSlider;
    public TextMeshProUGUI hungerText;
    public Slider hydrationSlider;
    public TextMeshProUGUI hydrationText;
    public Slider conditionSlider;
    public TextMeshProUGUI conditionText;
    public Slider bodyheatSlider;
    public TextMeshProUGUI bodyheatText;
    public Image muteCross;
    public Image muteMusicCross;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void SetMaxCondition(float condition)
    {
        conditionSlider.maxValue = condition;
        conditionSlider.value = condition;
        conditionText.text = condition.ToString();
    }
    public void SetCondition(float condition)
    {
        conditionSlider.value = condition;
        conditionText.text = condition.ToString();
    }
    public void SetMaxHydration(float hydration)
    {
        hydrationSlider.maxValue = hydration;
        hydrationSlider.value = hydration;
        hydrationText.text = hydration.ToString();
    }
    public void SetHydration(float hydration)
    {
        hydrationSlider.value = hydration;
        hydrationText.text = hydration.ToString();
    }
    public void SetMaxHunger(float hunger)
    {
        hungerSlider.maxValue = hunger;
        hungerSlider.value = hunger;
        hungerText.text = hunger.ToString();
    }
    public void SetHunger(float hunger)
    {
        hungerSlider.value = hunger;
        hungerText.text = hunger.ToString();
    }
    public void SetMaxBodyheat(float bodyheat)
    {
        bodyheatSlider.maxValue = bodyheat;
        bodyheatSlider.value = bodyheat;
        bodyheatText.text = bodyheat.ToString();
    }
    public void SetBodyheat(float bodyheat)
    {
        bodyheatSlider.value = bodyheat;
        bodyheatText.text = bodyheat.ToString();
    }
    public void SetLocation()
    {
        locationText.text = gameMan.locationString;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        gameMan.StopAllSounds();
        audioManager.mute = false;
    }
    public void Mute()
    {
        if(gameMan.mute == false)
        {
            gameMan.mute = true;
            muteCross.enabled = true;
            audioManager.Stop("DayBackgroundSounds");
            audioManager.Stop("NightBackgroundSounds");
            audioManager.mute = true;
        }
        else
        {
            gameMan.mute = false;
            audioManager.mute = false;
            muteCross.enabled = false;
            gameMan.unmute = true;
            gameMan.UpdateStats();
        }
    }
    public void MuteMusic()
    {
        if(gameMan.muteMusic == false)
        {
            gameMan.BGM = 4;
            audioManager.Stop("BadBGM");
            audioManager.Stop("MediumBGM");
            audioManager.Stop("GoodBGM");
            gameMan.muteMusic = true;
            muteMusicCross.enabled = true;
            gameMan.UpdateStats();
        }
        else
        {
            gameMan.BGM = 5;
            gameMan.muteMusic = false;
            muteMusicCross.enabled = false;
            gameMan.UpdateStats();
        }
    }
}
