using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainCanvasButtons : MonoBehaviour
{
    public GameMan gameMan;
    public AudioManager audioManager;
    public Canvas mainCanvas;
    public Canvas findCanvas;
    public Canvas huntCanvas;
    public Canvas fireCanvas;
    public Canvas inventoryCanvas;
    public Canvas travelCanvas;
    public Canvas craftCanvas;
    public Canvas shelterCanvas;
    public GameObject inventory;
    public GameObject fire;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void FindButton()
    {
        mainCanvas.enabled = false;
        findCanvas.enabled = true;
        audioManager.Play("Clave");
    }
    public void HuntButton()
    {
        mainCanvas.enabled = false;
        huntCanvas.enabled = true;
        audioManager.Play("Clave");
    }
    public void CraftButton()
    {
        mainCanvas.enabled = false;
        craftCanvas.enabled = true;
        audioManager.Play("Clave");
    }
    public void FireButton()
    {
        mainCanvas.enabled = false;
        fireCanvas.enabled = true;
        audioManager.Play("Clave");
        gameMan.UpdateStats();
        fire.GetComponent<FireCanvas>().InstantiateItems();
    }
    public void BackpackButton()
    {
        mainCanvas.enabled = false;
        inventoryCanvas.enabled = true;
        audioManager.Play("Clave");
        inventory.GetComponent<InventoryCanvas>().InstantiateItems();
    }
    public void ShelterButton()
    {
        mainCanvas.enabled = false;
        shelterCanvas.enabled = true;
        audioManager.Play("Clave");
        gameMan.UpdateStats();
    }
    public void TravelButton()
    {
        mainCanvas.enabled = false;
        travelCanvas.enabled = true;
        audioManager.Play("Clave");
        travelCanvas.GetComponent<TravelCanvas>().SetTravelLocations();
    }
}
