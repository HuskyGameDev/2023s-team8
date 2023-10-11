using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices_Box_Controller : MonoBehaviour {
    public int correctNum;          //The correct number for the selection box associated with this choices box
    public int correctNumLocation;  //The location of the correct number in this choices box
    public List<int> spotNums;      //The list of all numbers in this choices box
    private Spot_Controller curr;   //The spot controller for the currently selected spot that is being updated

    /// <summary>
    /// This method sets the numbers for the choices box the script is attatched to
    /// </summary>
    public void SetNums() {
        correctNumLocation = Random.Range(0, 5);    //Chose the location to put the correct number
        for (int i = 0; i < 5; i++) {               //For each location in the box
            curr = this.transform.GetChild(i).gameObject.GetComponent<Spot_Controller>();   //Grab Spot controller to modify the current spot

            do {
                curr.number = Random.Range(0, 10);  //Select a random number
            } while (curr.number == correctNum);    //If the selected number is equal to the correct number, try again

            if (i == correctNumLocation) {          //Set the number at the correct number's location to the correct number
                curr.number = correctNum;
            }

            spotNums.Add(curr.number);              //Add the number set to a list of all numbers in this box
            curr.SetNum();                          //Update the number shown on the box to be the desired value
            curr = null;
        }
    }

    /// <summary>
    /// This method sets the numbers for the choices box the script is attatched to, additionally it makes sure that none of the numbers in the duplicates parameter are present in this choices box
    /// </summary>
    /// <param name="duplicates">
    /// This parameter is the list of duplicates for the two other choices boxes in this column
    /// </param>
    public void SetNums(List<int> duplicates) {
        correctNumLocation = Random.Range(0, 5);
        for (int i = 0; i < 5; i++) {
            curr = this.transform.GetChild(i).gameObject.GetComponent<Spot_Controller>();

            do {
                curr.number = Random.Range(0, 10);
            } while (duplicates.Contains(curr.number)); //Only difference to SetNums() is now this condition is checking if the duplicates list contains

            if (i == correctNumLocation) {
                curr.number = correctNum;
            }

            curr.SetNum();
            curr = null;
        }
    }
}
