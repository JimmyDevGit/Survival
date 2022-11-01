using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas notificationCanvas;
    public Canvas menuCanvas;
    public Canvas tipsCanvas;
    public Canvas devNotes;
    public AudioManager audioManager;
    public bool saveExists;
    private void Start()
    {
        //check if save file exists
        SaveSystem.LoadPlayer();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.Play("MenuBGM");
    }
    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
    public void NewGame()
    {
        if(saveExists == true)
        {
            notificationCanvas.enabled = true;
            menuCanvas.enabled = false;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Tips()
    {
        tipsCanvas.enabled = true;
    }
    public void TipsClose()
    {
        tipsCanvas.enabled = false;
    }
    public void DevNotes()
    {
        devNotes.enabled = true;
    }
    public void DevNotesBack()
    {
        devNotes.enabled = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void YesButton()
    {
        SaveSystem.SeriouslyDeleteAllSaveFiles();
        SceneManager.LoadScene(1);
    }
    public void NoButton()
    {
        notificationCanvas.enabled = false;
        menuCanvas.enabled = true;
    }
}
