using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/**
Just a comment for anyone trying to make a scene that can be travelled to:
If you need to travel to a scene, make sure to add the scene to the build manager
and DO NOT PUT IT BEFORE THE PRIMARY LEVELS, otherwise I have to change all of the buttons
to go to the correct scene. The secondary levels are fine because of my implementation
*/
public class MainMenu : MonoBehaviour
{
    
    /**
    Level select is the next scene, so I have it be one.
    Secondary will be given by the object pressed.
    Depending on which object was pressed, it will give the
    number needed to get the it's corresponding scene
    */
    private int LevelSelect = 1;
    public string Secondary;
    //when the start button is pressed, send us to level select
    public void Play() {
        //So we're at scene 0 currently, I add by LevelSelect, (which is 1), to get me to the level select scene which is scene 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + (int)LevelSelect);
    }
    //Code to send to options menu
    public void OptionMenu() {
        SceneManager.LoadScene("Options");
    }
    //Code will do what it's supposed to when we make an executable, the debug statement is there to show that it does
    //Go in here
    public void Exit() {
        Application.Quit();
        Debug.Log("Off to visit your mother");
    }
    //Similar to level select, but instead I have a specific name and only the number given changes
    //The number given depends on which secondary scene you are being sent to
    public void GoToSecondary(){
        SceneManager.LoadScene("Secondary Level " + Secondary);
    }
}
