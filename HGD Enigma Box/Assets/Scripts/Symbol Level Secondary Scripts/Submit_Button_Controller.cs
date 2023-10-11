using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit_Button_Controller : MonoBehaviour {
    [SerializeField] GameObject SB0;        //First selection box object
    [SerializeField] GameObject SB1;        //Second selection box object
    [SerializeField] GameObject SB2;        //Third selection box object
    private Selection_Box_Controller SBC0;  //First selection box controller
    private Selection_Box_Controller SBC1;  //Second selection box controller
    private Selection_Box_Controller SBC2;  //Third selection box controller

    /// <summary>
    /// This just initiallizes all of the controllers we will be referencing.
    /// </summary>
    private void Start() {
        SBC0 = SB0.GetComponent<Selection_Box_Controller>();
        SBC1 = SB1.GetComponent<Selection_Box_Controller>();
        SBC2 = SB2.GetComponent<Selection_Box_Controller>();
    }

    /// <summary>
    /// This method simply checks if all the selection boxes are correct then allows the player to win if this is true.
    /// </summary>
    private void OnMouseDown() {
        if (!SBC0.correct || !SBC1.correct || !SBC2.correct) {  //Check to see if any values are incorrect
            return;
        }
        Debug.Log("You win");                                   //WIN METHOD CALL HERE
        return;
    }
}
