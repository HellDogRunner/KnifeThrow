using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public Throw data;
    private void Start()
    {
        //SaveGame();
    }
   public void SaveGame()
    {
        PlayerPrefs.SetInt("Apples", data.apples);
        PlayerPrefs.SetInt("Score", data.score);
        PlayerPrefs.SetInt("CurrLevel", data.currlevel);
        if (data.currlevel> PlayerPrefs.GetInt("MaxLevel"))
        {
            PlayerPrefs.SetInt("MaxLevel", data.currlevel);
        }
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
            data.apples = PlayerPrefs.GetInt("Apples");
            data.score = PlayerPrefs.GetInt("Score");
            data.currlevel = PlayerPrefs.GetInt("CurrLevel");
            Debug.Log("Game data loaded!");

    }
}
