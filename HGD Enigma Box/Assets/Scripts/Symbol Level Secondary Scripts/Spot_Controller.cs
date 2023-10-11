using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spot_Controller : MonoBehaviour {
    public int number;      //The number in this Spot
    public TMP_Text text;   //The text object for this spot

    /// <summary>
    /// This method just sets the number text in the associated spot to the number that is supposed to be at this level
    /// </summary>
    public void SetNum() {
        text = this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        text.text = number.ToString();
    }
}
