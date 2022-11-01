using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireCanvas : MonoBehaviour
{
    public Canvas fireCanvas;
    public Canvas mainCanvas;
    public Canvas notificationCanvas;
    public TextMeshProUGUI notificationText;
    public TextMeshProUGUI timeRemainingText;
    public GameMan gameMan;
    public AudioManager audioManager;
    public GameObject itemButtonCook;
    public GameObject itemButtonPrefab;
    public GameObject scrollContent;
    private string itemText;
    private float itemWeight;
    private string itemCount;
    private int inventoryButtonY = 50;
    public string selectedButton;
    public int totalItemButtons = 0;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void AddWood()
    {
        audioManager.Play("Clave");
        if (gameMan.fireTimeRemaining > 0)
        {
            if(gameMan.woodInventory > 0)
            {
                gameMan.woodInventory -= 1;
                gameMan.fireTimeRemaining = gameMan.fireTimeRemaining += 1;
                audioManager.Play("AddWood");
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have wood";
                notificationCanvas.enabled = true;
                gameMan.Neg();
            }
        }
        else
        {
            notificationText.text = "You have not started a fire";
            notificationCanvas.enabled = true;
            gameMan.Neg();
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }
    public void UseLighter()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.fireTimeRemaining > 0)
        {
            notificationText.text = "You already have a fire";
            gameMan.Neg();
        }
        else
        {
            if (gameMan.lighterInventory <= 0)
            {
                notificationText.text = "You don't have a lighter";
                gameMan.Neg();
            }
            else if (gameMan.tinderInventory <= 0)
            {
                notificationText.text = "You don't have tinder";
                gameMan.Neg();
            }
            else if (gameMan.woodInventory <= 0)
            {
                notificationText.text = "You don't have wood";
                gameMan.Neg();
            }
            else
            {
                notificationText.text = "You started a fire!";
                gameMan.Pos();
                audioManager.Play("Lighter");
                gameMan.tinderInventory -= 1;
                gameMan.woodInventory -= 1;
                gameMan.fireTimeRemaining = 1;
            }
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }
    public void UseMatch()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.fireTimeRemaining > 0)
        {
            notificationText.text = "You already have a fire";
            gameMan.Neg();
        }
        else
        {
            if(gameMan.matchesInventory <= 0)
            {
                notificationText.text = "You don't have matches";
                gameMan.Neg();
            }
            else if(gameMan.tinderInventory <= 0)
            {
                notificationText.text = "You don't have tinder";
                gameMan.Neg();
            }
            else if(gameMan.woodInventory <= 0)
            {
                notificationText.text = "You don't have wood";
                gameMan.Neg();
            }
            else
            {
                if(Random.Range(0,2) == 1)
                {
                    notificationText.text = "You started a fire!";
                    gameMan.Pos();
                    audioManager.Play("Match");
                    gameMan.tinderInventory -= 1;
                    gameMan.woodInventory -= 1;
                    gameMan.fireTimeRemaining = 1;
                    gameMan.matchesInventory -= 1;
                }
                else
                {
                    gameMan.tinderInventory -= 1;
                    gameMan.matchesInventory -= 1;
                    notificationText.text = "You failed to start a fire";
                    gameMan.Neg();
                    audioManager.Play("Match");
                }
            }
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }
    public void UseBowDrill()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.fireTimeRemaining > 0)
        {
            notificationText.text = "You already have a fire";
            gameMan.Neg();
        }
        else
        {
            if (gameMan.bowDrillInventory < 1)
            {
                notificationText.text = "You don't have a bow drill";
                gameMan.Neg();
            }
            else if (gameMan.tinderInventory < 1)
            {
                notificationText.text = "You don't have tinder";
                gameMan.Neg();
            }
            else if (gameMan.woodInventory < 1)
            {
                notificationText.text = "You don't have wood";
                gameMan.Neg();
            }
            else if (Random.Range(0, 2) == 1)
            {
                notificationText.text = "You started a fire!";
                gameMan.Pos();
                audioManager.Play("BowDrill");
                gameMan.AddTime(1);
                gameMan.tinderInventory -= 1;
                gameMan.woodInventory -= 1;
                gameMan.fireTimeRemaining = 1;
            }
            else
            {
                gameMan.AddTime(1);
                gameMan.tinderInventory -= 1;
                notificationText.text = "You failed to start a fire";
                gameMan.Neg();
                audioManager.Play("BowDrill");
            }
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }
    public void UseHandDrill()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (gameMan.fireTimeRemaining > 0)
        {
            notificationText.text = "You already have a fire";
            gameMan.Neg();
        }
        else
        {
            if(gameMan.handDrillInventory < 1)
            {
                notificationText.text = "You don't have a hand drill";
                gameMan.Neg();
            }
            else if(gameMan.tinderInventory < 1)
            {
                notificationText.text = "You don't have tinder";
                gameMan.Neg();
            }
            else if(gameMan.woodInventory < 1)
            {
                notificationText.text = "You don't have wood";
                gameMan.Neg();
            }
            else if(Random.Range(0,4) == 1)
            {
                notificationText.text = "You started a fire!";
                gameMan.Pos();
                gameMan.AddTime(1);
                audioManager.Play("BowDrill");
                gameMan.woodInventory -= 1;
                gameMan.tinderInventory -= 1;
                gameMan.fireTimeRemaining = 1;
            }
            else
            {
                gameMan.AddTime(1);
                audioManager.Play("BowDrill");
                gameMan.tinderInventory -= 1;
                notificationText.text = "You failed to start a fire";
                gameMan.Neg();
            }
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }
    public void Cook()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (selectedButton == "")
        {
            notificationText.text = "Nothing selected";
            gameMan.Neg();
        }
        else if(gameMan.fireTimeRemaining > 0)
        {
            if (selectedButton == "Small Fish")
            {
                notificationText.text = "You got small cooked meat";
                gameMan.Pos();
                audioManager.Play("Cook");
                gameMan.smallFishInventory -= 1;
                gameMan.smallCookedMeat += 1;
            }
            else if(selectedButton == "Big Fish")
            {
                notificationText.text = "You got large cooked meat";
                gameMan.Pos();
                audioManager.Play("Cook");
                gameMan.bigFishInventory -= 1;
                gameMan.largeCookedMeat += 1;
            }
            else if(selectedButton == "Small Game")
            {
                notificationText.text = "You got small cooked meat";
                gameMan.Pos();
                audioManager.Play("Cook");
                gameMan.smallGameInventory -= 1;
                gameMan.smallCookedMeat += 1;
            }
            else if(selectedButton == "Big Game")
            {
                notificationText.text = "You got 5 large cooked meat";
                gameMan.Pos();
                audioManager.Play("Cook");
                gameMan.bigGameInventory -= 1;
                gameMan.largeCookedMeat += 5;
            }
            else if(selectedButton == "non-potable water")
            {
                notificationText.text = "You got clean water";
                gameMan.Pos();
                audioManager.Play("Boil");
                gameMan.nonPotableWaterInventory -= 1;
                gameMan.cleanWaterInventory += 1;
            }
            gameMan.AddTime(1);
        }
        else
        {
            notificationText.text = "You don't have a fire";
            gameMan.Neg();
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }
    public void InstantiateItems()
    {
        if (gameMan.smallFishInventory > 0)
        {
            itemText = "Small Fish";
            itemWeight = gameMan.smallFishInventory * gameMan.smallFishWeight;
            itemCount = gameMan.smallFishInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.bigFishInventory > 0)
        {
            itemText = "Big Fish";
            itemWeight = gameMan.bigFishInventory;
            itemCount = gameMan.bigFishInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.smallGameInventory > 0)
        {
            itemText = "Small Game";
            itemWeight = gameMan.smallGameInventory;
            itemCount = gameMan.smallGameInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.bigGameInventory > 0)
        {
            itemText = "Big Game";
            itemWeight = gameMan.bigGameInventory * gameMan.bigGameWeight;
            itemCount = gameMan.bigGameInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.nonPotableWaterInventory > 0)
        {
            itemText = "non-potable water";
            itemWeight = gameMan.nonPotableWaterInventory;
            itemCount = gameMan.nonPotableWaterInventory.ToString();
            ItemInstantiator();
        }
        gameMan.UpdateStats();
    }
    public void ItemInstantiator()
    {
        inventoryButtonY = inventoryButtonY - 100;
        //Instantiate and set location of button
        GameObject myPrefab = GameObject.Instantiate(itemButtonPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, scrollContent.transform);
        itemButtonCook = myPrefab;
        itemButtonCook.transform.localPosition = new Vector3(400, inventoryButtonY, itemButtonCook.transform.position.z);

        //Set Values on button
        ItemButtonCook itemButtonScript = itemButtonCook.GetComponent<ItemButtonCook>();
        itemButtonScript.itemText.text = itemText;
        itemButtonScript.itemWeight.text = itemWeight.ToString();
        itemButtonScript.itemCount.text = "x " + itemCount;
        itemButtonScript.name = itemText;
    }
    public void BackButton()
    {
        audioManager.Play("ClaveLow");
        fireCanvas.enabled = false;
        mainCanvas.enabled = true;
        ResetItems();
    }
    public void ResetItems()
    {
        //Destroys all item buttons
        var clones = GameObject.FindGameObjectsWithTag("ItemButton");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        //Set button count back to 0
        totalItemButtons = 0;
        //Sets start Y position for item buttons back to original
        inventoryButtonY = 50;
        //Sets time remaining on fire
        timeRemainingText.text = gameMan.fireTimeRemaining + " Hrs Remaining";
    }
}
