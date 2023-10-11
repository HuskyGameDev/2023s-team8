//Currently Used by: Level Select Scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelectScript : MonoBehaviour
{
    public Button[] levelButtons;
    void Start(){
        // this line of code will reset player progress
        //PlayerPrefs.SetInt("levelReached", 1);
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        //loop through all the level buttons and make any levels after
        //levelReached false
        for(int i = 0; i < levelButtons.Length; i++){
            if(i+1 > levelReached){
            levelButtons[i].interactable = false;
            }
        }
    }
    //nextLevel will be the level the player wants to go to
    public void LevelSelect(string nextLevel) {
        SceneManager.LoadScene("Level " + nextLevel);
    }
    //back button simply sends them to the main menu
    public void Back(){
        SceneManager.LoadScene("MainMenuScene");
    }
}
