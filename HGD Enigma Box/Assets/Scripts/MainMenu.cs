using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //I make a enum here so that what I'm adding is the number that I need to get to a certain scene
    enum Scenes { 
        LevelSelect = 1
    }
    //when the start button is pressed, send us to level select
    public void Play() {
        //So we're at scene 0 currently, I add by LevelSelect, (which is 1), to get me to the level select scene which is scene 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + (int)Scenes.LevelSelect);
    }
    public void Exit() {
        Application.Quit();
        Debug.Log("Off to visit your mother");
    }
}
