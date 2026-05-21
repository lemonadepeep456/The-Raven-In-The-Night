using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManagerScript : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManagerScript instance {  get; private set; }

    private void Awake()
    {
        if(instance != null )
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
         
        }
        instance = this;
    }
    private void Start()
    {
        LoadGame();
        
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }   

    public void LoadGame()
    {
        // TODO - Load any saved data from a file using the data handle
        // if no data can be loaded, initalize a new game!
        if (this.gameData == null)
        {

            Debug.Log("No data was found. Initallizing data to defaults.");
            NewGame();
        }
        //To do - Push the loaded data to all other scripts that need it.
    }   


    public void SaveGame()
    {
        //TO DO pass data to other scripts to update it and save that data to a file using the data handler.
    }
    private void OnApplicationQuit()
    {
        SaveGame();

    }
}