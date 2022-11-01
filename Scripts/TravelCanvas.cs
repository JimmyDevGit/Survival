using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TravelCanvas : MonoBehaviour
{
    public GameMan gameMan;
    public AudioManager audioManager;
    public Canvas travelCanvas;
    public Canvas mainCanvas;
    public Canvas notificationCanvas;

    public TextMeshProUGUI notificationText;
    public TextMeshProUGUI travel1Text;
    public TextMeshProUGUI travel2Text;
    public TextMeshProUGUI t1Distance;
    public TextMeshProUGUI t2Distance;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void GenerateTraveLocations()
    {
        gameMan.travelLocations1 = Random.Range(1, 10);
        gameMan.travelLocations1Distance = Random.Range(2, 8);
        if(Random.Range(0,2) == 1)
        {
            gameMan.travelLocations1Hidden = true;
        }
        else
        {
            gameMan.travelLocations1Hidden = false;
        }
        gameMan.travelLocations2 = Random.Range(1, 10);
        gameMan.travelLocations2Distance = Random.Range(2, 8);
        if (Random.Range(0, 2) == 1)
        {
            gameMan.travelLocations2Hidden = true;
        }
        else
        {
            gameMan.travelLocations2Hidden = false;
        }
        gameMan.SavePlayer();
    }
    public void SetTravelLocations()
    {
        if (gameMan.travelLocations1Hidden == true || gameMan.nightTime == true)
        {
            travel1Text.text = "???";
            t1Distance.text = "?hr";
        }
        else if(gameMan.travelLocations1Hidden == false)
        {
            travel1Text.text = gameMan.location[gameMan.travelLocations1];
            t1Distance.text = gameMan.travelLocations1Distance + "hr";
        }
        if (gameMan.travelLocations2Hidden == true || gameMan.nightTime == true)
        {
            travel2Text.text = "???";
            t2Distance.text = "?hr";
        }
        else if (gameMan.travelLocations2Hidden == false)
        {
            travel2Text.text = gameMan.location[gameMan.travelLocations2];
            t2Distance.text = gameMan.travelLocations2Distance + "hr";
        }
    }
    public void TravelButton1()
    {
        audioManager.Play("Clave");
        if (gameMan.sickness > 0)
        {
            notificationCanvas.enabled = true;
            notificationText.text = "You can't travel when you're sick";
            gameMan.Neg();
        }
        else
        {
            if (gameMan.currentWeight <= gameMan.maxWeight)
            {
                gameMan.locationString = gameMan.location[gameMan.travelLocations1];
                travelCanvas.enabled = false;
                mainCanvas.enabled = true;
                notificationCanvas.enabled = true;
                notificationText.text = "You traveled to a " + gameMan.location[gameMan.travelLocations1];
                gameMan.Pos();
                gameMan.AddTime(gameMan.travelLocations1Distance);
                audioManager.Play("Travel");
                gameMan.locationNumber = gameMan.travelLocations1;
                gameMan.SetBackgrounds();
                ResetOnTravel();
               
            }
            else
            {
                notificationCanvas.enabled = true;
                notificationText.text = "You're too encumbered to travel";
                gameMan.Neg();
            }
        }
    }
    public void TravelButton2()
    {
        audioManager.Play("Clave");
        if (gameMan.sickness > 0)
        {
            notificationCanvas.enabled = true;
            notificationText.text = "You can't travel when you're sick";
            gameMan.Neg();
        }
        else
        {
            if (gameMan.currentWeight <= gameMan.maxWeight)
            {
                gameMan.locationString = gameMan.location[gameMan.travelLocations2];
                travelCanvas.enabled = false;
                mainCanvas.enabled = true;
                notificationCanvas.enabled = true;
                notificationText.text = "You traveled to a " + gameMan.location[gameMan.travelLocations2];
                gameMan.Pos();
                gameMan.AddTime(gameMan.travelLocations2Distance);
                audioManager.Play("Travel");
                gameMan.locationNumber = gameMan.travelLocations2;
                gameMan.SetBackgrounds();
                ResetOnTravel();
                
            }
            else
            {
                notificationCanvas.enabled = true;
                notificationText.text = "You're too encumbered to travel";
                gameMan.Neg();
            }
        }
    }
    public void ResetOnTravel()
    {
        //Wipe save data for new location
        gameMan.puddleInventory = 0;
        gameMan.exploreAreaCount = 0;
        gameMan.gatherWoodCount = 0;
        gameMan.snareTrap = 0;
        gameMan.spikeTrap = 0;
        gameMan.snarePlaced = false;
        gameMan.spikePlaced = false;
        gameMan.rainCatcherPlaced = false;
        gameMan.exploreArea100 = false;
        gameMan.gatherWood100 = false;
        gameMan.shelterType = 0;
        gameMan.shelterCondition = 0;
        gameMan.travelCount++;
        GenerateTraveLocations();
        notificationCanvas.enabled = true;
        notificationText.text = "You arrived at a " + gameMan.locationString;
        gameMan.Pos();
        gameMan.UpdateStats();
    }
    public void BackButton()
    {
        audioManager.Play("ClaveLow");
        travelCanvas.enabled = false;
        mainCanvas.enabled = true;
    }
}
