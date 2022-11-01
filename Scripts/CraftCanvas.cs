using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftCanvas : MonoBehaviour
{
    public GameMan gameMan;
    public AudioManager audioManager;
    public Canvas craftCanvas;
    public Canvas mainCanvas;
    public Canvas notificationCanvas;
    public TextMeshProUGUI notificationText;
    public TextMeshProUGUI craftIngreedientsText;

    public int craftButtonNumber;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void CraftSnare()
    {
        audioManager.Play("Clave");
        craftButtonNumber = 1;
        craftIngreedientsText.text = "REQUIRED ITEMS:\nx1 Rope\nx1 Wood";
    }
    public void CraftSpear()
    {
        audioManager.Play("Clave");
        craftButtonNumber = 2;
        craftIngreedientsText.text = "REQUIRED ITEMS:\nx2 Wood";
    }
    public void CraftBowDrill()
    {
        audioManager.Play("Clave");
        craftButtonNumber = 3;
        craftIngreedientsText.text = "REQUIRED ITEMS:\nx1 Rope\nx3 Wood";
    }
    public void CraftRod()
    {
        audioManager.Play("Clave");
        craftButtonNumber = 4;
        craftIngreedientsText.text = "REQUIRED ITEMS:\nx1 Rope\nx2 Wood\nx1 Fishing Hook";
    }
    public void CraftHook()
    {
        audioManager.Play("Clave");
        craftButtonNumber = 5;
        craftIngreedientsText.text = "REQUIRED ITEMS:\nx1 Wood";
    }
    public void CraftHandDrill()
    {
        audioManager.Play("Clave");
        craftButtonNumber = 6;
        craftIngreedientsText.text = "REQUIRED ITEMS:\nx2 Wood";
    }
    public void CraftButton()
    {
        notificationCanvas.enabled = true;
        audioManager.Play("Clave");
        //CraftSnare
        if(craftButtonNumber == 1)
        {
            if(gameMan.woodInventory >= 1 && gameMan.ropeInventory >=1)
            {
                gameMan.snareInventory += 1;
                gameMan.woodInventory -= 1;
                gameMan.ropeInventory -= 1;
                gameMan.AddTime(2);
                audioManager.Play("Craft");
                notificationText.text = "You crafted a snare";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have the required items";
                gameMan.Neg();
            }
        }
        //CraftSpear
        if (craftButtonNumber == 2)
        {
            if (gameMan.woodInventory >= 2)
            {
                gameMan.spearInventory += 1;
                gameMan.woodInventory -= 2;
                gameMan.AddTime(1);
                audioManager.Play("Craft");
                notificationText.text = "You crafted a spear";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have the required items";
                gameMan.Neg();
            }
        }
        //CraftBowDrill
        if (craftButtonNumber == 3)
        {
            if (gameMan.woodInventory >= 3 && gameMan.ropeInventory >= 1)
            {
                gameMan.bowDrillInventory += 1;
                gameMan.woodInventory -= 3;
                gameMan.ropeInventory -= 1;
                gameMan.AddTime(3);
                audioManager.Play("Craft");
                notificationText.text = "You crafted a bow drill";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have the required items";
                gameMan.Neg();
            }
        }
        //CraftRod
        if (craftButtonNumber == 4)
        {
            if (gameMan.woodInventory >= 1 && gameMan.ropeInventory >= 1 && gameMan.fishingHookInventory >= 1)
            {
                gameMan.fishingRodInventory += 1;
                gameMan.woodInventory -= 1;
                gameMan.fishingHookInventory -= 1;
                gameMan.ropeInventory -= 1;
                gameMan.AddTime(2);
                audioManager.Play("Craft");
                notificationText.text = "You crafted a fishing rod";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have the required items";
                gameMan.Neg();
            }
        }
        //CraftHook
        if (craftButtonNumber == 5)
        {
            if (gameMan.woodInventory >= 1)
            {
                gameMan.fishingHookInventory += 1;
                gameMan.woodInventory -= 1;
                gameMan.AddTime(1);
                audioManager.Play("Craft");
                notificationText.text = "You crafted a fishing hook";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have the required items";
                gameMan.Neg();
            }
        }
        //CraftHandDrill
        if (craftButtonNumber == 6)
        {
            if (gameMan.woodInventory >= 2)
            {
                gameMan.handDrillInventory += 1;
                gameMan.woodInventory -= 2;
                gameMan.AddTime(1);
                audioManager.Play("Craft");
                notificationText.text = "You crafted a hand drill";
                gameMan.Pos();
            }
            else
            {
                notificationText.text = "You don't have the required items";
                gameMan.Neg();
            }
        }
        if(craftButtonNumber == 0)
        {
            notificationText.text = "Nothing selected";
            gameMan.Neg();
        }
        craftIngreedientsText.text = "";
        gameMan.UpdateStats();
    }
    public void BackButton()
    {
        audioManager.Play("ClaveLow");
        craftCanvas.enabled = false;
        mainCanvas.enabled = true;
        craftButtonNumber = 0;
        craftIngreedientsText.text = "";
    }
}
