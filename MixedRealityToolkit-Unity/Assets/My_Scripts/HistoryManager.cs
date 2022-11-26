using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryManager : MonoBehaviour
{
    [HideInInspector]
    History history;
    [HideInInspector]
    public int currentRoom = 0; // should only go 0 to 7
    public FurnitureMenu menu;


    public History History
    {
        get
        {
            return history;
        }
        set
        {
            history = value;
        }
    }

    void Start() {
        // load existing history if possible 
        //SaveLoad.DeleteSaveFiles(); // remove this later
        HistoryData dataFromFiles = SaveLoad.LoadHistorySaveDataOnStartup();
        if (dataFromFiles == null) {
            Debug.Log("no history to load from files on startup");
            history = new History();
        } else {
            Debug.Log("yes history to load from files on startup");
            history = new History(dataFromFiles);
            foreach(FurnitureData f in history.data.rooms[0].furniture) {
                menu.SetUpLoadedFurniture(f);
            }
        }
    }
        
}
