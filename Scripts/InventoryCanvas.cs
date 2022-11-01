using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryCanvas : MonoBehaviour
{
    public Canvas inventoryCanvas;
    public Canvas mainCanvas;
    public Canvas notificationCanvas;
    public TextMeshProUGUI notificationText;
    
    public TextMeshProUGUI consumableText;
    public TextMeshProUGUI harvestForText;
    public GameMan gameMan;
    public AudioManager audioManager;
    public GameObject itemButton;
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
    public void InstantiateItems()
    {
        if (gameMan.cleanWaterInventory > 0)
        {
            itemText = "Clean Water";
            itemWeight = gameMan.cleanWaterInventory;
            itemCount = gameMan.cleanWaterInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.woodInventory > 0)
        {
            itemText = "Wood";
            itemWeight = gameMan.woodInventory;
            itemCount = gameMan.woodInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.candyBar > 0)
        {
            itemText = "Candy Bar";
            itemWeight = gameMan.candyBarWeight * gameMan.candyBar;
            itemCount = gameMan.candyBar.ToString();
            ItemInstantiator();
        }
        if (gameMan.smallCookedMeat > 0)
        {
            itemText = "Small Cooked Meat";
            itemWeight = gameMan.smallCookedMeat * gameMan.smallCookedMeatWeight;
            itemCount = gameMan.smallCookedMeat.ToString();
            ItemInstantiator();
        }
        if (gameMan.largeCookedMeat > 0)
        {
            itemText = "Large Cooked Meat";
            itemWeight = gameMan.largeCookedMeat;
            itemCount = gameMan.largeCookedMeat.ToString();
            ItemInstantiator();
        }
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
        if (gameMan.bugsInventory > 0)
        {
            itemText = "Bugs";
            itemWeight = gameMan.bugsWeight * gameMan.bugsInventory;
            itemCount = gameMan.bugsInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.unknownBerriesInventory > 0)
        {
            itemText = "Unknown Berries";
            itemWeight = gameMan.unknownBerriesWeight * gameMan.unknownBerriesInventory;
            itemCount = gameMan.unknownBerriesInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.edibleBerriesInventory > 0)
        {
            itemText = "Edible Berries";
            itemWeight = gameMan.edibleBerriesWeight * gameMan.edibleBerriesInventory;
            itemCount = gameMan.edibleBerriesInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.nonPotableWaterInventory > 0)
        {
            itemText = "non-potable water";
            itemWeight = gameMan.nonPotableWaterInventory;
            itemCount = gameMan.nonPotableWaterInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.tinderInventory > 0)
        {
            itemText = "Tinder";
            itemWeight = gameMan.tinderWeight * gameMan.tinderInventory;
            itemCount = gameMan.tinderInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.baitInventory > 0)
        {
            itemText = "Bait";
            itemWeight = gameMan.baitWeight * gameMan.baitInventory;
            itemCount = gameMan.baitInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.vineInventory > 0)
        {
            itemText = "Vine";
            itemWeight = gameMan.vineInventory;
            itemCount = gameMan.vineInventory.ToString();
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
        if (gameMan.ropeInventory > 0)
        {
            itemText = "Rope";
            itemWeight = gameMan.ropeInventory;
            itemCount = gameMan.ropeInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.emptyWaterBottlesInventory > 0)
        {
            itemText = "Empty Water Bottle";
            itemWeight = gameMan.emptyWaterBottleWeight * gameMan.emptyWaterBottlesInventory;
            itemCount = gameMan.emptyWaterBottlesInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.handDrillInventory > 0)
        {
            itemText = "Hand Drill";
            itemWeight = gameMan.handDrillInventory;
            itemCount = gameMan.handDrillInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.fishingRodInventory > 0)
        {
            itemText = "Fishing Rod";
            itemWeight = gameMan.fishingRodWeight * gameMan.fishingRodInventory;
            itemCount = gameMan.fishingRodInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.fishingHookInventory > 0)
        {
            itemText = "Fishing Hook";
            itemWeight = gameMan.fishingHookWeight * gameMan.fishingHookInventory;
            itemCount = gameMan.fishingHookInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.matchesInventory > 0)
        {
            itemText = "Matches";
            itemWeight = gameMan.matchesWeight * gameMan.matchesInventory;
            itemCount = gameMan.matchesInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.trashBagInventory > 0)
        {
            itemText = "Trash Bag";
            itemWeight = gameMan.trashBagWeight * gameMan.trashBagInventory;
            itemCount = gameMan.trashBagInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.clothInventory > 0)
        {
            itemText = "Cloth";
            itemWeight = gameMan.clothWeight * gameMan.clothInventory;
            itemCount = gameMan.clothInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.mapInventory > 0)
        {
            itemText = "Map";
            itemWeight = gameMan.mapWeight * gameMan.mapInventory;
            itemCount = gameMan.mapInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.cablesInventory > 0)
        {
            itemText = "Cable";
            itemWeight = gameMan.cablesInventory;
            itemCount = gameMan.cablesInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.lighterInventory > 0)
        {
            itemText = "Lighter";
            itemWeight = gameMan.lighterInventory;
            itemCount = gameMan.lighterInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.MREInventory > 0)
        {
            itemText = "MRE";
            itemWeight = gameMan.MREInventory;
            itemCount = gameMan.MREInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.axeInventory > 0)
        {
            itemText = "Axe";
            itemWeight = gameMan.axeWeight * gameMan.axeInventory;
            itemCount = gameMan.axeInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.spearInventory > 0)
        {
            itemText = "Spear";
            itemWeight = gameMan.spearWeight * gameMan.spearInventory;
            itemCount = gameMan.spearInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.snareInventory > 0)
        {
            itemText = "Snare";
            itemWeight = gameMan.snareInventory;
            itemCount = gameMan.snareInventory.ToString();
            ItemInstantiator();
        }
        if (gameMan.bowDrillInventory > 0)
        {
            itemText = "Bow Drill";
            itemWeight = gameMan.bowDrillInventory;
            itemCount = gameMan.bowDrillInventory.ToString();
            ItemInstantiator();
        }
        gameMan.UpdateStats();
    }
    public void ItemInstantiator()
    {
        inventoryButtonY = inventoryButtonY - 100;
        //Instantiate and set location of button
        GameObject myPrefab = GameObject.Instantiate(itemButtonPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, scrollContent.transform);
        itemButton = myPrefab;
        itemButton.transform.localPosition = new Vector3(400, inventoryButtonY, itemButton.transform.position.z);

        //Set Values on button
        ItemButton itemButtonScript = itemButton.GetComponent<ItemButton>();
        itemButtonScript.itemText.text = itemText;
        itemButtonScript.itemWeight.text = itemWeight.ToString();
        itemButtonScript.itemCount.text = "x " + itemCount;
        itemButtonScript.name = itemText;
    }


    public void Consume()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (selectedButton == "")
        {
            notificationText.text = "Nothing selected";
            gameMan.Neg();
        }
        else if (selectedButton == "Candy Bar")
        {
            notificationText.text = "You ate a candy bar";
            gameMan.Pos();
            audioManager.Play("Consume");
            gameMan.candyBar -= 1;
            gameMan.hunger += 20;
        }
        else if(selectedButton == "Bugs")
        {
            notificationText.text = "You ate bugs";
            gameMan.Pos();
            audioManager.Play("Consume");
            gameMan.bugsInventory -= 1;
            gameMan.hunger += 5;
        }
        else if(selectedButton == "Edible Berries")
        {
            notificationText.text = "You ate edible berries";
            gameMan.Pos();
            audioManager.Play("Consume");
            gameMan.edibleBerriesInventory -= 1;
            gameMan.hunger += 5;
        }
        else if(selectedButton == "Unknown Berries")
        {
            audioManager.Play("Consume");
            gameMan.unknownBerriesInventory -= 1;
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                notificationText.text = "You ate unknown berries";
                gameMan.Pos();
                gameMan.hunger += 5;
            }
            else if(rand == 1)
            {
                notificationText.text = "The berries made you sick";
                gameMan.Neg();
                gameMan.Sick();
                gameMan.condition -= 10;
            }
        }
        else if(selectedButton == "non-potable water")
        {
            audioManager.Play("Consume");
            if (gameMan.nonPotableWaterInventory > 0)
            {
                notificationText.text = "You drank non-potable water";
                gameMan.Neg();
                gameMan.Sick();
                gameMan.nonPotableWaterInventory -= 1;
                gameMan.emptyWaterBottlesInventory += 1;
                gameMan.hydration += 25;
            }
            else
            {
                notificationText.text = "You have no water to drink";
                gameMan.Neg();
            }
        }
        else if(selectedButton == "Clean Water")
        {
            audioManager.Play("Consume");
            if(gameMan.cleanWaterInventory > 0)
            {
                notificationText.text = "You drank clean water";
                gameMan.Pos();
                gameMan.cleanWaterInventory -= 1;
                gameMan.emptyWaterBottlesInventory += 1;
                gameMan.hydration += 25;
            }
            else
            {
                notificationText.text = "You have no water to drink";
                gameMan.Neg();
            }
        }
        else if(selectedButton == "MRE")
        {
            audioManager.Play("Consume");
            notificationText.text = "You ate an MRE";
            gameMan.Pos();
            gameMan.MREInventory -= 1;
            gameMan.hunger += 100;
        }
        else if(selectedButton == "Small Fish")
        {
            audioManager.Play("Consume");
            int sickOrNotSF = Random.Range(0, 2);
            if(sickOrNotSF == 0)
            {
                gameMan.smallFishInventory -= 1;
                gameMan.condition -= 20;
                notificationText.text = "The raw fish made you ill";
                gameMan.Pos(); gameMan.Neg();
                gameMan.Sick();
            }
            else if (sickOrNotSF == 1)
            {
                gameMan.smallFishInventory -= 1;
                gameMan.hunger += 10;
                notificationText.text = "You ate raw fish";
                gameMan.Pos();
            }
        }
        else if(selectedButton == "Big Fish")
        {
            audioManager.Play("Consume");
            int sickOrNotBF = Random.Range(0, 2);
            if (sickOrNotBF == 0)
            {
                gameMan.bigFishInventory -= 1;
                gameMan.condition -= 20;
                notificationText.text = "The raw fish made you ill";
                gameMan.Neg();
                gameMan.Sick();
            }
            else if (sickOrNotBF == 1)
            {
                gameMan.bigFishInventory -= 1;
                gameMan.hunger += 20;
                notificationText.text = "You ate raw fish";
                gameMan.Pos();
            }
        }
        else if(selectedButton == "Small Cooked Meat")
        {
            audioManager.Play("Consume");
            notificationText.text = "You ate small cooked meat";
            gameMan.Pos();
            gameMan.smallCookedMeat -= 1;
            gameMan.hunger += 10;
        }
        else if(selectedButton == "Large Cooked Meat")
        {
            audioManager.Play("Consume");
            notificationText.text = "You ate large cooked meat";
            gameMan.Pos();
            gameMan.largeCookedMeat -= 1;
            gameMan.hunger += 30;
        }
        else
        {
            notificationText.text = "You cannot consume this item";
            gameMan.Neg();
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }
    public void Harvest()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (selectedButton == "")
        {
            notificationText.text = "Nothing selected";
            gameMan.Neg();
        }
        else if(selectedButton == "Wood")
        {
            notificationText.text = "You got tinder";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.woodInventory -= 1;
            gameMan.tinderInventory += 1;
        }
        else if(selectedButton == "Bugs")
        {
            notificationText.text = "You got bait";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.bugsInventory -= 1;
            gameMan.baitInventory += 1;
        }
        else if(selectedButton == "Edible Berries")
        {
            notificationText.text = "You got bait";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.edibleBerriesInventory -= 1;
            gameMan.baitInventory += 1;
        }
        else if(selectedButton == "Unknown Berries")
        {
            notificationText.text = "You got bait";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.unknownBerriesInventory -= 1;
            gameMan.baitInventory += 1;
        }
        else if (selectedButton == "Vine")
        {
            notificationText.text = "You got rope";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.vineInventory -= 1;
            gameMan.ropeInventory += 1;
        }
        else if(selectedButton == "Bow Drill")
        {
            notificationText.text = "You got rope and 2 wood";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.bowDrillInventory -= 1;
            gameMan.ropeInventory += 1;
            gameMan.woodInventory += 2;
        }
        else if(selectedButton == "Hand Drill")
        {
            notificationText.text = "You got 2 wood";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.handDrillInventory -= 1;
            gameMan.woodInventory += 2;
        }
        else if(selectedButton == "Fishing Rod")
        {
            notificationText.text = "You got wood and rope";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.fishingRodInventory -= 1;
            gameMan.woodInventory += 1;
            gameMan.ropeInventory += 1;
        }
        else if (selectedButton == "Spear")
        {
            notificationText.text = "You got 2 wood";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.spearInventory -= 1;
            gameMan.woodInventory += 2;
        }
        else if (selectedButton == "Snare")
        {
            notificationText.text = "You got wood and rope";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.snareInventory -= 1;
            gameMan.woodInventory += 1;
            gameMan.ropeInventory += 1;
        }
        else if(selectedButton == "Cloth")
        {
            notificationText.text = "You got tinder";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.clothInventory -= 1;
            gameMan.tinderInventory += 1;
        }
        else if(selectedButton == "Map")
        {
            notificationText.text = "You got tinder";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.mapInventory -= 1;
            gameMan.tinderInventory += 1;
        }
        else if (selectedButton == "Cable")
        {
            notificationText.text = "You got rope";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.cablesInventory -= 1;
            gameMan.ropeInventory += 1;
        }
        else if (selectedButton == "Small Fish")
        {
            notificationText.text = "You got 5 bait";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.smallFishInventory -= 1;
            gameMan.baitInventory += 5;
        }
        else if(selectedButton == "non-potable water")
        {
            notificationText.text = "You got an empty water bottle";
            gameMan.Pos();
            audioManager.Play("Harvest");
            gameMan.nonPotableWaterInventory -= 1;
            gameMan.emptyWaterBottlesInventory += 1;
        }
        else
        {
            notificationText.text = "You can't harvest this item";
            gameMan.Neg();
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }
    public void ThrowAway()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        if (selectedButton == "")
        {
            notificationText.text = "Nothing selected";
            gameMan.Neg();
        }
        if (selectedButton == "Wood")
        {
            notificationText.text = "You threw away 1 wood";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.woodInventory -= 1;
        }
        if (selectedButton == "Bugs")
        {
            notificationText.text = "You threw away 1 bug";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.bugsInventory -= 1;
        }
        if (selectedButton == "Edible Berries")
        {
            notificationText.text = "You threw away 1 edible berry";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.edibleBerriesInventory -= 1;
        }
        if (selectedButton == "Unknown Berries")
        {
            notificationText.text = "You threw away 1 unknown berry";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.unknownBerriesInventory -= 1;
        }
        if (selectedButton == "Tinder")
        {
            notificationText.text = "You threw away 1 tinder";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.tinderInventory -= 1;
        }
        if(selectedButton == "Bait")
        {
            notificationText.text = "You threw away 1 bait";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.baitInventory -= 1;
        }
        if(selectedButton == "non-potable water")
        {
            notificationText.text = "You threw away 1 non-potable water";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.nonPotableWaterInventory -= 1;
        }
        if (selectedButton == "Clean Water")
        {
            notificationText.text = "You threw away 1 clean water";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.cleanWaterInventory -= 1;
        }
        if (selectedButton == "Empty Water Bottle")
        {
            notificationText.text = "You threw away 1 empty water bottle";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.emptyWaterBottlesInventory -= 1;
        }
        if (selectedButton == "Vine")
        {
            notificationText.text = "You threw away 1 vine";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.vineInventory -= 1;
        }
        if (selectedButton == "Rope")
        {
            notificationText.text = "You threw away 1 piece of rope";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.ropeInventory -= 1;
        }
        if(selectedButton == "Hand Drill")
        {
            notificationText.text = "You threw away 1 hand drill";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.handDrillInventory -= 1;
        }
        if(selectedButton == "Bow Drill")
        {
            notificationText.text = "You threw away 1 bow drill";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.bowDrillInventory -= 1;
        }
        if (selectedButton == "Fishing Rod")
        {
            notificationText.text = "You threw away 1 fishing rod";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.fishingRodInventory -= 1;
        }
        if (selectedButton == "Fishing Hook")
        {
            notificationText.text = "You threw away 1 fishing hook";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.fishingHookInventory -= 1;
        }
        if (selectedButton == "Spear")
        {
            notificationText.text = "You threw away 1 spear";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.spearInventory -= 1;
        }
        if (selectedButton == "Snare")
        {
            notificationText.text = "You threw away 1 snare";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.snareInventory -= 1;
        }
        if (selectedButton == "Matches")
        {
            notificationText.text = "You threw away 1 match";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.matchesInventory -= 1;
        }
        if (selectedButton == "Trash Bag")
        {
            notificationText.text = "You threw away 1 trash bag";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.trashBagInventory -= 1;
        }
        if (selectedButton == "Cloth")
        {
            notificationText.text = "You threw away 1 piece of cloth";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.clothInventory -= 1;
        }
        if (selectedButton == "Map")
        {
            notificationText.text = "You threw away 1 map";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.mapInventory -= 1;
        }
        if (selectedButton == "Cable")
        {
            notificationText.text = "You threw away 1 cable";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.cablesInventory -= 1;
        }
        if (selectedButton == "Lighter")
        {
            notificationText.text = "You threw away 1 lighter";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.lighterInventory -= 1;
        }
        if (selectedButton == "MRE")
        {
            notificationText.text = "You threw away 1 MRE";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.MREInventory -= 1;
        }
        if (selectedButton == "Axe")
        {
            notificationText.text = "You threw away 1 axe";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.axeInventory -= 1;
        }
        if(selectedButton == "Small Fish")
        {
            notificationText.text = "You threw away 1 small fish";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.smallFishInventory -= 1;
        }
        if(selectedButton == "Big Fish")
        {
            notificationText.text = "You threw away 1 big fish";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.bigFishInventory -= 1;
        }
        if(selectedButton == "Small Game")
        {
            notificationText.text = "You threw away small game";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.smallGameInventory -= 1;
        }
        if (selectedButton == "Big Game")
        {
            notificationText.text = "You threw away big game";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.bigGameInventory -= 1;
        }
        if (selectedButton == "Small Cooked Meat")
        {
            notificationText.text = "You threw away small cooked meat";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.smallCookedMeat -= 1;
        }
        if (selectedButton == "Large Cooked Meat")
        {
            notificationText.text = "You threw away large cooked meat";
            gameMan.Pos();
            audioManager.Play("ThrowAway");
            gameMan.largeCookedMeat -= 1;
        }
        selectedButton = "";
        gameMan.UpdateStats();
        ResetItems();
        InstantiateItems();
        gameMan.SavePlayer();
    }

    public void BackButton()
    {
        audioManager.Play("ClaveLow");
        inventoryCanvas.enabled = false;
        mainCanvas.enabled = true;
        selectedButton = "";
        ResetItems();
    }
    public void ResetItems() {
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
        consumableText.text = "";
        harvestForText.text = "";
    }
}
