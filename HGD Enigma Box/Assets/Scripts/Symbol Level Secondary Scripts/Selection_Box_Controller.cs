using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Box_Controller : MonoBehaviour {
    public int correctNum;                  //The correct number for this box
    public int currNum;                     //The current number in the box
    public bool correct = false;            //Whether or not the number currently in the box is correct
    private Choices_Box_Controller curr;    //The currently selected Choices box controller

    private List<int> choice_Box_1_Nums;    //The list for the numbers in the first choices box
    private List<int> choice_Box_2_Nums;    //The list for the numbers in the second choices box
    public List<int> duplicates;            //The list of all duplicates between the first two lists, this includes the correct number

    /// <summary>
    /// This initiallizes all of the numbers for the boxes corresponding to the selection box this script is on
    /// </summary>
    private void Start() {
        currNum = 0;
        correctNum = Random.Range(0, 10);   //Choose the number that will be considered "correct" for the choice boxes below
        for (int i = 1; i < 3; i++) {       //Grab the 3 choice boxes below this selction box, skip the first object as that is just a text object
            curr = this.transform.GetChild(i).GetComponent<Choices_Box_Controller>();
            curr.correctNum = correctNum;   //Set the correct number
            curr.SetNums();                 //Call method to intialize values
            if (i == 1) {                   //Grab the list from the first box
                choice_Box_1_Nums = curr.spotNums;
            } else if (i == 2) {            //Grab the list from the second box
                choice_Box_2_Nums = curr.spotNums;
            }
        }
        for (int i = 0; i < 5; i++) {       //Check for each value in the list of numbers if there are duplicates in the second box
            if (choice_Box_2_Nums.Contains(choice_Box_1_Nums[i])) {
                duplicates.Add(choice_Box_1_Nums[i]);   //Add duplicates to their own list, this includes the correct number as that will always be a duplicate
            }
        }
        curr = this.transform.GetChild(3).GetComponent<Choices_Box_Controller>();
        curr.correctNum = correctNum;
        curr.SetNums(duplicates);           //Call the method with a list parameter to generate numbers without making more duplicates
        CheckNum();                         //Make sure the selection box isnt already correct, if so set value to true
    }

    /// <summary>
    /// This method checks to see if the number currently selected
    /// is the correct number for the corresponding boxes
    /// </summary>
    public void CheckNum() {
        if (correctNum == currNum) {
            correct = true;
        } else {
            correct = false;
        }
    }
}
