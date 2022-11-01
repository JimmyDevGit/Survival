using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HuntCanvas : MonoBehaviour
{
    public GameMan gameMan;
    public AudioManager audioManager;
    public Canvas mainCanvas;
    public Canvas huntCanvas;
    public Canvas notificationCanvas;
    public TextMeshProUGUI notificationText;
    public TextMeshProUGUI huntIngreedientsText;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void PlaceSnare()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.snarePlaced == false)
        {
            if (gameMan.snareInventory >= 1)
            {
                gameMan.snareInventory -= 1;
                gameMan.snareTrap += 1;
                gameMan.snarePlaced = true;
                gameMan.AddTime(1);
                audioManager.Play("PlaceTrap");
                notificationText.text = "You placed a snare trap";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have a snare";
                gameMan.Neg();
            }
        }
        else
        {
            notificationText.text = "You already have a snare placed";
            gameMan.Neg();
        }
    }
    public void PlaceSpikePit()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.spikePlaced == false)
        {
            if (gameMan.spearInventory >= 3)
            {
                gameMan.spearInventory -= 3;
                gameMan.spikeTrap += 1;
                gameMan.spikePlaced = true;
                gameMan.AddTime(1);
                audioManager.Play("PlaceTrap");
                notificationText.text = "You placed a spike trap";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have enough spears";
                gameMan.Neg();
            }
        }
        else
        {
            notificationText.text = "You already have a spike pit";
            gameMan.Neg();
        }
    }
    public void Spearhunt()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.sickness > 0)
        {
            notificationText.text = "You can't spear hunt when you're sick";
            gameMan.Neg();
        }
        else
        {
            if(gameMan.nightTime == false)
            {
                if (gameMan.locationString == "cave" || gameMan.locationString == "mountain top" || gameMan.locationString == "jungle" || gameMan.locationString == "valley")
                {
                    if (gameMan.spearInventory >= 1)
                    {
                        gameMan.AddTime(1);
                        float rand = Random.Range(0, 36);
                        if (rand == 0)
                        {
                            notificationText.text = "You speared a hog";
                            gameMan.Pos();
                            audioManager.Play("PigSqueal");
                            gameMan.bigGameInventory += 1;
                        }
                        else if (rand >= 1 && rand <= 10)
                        {
                            notificationText.text = "You speared small game";
                            gameMan.Pos();
                            audioManager.Play("SpearHunt");
                            gameMan.smallGameInventory += 1;
                        }
                        else
                        {
                            notificationText.text = "You caught nothing";
                            gameMan.Neg();
                            audioManager.Play("SpearHunt");
                        }
                    }
                    else
                    {
                        notificationText.text = "You don't have a spear";
                        gameMan.Neg();
                    }
                }
                else
                {
                    notificationText.text = "There are no tracks here";
                    gameMan.Neg();
                }
            }
            else
            {
                notificationText.text = "You can't spear hunt at night";
                gameMan.Neg();
            }
        }
    }
    public void RodFishing()
    {
        //STILL NEED TO CHECK LOCATION
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.sickness > 0)
        {
            notificationText.text = "You can't fish when you're sick";
            gameMan.Neg();
        }
        else
        {
            if(gameMan.locationString == "creek" || gameMan.locationString == "large river" || gameMan.locationString == "large lake")
            {
                if (gameMan.fishingRodInventory >= 1)
                {
                    if(gameMan.baitInventory > 0)
                    {
                        gameMan.AddTime(1);
                        audioManager.Play("RodFish");
                        gameMan.baitInventory -= 1;
                        float rand = Random.Range(0, 15);
                        if (rand >= 0 && rand <= 2)
                        {
                            notificationText.text = "You caught a small fish";
                            gameMan.Pos();
                            gameMan.smallFishInventory += 1;
                        }
                        else if (rand == 3)
                        {
                            notificationText.text = "You caught a big fish";
                            gameMan.Pos();
                            gameMan.bigFishInventory += 1;
                        }
                        else
                        {
                            notificationText.text = "You caught nothing";
                            gameMan.Neg();
                        }
                    }
                    else
                    {
                        notificationText.text = "You don't have bait";
                        gameMan.Neg();
                    }
                }
                else
                {
                    notificationText.text = "You don't have a fishing rod";
                    gameMan.Neg();
                }
            }
            else
            {
                notificationText.text = "There's nowhere to fish";
                gameMan.Neg();
            }
        }
    }
    public void SpearFishing()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.sickness > 0)
        {
            notificationText.text = "You can't spearfish when you're sick";
            gameMan.Neg();
        }
        else
        {
            if(gameMan.nightTime == false)
            {
                if (gameMan.locationString == "creek" || gameMan.locationString == "large river" || gameMan.locationString == "large lake")
                {
                    if (gameMan.spearInventory >= 1)
                    {
                        gameMan.AddTime(1);
                        audioManager.Play("SpearFish");
                        float rand = Random.Range(0, 15);
                        if (rand == 0)
                        {
                            notificationText.text = "You caught a small fish";
                            gameMan.Pos();
                            gameMan.smallFishInventory += 1;
                        }
                        else if (rand >= 1 && rand <= 2)
                        {
                            notificationText.text = "You caught a big fish";
                            gameMan.Pos();
                            gameMan.bigFishInventory += 1;
                        }
                        else
                        {
                            notificationText.text = "You caught nothing";
                            gameMan.Neg();
                        }
                    }
                    else
                    {
                        notificationText.text = "You don't have a spear";
                        gameMan.Neg();
                    }
                }
                else
                {
                    notificationText.text = "There's nowhere to fish";
                    gameMan.Neg();
                }
            }
            else
            {
                notificationText.text = "You can't spearfish at night";
                gameMan.Neg();
            }
        }
    }
    public void Dismantle()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.snarePlaced == true || gameMan.rainCatcherPlaced == true || gameMan.spikePlaced == true)
        {
            if(gameMan.snarePlaced == true)
            {
                gameMan.snarePlaced = false;
                gameMan.snareInventory += 1;
                gameMan.snareTrap -= 1;
            }
            if(gameMan.spikePlaced == true)
            {
                gameMan.spikePlaced = false;
                gameMan.spearInventory += 3;
                gameMan.spikeTrap -= 1;
            }
            if (gameMan.rainCatcherPlaced == true)
            {
                gameMan.rainCatcherPlaced = false;
                gameMan.woodInventory += 1;
                gameMan.trashBagInventory += 1;
            }
            gameMan.AddTime(1);
            audioManager.Play("PlaceTrap");
            notificationText.text = "You dismantled all traps and catchers";
            gameMan.Pos();
        }
        else
        {
            notificationText.text = "You have no traps or catchers to dismantle";
            gameMan.Neg();
        }
    }
    public void BackButton()
    {
        audioManager.Play("ClaveLow");
        huntCanvas.enabled = false;
        mainCanvas.enabled = true;
    }
}
