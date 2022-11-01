using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemWeight;
    public TextMeshProUGUI itemCount;
    public TextMeshProUGUI consumableText;
    public TextMeshProUGUI harvestForText;
    public GameObject inventoryCanvas;
    public GameMan gameMan;
    public AudioManager audioManager;
    private void Start()
    {
        inventoryCanvas = GameObject.Find("IntevntoryCanvas");
        consumableText = GameObject.Find("ConsumableText").GetComponent<TextMeshProUGUI>();
        harvestForText = GameObject.Find("HarvestForText").GetComponent<TextMeshProUGUI>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void SelectButton()
    {
        inventoryCanvas.GetComponent<InventoryCanvas>().selectedButton = gameObject.name;
        audioManager.Play("Clave");
        if (gameObject.name == "Wood")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX1 Tinder";
        }
        else if (gameObject.name == "Bugs")
        {
            consumableText.text = "CONSUMABLE:\n+5 Hunger";
            harvestForText.text = "HARVEST FOR:\nX1 Bait";
        }
        else if (gameObject.name == "Unknown Berries")
        {
            consumableText.text = "CONSUMABLE:\n+5 Hunger";
            harvestForText.text = "HARVEST FOR:\nX1 Bait";
        }
        else if (gameObject.name == "non-potable water")
        {
            consumableText.text = "CONSUMABLE:\n+25 Hydration\nX1 Empty Water Bottle";
            harvestForText.text = "HARVEST FOR:\nX1 Empty water bottle";
        }
        else if (gameObject.name == "Tinder")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Bait")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Vine")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX1 Rope";
        }
        else if (gameObject.name == "Small Fish")
        {
            consumableText.text = "CONSUMABLE:\n+10 Hunger";
            harvestForText.text = "HARVEST FOR:\nX5 Bait";
        }
        else if (gameObject.name == "Big Fish")
        {
            consumableText.text = "CONSUMABLE:\n+20 Hunger";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Small Game")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Big Game")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Small Cooked Meat")
        {
            consumableText.text = "CONSUMABLE:\n+10 Hunger";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Large Cooked Meat")
        {
            consumableText.text = "CONSUMABLE:\n+30 Hunger";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Clean Water")
        {
            consumableText.text = "CONSUMABLE:\n+25 Hydration\nX1 Empty Water Bottle";
            harvestForText.text = "HARVEST FOR:\nX1 Empty Water Bottle";
        }
        else if (gameObject.name == "Rope")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Hand Drill")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX2 Wood";
        }
        else if (gameObject.name == "Bow Drill")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX1 Rope\nX2 Wood";
        }
        else if (gameObject.name == "Fishing Rod")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX1 Wood\nX1 Rope";
        }
        else if (gameObject.name == "Fishing Hook")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Spear")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX2 Wood";
        }
        else if (gameObject.name == "Matches")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Trash Bag")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Cloth")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX1 Tinder";
        }
        else if (gameObject.name == "Map")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX1 Tinder";
        }
        else if (gameObject.name == "Cable")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX1 Rope";
        }
        else if (gameObject.name == "Lighter")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "MRE")
        {
            consumableText.text = "CONSUMABLE:\n+100 Hunger";
            harvestForText.text = "HARVEST FOR:\nX1 Bait";
        }
        else if (gameObject.name == "Axe")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Snare")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:\nX1 Wood\nX1 Rope";
        }
        else if (gameObject.name == "Empty Water Bottle")
        {
            consumableText.text = "CONSUMABLE:\nNo";
            harvestForText.text = "HARVEST FOR:";
        }
        else if (gameObject.name == "Candy Bar")
        {
            consumableText.text = "CONSUMABLE:\n+20 Hunger";
            harvestForText.text = "HARVEST FOR:";
        }
    }
}
