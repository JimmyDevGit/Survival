using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerkItemCanvas : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas perkItemCanvas;
    public GameMan gameMan;
    public AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void Lighter()
    {
        audioManager.Play("Clave");
        gameMan.lighterInventory += 1;
        ClosePerkCanvas();
    }
    public void MRE()
    {
        audioManager.Play("Clave");
        gameMan.MREInventory += 1;
        ClosePerkCanvas();
    }
    public void Backpack()
    {
        audioManager.Play("Clave");
        gameMan.largeBackpackInventory += 1;
        ClosePerkCanvas();
    }
    public void Axe()
    {
        audioManager.Play("Clave");
        gameMan.axeInventory += 1;
        ClosePerkCanvas();
    }
    public void ClosePerkCanvas()
    {
        perkItemCanvas.enabled = false;
        mainCanvas.enabled = true;
        gameMan.UpdateStats();
    }
}
