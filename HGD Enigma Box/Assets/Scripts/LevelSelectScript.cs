using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public int level;
    public void LevelSelect() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
    }
}
