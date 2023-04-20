using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

 public void BackButton()
 {
 UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
 }
}
