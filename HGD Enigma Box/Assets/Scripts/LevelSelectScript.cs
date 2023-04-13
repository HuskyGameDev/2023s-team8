using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/**
Just a comment for anyone trying to make a scene that can be travelled to:
If you need to travel to a scene, make sure to add the scene to the build manager
and DO NOT PUT IT BEFORE THE LEVELS, otherwise I have to change all of the buttons
to go to the correct scene
*/
public class LevelSelectScript : MonoBehaviour
{
    public Button[] levelButtons;
    void Start(){
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for(int i = 0; i < levelButtons.Length; i++){
            if(i+1 > levelReached){
            levelButtons[i].interactable = false;
            }
        }
    }

    public void LevelSelect(string nextLevel) {
        SceneManager.LoadScene("Level " + nextLevel);
    }
    public void Back(){
        SceneManager.LoadScene("MainMenuScene");
    }
}
