using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public static class SaveSystem
{
    public static void SavePlayer(GameMan player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/MySaveLocation";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/MySaveLocation";
        if (File.Exists(path))
        {
            Debug.LogError("It exists");
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                GameObject.Find("MenuCanvas").GetComponent<Menu>().saveExists = true;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("It doesnt exist");
            //Debug.Log("Save file not found in " + path);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                GameObject.Find("ContinueText").GetComponent<TextMeshProUGUI>().color = new Color32(82, 82, 82, 255);
                GameObject.Find("ContinueButton").GetComponent<Button>().interactable = false;
                GameObject.Find("MenuCanvas").GetComponent<Menu>().saveExists = false;
            }
            else if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                GameObject.Find("GameManager").GetComponent<GameMan>().StartingLoot();
            }
            return null;
        }
    }
    public static void SeriouslyDeleteAllSaveFiles()
    {
        Debug.LogError("1");
        string path = Application.persistentDataPath;
        DirectoryInfo directory = new DirectoryInfo(path);
        Debug.LogError("3");
        //STOPS HERE. IDK WHY!
        directory.Delete(true);
        Debug.LogError("4");
        Directory.CreateDirectory(path);
        Debug.LogError("5");
        //SceneManager.LoadScene(0);
    }
}
