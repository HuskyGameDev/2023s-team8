using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleUI : MonoBehaviour
{
    public void Back(){
        SceneManager.LoadScene("Level Select");
    }
}
