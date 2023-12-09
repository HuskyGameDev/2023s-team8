using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function will determine if he level has been finished
    public void pogressMade(int finishedLevel, bool isSecondary){
        //if we beat a secondary level
        if (isSecondary)
        {
            //update the secondary level reached to show that we beat the level
            if (finishedLevel == PlayerPrefs.GetInt("secondaryLevelReached", 1)) {
                PlayerPrefs.SetInt("secondaryLevelReached", finishedLevel + 1);
            }
            SceneManager.LoadScene("MainMenuScene");
        }
        else
        {
            //if the finished level is the same as the one the player has reached, increase the level reached by 1
            if (finishedLevel == PlayerPrefs.GetInt("levelReached", 1))
            {
                PlayerPrefs.SetInt("levelReached", finishedLevel + 1);
            }
            //if the finished level is 1, 2, or 4, unlock their corresponding secondary levels
            if (finishedLevel == 1)
            {
                PlayerPrefs.GetInt("secondaryLevelUnlocked", 0);
                PlayerPrefs.SetInt("secondaryLevelUnlocked", 1);
            }
            else if (finishedLevel == 2)
            {
                PlayerPrefs.GetInt("secondaryLevelUnlocked", 0);
                PlayerPrefs.SetInt("secondaryLevelUnlocked", 2);
            }
            if (finishedLevel == 4)
            {
                PlayerPrefs.GetInt("secondaryLevelUnlocked", 0);
                PlayerPrefs.SetInt("secondaryLevelUnlocked", 3);
            }
            SceneManager.LoadScene("Level Select");
        }

    }
}
