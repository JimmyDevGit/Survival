using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathCanvas : MonoBehaviour
{
    public GameMan gameMan;
    public GameObject deathMenuButton;
    public GameObject daysSurvivedGO;
    public GameObject youDiedText;
    public TextMeshProUGUI daysSurvived;
    public AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void DeathMenuButton()
    {
        audioManager.Play("Clave");
        gameMan.StopAllSounds();
        SaveSystem.SeriouslyDeleteAllSaveFiles();
        SceneManager.LoadScene(0);
    }
    //Call this function at the same time as enabling canvas
    public IEnumerator DeathButtonDelay()
    {
        yield return new WaitForSeconds(1);
        youDiedText.SetActive(true);
        yield return new WaitForSeconds(1);
        daysSurvivedGO.SetActive(true);
        daysSurvived.text = "You survived " + gameMan.day + " days";
        yield return new WaitForSeconds(1);
        daysSurvived.text = "You survived " + gameMan.day + " days\nLocations Visited: "+ gameMan.travelCount;
        yield return new WaitForSeconds(1);
        deathMenuButton.SetActive(true);
    }
}
