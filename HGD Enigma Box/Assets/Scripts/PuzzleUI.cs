using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleUI : MonoBehaviour
{
    public GameManager gameManager;
    public int fillerNumber;
    //back button used for primary levels
    public void BackPrimary(){
        SceneManager.LoadScene("Level Select");
    }
    //back button used for secondary levels
    public void BackSecondary()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    //allows a button to finish a level; mainly used for filler levels that aren't implemented yet
    public void fillerFinish() {
        gameManager.pogressMade(fillerNumber, false);
    }

}
