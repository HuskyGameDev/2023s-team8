using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Selection_Button : MonoBehaviour {
    public GameObject selection_Box;                            //The selection box associated with the button this script is on
    public bool up;                                             //Whther or not the button is an up or down button
    private TMP_Text selection_Box_Text;                        //The text object on the associated selection box
    private Selection_Box_Controller selection_Box_Controller;  //The controller for the associated selection box

    /// <summary>
    /// This just sets up the text element and the controller element off of the selection box object
    /// </summary>
    private void Start() {
        selection_Box_Text = selection_Box.transform.GetChild(0).GetComponent<TMP_Text>();
        selection_Box_Controller = selection_Box.GetComponent<Selection_Box_Controller>();
    }

    /// <summary>
    /// This method changes the number in the selection box when the associated button is pressed.
    /// </summary>
    private void OnMouseDown() {
        int _curr = selection_Box_Controller.currNum;   //Set an easier to refference variable equal to desired value
        if (up) {                                       //Check if the button is supposed to go up or down
            _curr = ++_curr % 10;                       //Increment and account for overflow when the number reaches 10
        } else {
            _curr = (--_curr + 10) % 10;                //Decrement and account for overflow when the number reaches -1
        }
        selection_Box_Controller.currNum = _curr;       //Set the current number variable equal to the new one
        selection_Box_Text.text = _curr.ToString();     //Set the current number text to the proper number
        selection_Box_Controller.CheckNum();
    }
}
