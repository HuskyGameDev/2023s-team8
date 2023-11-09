using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovementScript : MonoBehaviour
{ 
    public GameObject selectedObject;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
        
    void Update()
    {
        //get the position of the mouse based on the camera
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if left mouse click is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //check to see if a collider exists where the mouse positions is
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            //if a collider object exists
            if (targetObject)
            {
                //get the parent game object of the collider
                selectedObject = targetObject.transform.gameObject;
                /*this offset is used to make sure the selected object doesn't go behind the screen
                 * it normally will make the object disappear becausue the mouse position will be
                 * calculated using the camera, making the z-position at the camera and make the object
                 * disappear. 
                 * 
                 * TLDR: the object won't disappear when clicked on
                 */
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        //if there is an object that is being selected
        if (selectedObject)
        {
            //drag the object to the right spot
            selectedObject.transform.position = mousePosition + offset;
        }
        //if the left mouse button is let go and there was an object, set it back to null
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }
}
