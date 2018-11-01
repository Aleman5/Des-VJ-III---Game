using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
 
public static class SaveLoad
{
 
    //public static List<DataManager> saveGame = new List<DataManager>();
    public static DataManager saveGame = new DataManager();

    public static void NewGame()
    {
        saveGame.data.actualScene = "Game3D";
        saveGame.data.waveName = "wave1";
        saveGame.data.moneyCount = 0;
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/rbSave.bp");
        bf.Serialize(file, saveGame);
        Debug.Log("JUEGO CREADO?" + file);
        file.Close();

        SceneManager.LoadScene(saveGame.data.actualScene);
    }

    public static void Save()
    {
        saveGame = (DataManager.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite (Application.persistentDataPath + "/rbSave.bp");
        bf.Serialize(file, saveGame);
        Debug.Log("JUEGO GUARDADO?" + file);
        file.Close();
    }
     
    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/rbSave.bp"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/rbSave.bp", FileMode.Open);
            saveGame = (DataManager)bf.Deserialize(file);
            Debug.Log("JUEGO CARGADO?" + file);


            SceneManager.LoadScene(saveGame.data.actualScene);


            file.Close();


        }
        else
        {
            NewGame();
        }
    }
}