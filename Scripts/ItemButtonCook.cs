using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemButtonCook : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemWeight;
    public TextMeshProUGUI itemCount;
    public GameObject fireCanvas;
    public AudioManager audioManager;
    private void Start()
    {
        fireCanvas = GameObject.Find("FireCanvas");
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void SelectButton()
    {
        fireCanvas.GetComponent<FireCanvas>().selectedButton = gameObject.name;
        audioManager.Play("Clave");
    }
}
