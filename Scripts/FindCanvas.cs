using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FindCanvas : MonoBehaviour
{
    public Canvas findCanvas;
    public Canvas mainCanvas;
    public Canvas notificationCanvas;
    public GameMan gameMan;
    public AudioManager audioManager;
    public TextMeshProUGUI notificationText;
    private int randomExploreArea;
    private int randomGatherWood;

    public Button exploreAreaButton;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void BackButton()
    {
        findCanvas.enabled = false;
        mainCanvas.enabled = true;
        gameMan.UpdateStats();
        audioManager.Play("ClaveLow");
    }
    public void ExploreArea()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.exploreAreaCount >= Random.Range(2, 6))
        {
            gameMan.exploreArea100 = true;
        }
        if (gameMan.exploreArea100 == false)
        {
            if(gameMan.locationString != "crash site")
            {
                if (gameMan.nightTime == false)
                {
                    //Lowered for debugging
                    randomExploreArea = Random.Range(0, 12);
                }
                if (gameMan.nightTime == true)
                {
                    //lowered for debugging
                    randomExploreArea = Random.Range(0, 8);
                }
                if (randomExploreArea == 0 && gameMan.puddleInventory < 2)
                {
                    notificationText.text = "You found a puddle";
                    gameMan.Pos();
                    gameMan.puddleInventory += 1;
                }
                else if (randomExploreArea == 1)
                {
                    notificationText.text = "You found bugs";
                    gameMan.Pos();
                    gameMan.bugsInventory += 1;
                }
                else if (randomExploreArea == 2)
                {
                    notificationText.text = "You found unknown berries";
                    gameMan.Pos();
                    gameMan.unknownBerriesInventory += 1;
                }
                else if (randomExploreArea == 3)
                {
                    notificationText.text = "You found edible berries";
                    gameMan.Pos();
                    gameMan.edibleBerriesInventory += 1;
                }
                else if(randomExploreArea == 4)
                {
                    notificationText.text = "You found a vine";
                    gameMan.Pos();
                    gameMan.vineInventory += 1;
                }
                else
                {
                    notificationText.text = "You found nothing";
                    gameMan.Neg();
                }
            }
            else
            {
                randomExploreArea = Random.Range(0, 10);
                if (randomExploreArea == 0)
                {
                    notificationText.text = "You found matches";
                    gameMan.Pos();
                    gameMan.matchesInventory += 5;
                }
                else if (randomExploreArea == 1)
                {
                    notificationText.text = "You found a trash bag";
                    gameMan.Pos();
                    gameMan.trashBagInventory += 1;
                }
                else if (randomExploreArea == 2)
                {
                    notificationText.text = "You found cloth";
                    gameMan.Pos();
                    gameMan.clothInventory += 1;
                }
                else if (randomExploreArea == 3)
                {
                    notificationText.text = "You found a map";
                    gameMan.Pos();
                    gameMan.mapInventory += 1;
                }
                else if (randomExploreArea == 4)
                {
                    notificationText.text = "You found a cable";
                    gameMan.Pos();
                    gameMan.cablesInventory += 1;
                }
                else
                {
                    notificationText.text = "You found nothing";
                    gameMan.Neg();
                }
            }
            gameMan.AddTime(1);
            audioManager.Play("Explore");
        }
        else
        {
            notificationText.text = "You've already explored the area";
            gameMan.Neg();
        }
        gameMan.exploreAreaCount++;
        gameMan.SavePlayer();
    }
    public void GatherWood()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.gatherWoodCount >= Random.Range(3, 8))
        {
            gameMan.gatherWood100 = true;
        }
        //Checks how many times I've searched for wood already
        if (gameMan.gatherWood100 == false)
        {
            int gatherWoodModifier;
            if(gameMan.locationString == gameMan.location[0] || gameMan.locationString == gameMan.location[1] || gameMan.locationString == gameMan.location[2] || gameMan.locationString == gameMan.location[3] || gameMan.locationString == gameMan.location[4])
            {
                gatherWoodModifier = 10;
            }
            else
            {
                gatherWoodModifier = 5;
            }
            if(gameMan.nightTime == true)
            {
                gatherWoodModifier = gatherWoodModifier * 2;
            }
            if(gameMan.axeInventory > 0)
            {
                gatherWoodModifier = (int)gatherWoodModifier / 2;
            }
            if(gatherWoodModifier < 3)
            {
                gatherWoodModifier = 3;
            }
            randomGatherWood = Random.Range(0, gatherWoodModifier);
            if (randomGatherWood == 0)
            {
                notificationText.text = "You found 1 Wood";
                gameMan.Pos();
                gameMan.woodInventory += 1;
                gameMan.SavePlayer();
            }
            else if (randomGatherWood == 1)
            {
                notificationText.text = "You found 2 Wood";
                gameMan.Pos();
                gameMan.woodInventory += 2;
                gameMan.SavePlayer();
            }
            else if (randomGatherWood == 2)
            {
                notificationText.text = "You found 3 Wood";
                gameMan.Pos();
                gameMan.woodInventory += 3;
                gameMan.SavePlayer();
            }
            else if (randomGatherWood == 3)
            {
                notificationText.text = "You found 6 Wood";
                gameMan.Pos();
                gameMan.woodInventory += 6;
                gameMan.SavePlayer();
            }
            else
            {
                notificationText.text = "You couldn't find any wood";
                gameMan.Neg();
            }
            gameMan.AddTime(1);
            audioManager.Play("GatherWood");
        }
        else
        {
            notificationText.text = "You've already searched this area for wood";
            gameMan.Neg();
        }
        gameMan.gatherWoodCount++;
        gameMan.SavePlayer();
    }
    public void FillWater()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.rainCatcherPlaced == true)
        {
            gameMan.UpdateStats();
            if (gameMan.locationString != gameMan.location[5] && gameMan.locationString != gameMan.location[6] && gameMan.locationString != gameMan.location[9] && gameMan.puddleInventory <= 0 && gameMan.raining == false)
            {
                notificationText.text = "There's no rain to collect";
                gameMan.Neg();
            }
            else if (gameMan.raining == true)
            {
                if (gameMan.emptyWaterBottlesInventory > 0)
                {
                    notificationText.text = "You collected clean water from the rain catcher";
                    gameMan.Pos();
                    gameMan.UpdateStats();
                    audioManager.Play("FillWater");
                    gameMan.emptyWaterBottlesInventory -= 1;
                    gameMan.cleanWaterInventory += 1;
                }
                else
                {
                    notificationText.text = "You have no empty waterbottles to fill";
                    gameMan.Neg();
                }
            }
            else
            {
                WaterCheck();
            }
        }
        else
        {
            WaterCheck();
        }
    }
    private void WaterCheck()
    {
        //Checks if in location with body of water
        if (gameMan.locationString == gameMan.location[5] || gameMan.locationString == gameMan.location[6] || gameMan.locationString == gameMan.location[9] || gameMan.puddleInventory > 0)
        {
            if (gameMan.emptyWaterBottlesInventory > 0)
            {
                audioManager.Play("FillWater");
                if (gameMan.puddleInventory > 0)
                {
                    gameMan.puddleInventory -= 1;
                    gameMan.nonPotableWaterInventory += 1;
                    gameMan.emptyWaterBottlesInventory -= 1;
                    notificationText.text = "You filled your water bottle from a puddle";
                    gameMan.Pos();
                    gameMan.UpdateStats();
                }
                else
                {
                    gameMan.nonPotableWaterInventory += 1;
                    gameMan.emptyWaterBottlesInventory -= 1;
                    CheckFillWaterLocation();
                    gameMan.UpdateStats();
                }
            }
            else
            {
                notificationText.text = "You have no empty waterbottles to fill";
                gameMan.Neg();
            }
        }
        else
        {
            notificationText.text = "There's nowhere to fill your water bottle";
            gameMan.Neg();
        }
    }
    private void CheckFillWaterLocation()
    {
        if(gameMan.locationString == gameMan.location[5])
        {
            notificationText.text = "You filled your water bottle from the creek";
            gameMan.Pos();
        }
        else if (gameMan.locationString == gameMan.location[6])
        {
            notificationText.text = "You filled your water bottle from the river";
            gameMan.Pos();
        }
        else if(gameMan.locationString == gameMan.location[9])
        {
            notificationText.text = "You filled your water bottle from the lake";
            gameMan.Pos();
        }
    }
}