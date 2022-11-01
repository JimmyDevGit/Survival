using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationCanvas : MonoBehaviour
{
    public Canvas notificationCanvas;
    public Canvas notificationCanvas2;
    public AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void NextButton()
    {
        audioManager.Play("Clave");
        notificationCanvas.enabled = false;
    }
    public void NextButton2()
    {
        audioManager.Play("Clave");
        notificationCanvas2.enabled = false;
    }
}
