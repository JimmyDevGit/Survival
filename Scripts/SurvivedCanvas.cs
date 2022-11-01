using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SurvivedCanvas : MonoBehaviour
{
    public GameMan gameMan;
    public GameObject MenuButton;
    public GameObject youSurvivedText;
    public GameObject reasonGO;
    public GameObject daysSurvivedGO;
    public TextMeshProUGUI reasonText;
    public TextMeshProUGUI daysSurvived;
    public AudioManager audioManager;
    private void Start()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void DeathMenuButton()
    {
        audioManager.Play("Clave");
        gameMan.StopAllSounds();
        SaveSystem.SeriouslyDeleteAllSaveFiles();
        SceneManager.LoadScene(0);
    }
    //Call this function at the same time as enabling canvas
    public IEnumerator SurvivedButtonDelay(bool MaxDaysReached)
    {
        yield return new WaitForSeconds(1);
        youSurvivedText.SetActive(true);
        yield return new WaitForSeconds(1);
        if(MaxDaysReached == false)
        {
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                reasonText.text = "You found a road and walked along it until you found a town";
            }
            else if (rand == 1)
            {
                reasonText.text = "You found a camp and got led back to safety by the campers";
            }
            else
            {
                reasonText.text = "A small boat passed by and rescued you";
            }
        }
        else
        {
            reasonText.text = "A helicopter search party spotted you";
        }
        reasonGO.SetActive(true);
        yield return new WaitForSeconds(1);
        daysSurvived.text = "Days Survived: " + gameMan.day;
        daysSurvivedGO.SetActive(true);
        yield return new WaitForSeconds(1);
        daysSurvived.text = "Days Survived: " + gameMan.day+"\nLocations Visited: "+gameMan.travelCount;
        yield return new WaitForSeconds(1);
        MenuButton.SetActive(true);
    }
}
