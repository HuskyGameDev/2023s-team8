using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScripts : MonoBehaviour
{
    //public SceneFader fader;
    public Button [] levelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("level Reached", 1);
        for(int i = 0; i < levelButtons.Length; i++)
        {
            if (i < levelReached)
            levelButtons[i].interactable = false;
        }
    }
   /* public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }*/
}
