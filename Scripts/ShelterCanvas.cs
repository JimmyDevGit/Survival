using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShelterCanvas : MonoBehaviour
{
    public GameMan gameMan;
    public AudioManager audioManager;
    public Canvas notifiactionCanvas;
    public Canvas shelterCanvas;
    public Canvas mainCanvas;
    public TextMeshProUGUI notificationText;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void BuildRainCatcher()
    {
        notifiactionCanvas.enabled = true;
        audioManager.Play("Clave");
        if(gameMan.rainCatcherPlaced == false)
        {
            if(gameMan.trashBagInventory > 0)
            {
                if(gameMan.woodInventory > 0)
                {
                    gameMan.woodInventory -= 1;
                    gameMan.trashBagInventory -= 1;
                    gameMan.rainCatcherPlaced = true;
                    notificationText.text = "You built a rain catcher";
                    gameMan.Pos();
                    audioManager.Play("Craft");
                }
                else
                {
                    notificationText.text = "You don't have wood";
                    gameMan.Neg();
                }
            }
            else
            {
                notificationText.text = "You don't have a trash bag";
                gameMan.Neg();
            }
        }
        else
        {
            notificationText.text = "You already have a rain catcher";
            gameMan.Neg();
        }
    }
    public void BuildLeanTo()
    {
        if (gameMan.shelterType == 0)
        {
            gameMan.shelterType = 1;
            gameMan.shelterCondition = 50;
            gameMan.AddTime(1);
            audioManager.Play("Craft");
            notificationText.text = "You built a lean to";
            gameMan.Pos();
        }
        else
        {
            notificationText.text = "You already have a shelter";
            gameMan.Neg();
        }
        notifiactionCanvas.enabled = true;
        audioManager.Play("Clave");
        gameMan.UpdateStats();
    }
    public void BuildAFrame()
    {
        if (gameMan.shelterType == 0 || gameMan.shelterType == 1)
        {
            gameMan.shelterType = 2;
            gameMan.shelterCondition = 25;
            gameMan.AddTime(1);
            audioManager.Play("Craft");
            notificationText.text = "You built an A-Frame";
            gameMan.Pos();
        }
        else
        {
            notificationText.text = "You already have a shelter";
            gameMan.Neg();
        }
        notifiactionCanvas.enabled = true;
        audioManager.Play("Clave");
        gameMan.UpdateStats();
    }
    public void MaintainShelter()
    {
        if(gameMan.shelterType == 0)
        {
            notificationText.text = "You havn't built a shelter here";
            gameMan.Neg();
        }
        else if(gameMan.shelterType == 1)
        {
            if(gameMan.shelterCondition < 50)
            {
                if (gameMan.nightTime == true)
                {
                    if (gameMan.shelterCondition >= 40)
                    {
                        gameMan.shelterCondition = 50;
                    }
                    else if(gameMan.shelterCondition < 40)
                    {
                        gameMan.shelterCondition += 10;
                    }
                }
                else
                {
                    gameMan.shelterCondition = 50;
                }
                gameMan.AddTime(1);
                audioManager.Play("Craft");
                notificationText.text = "You improved your shelters condition";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "Your shelter is in the best possible condition";
                gameMan.Neg();
            }
        }
        else if (gameMan.shelterType == 2)
        {
            if(gameMan.shelterCondition < 100)
            {
                if(gameMan.nightTime == true)
                {
                    if (gameMan.shelterCondition > 90)
                    {
                        gameMan.shelterCondition = 100;
                    }
                    else
                    {
                        gameMan.shelterCondition += 10;
                    }
                }
                else
                {
                    if (gameMan.shelterCondition > 75)
                    {
                        gameMan.shelterCondition = 100;
                    }
                    else
                    {
                        gameMan.shelterCondition += 25;
                    }
                }
                gameMan.AddTime(1);
                audioManager.Play("Craft");
                notificationText.text = "You improved your shelters condition";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "Your shelter is in the best possible condition";
                gameMan.Neg();
            }
        }
        notifiactionCanvas.enabled = true;
        audioManager.Play("Clave");
        gameMan.UpdateStats();
    }
    public void Sleep1Hour()
    {
        audioManager.Play("Clave");
        gameMan.sleeping = true;
        gameMan.AddTime(1);
        audioManager.Play("Sleep");
        gameMan.sleeping = false;
        notifiactionCanvas.enabled = true;
        notificationText.text = "You slept 1 hour";
        gameMan.Pos();
        gameMan.UpdateStats();
    }
    public void Sleep3Hours()
    {
        audioManager.Play("Clave");
        gameMan.sleeping = true;
        gameMan.AddTime(3);
        audioManager.Play("Sleep");
        notifiactionCanvas.enabled = true;
        notificationText.text = "You slept 3 hours";
        gameMan.Pos();
        gameMan.sleeping = false;
        gameMan.UpdateStats();
    }
    public void Sleep6Hours()
    {
        audioManager.Play("Clave");
        gameMan.sleeping = true;
        gameMan.AddTime(6);
        audioManager.Play("Sleep");
        gameMan.sleeping = false;
        notifiactionCanvas.enabled = true;
        notificationText.text = "You slept 6 hours";
        gameMan.Pos();
        gameMan.UpdateStats();
    }
    public void BackButton()
    {
        audioManager.Play("ClaveLow");
        shelterCanvas.enabled = false;
        mainCanvas.enabled = true;
        mainCanvas.enabled = true;
    }
}
