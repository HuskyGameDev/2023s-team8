using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @author Wade Canavan 
*
* created to be able to drag objects around in level editor.
*/
public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    void Update()
    {

    }

    /** gets the coordinates the object should be moved to position when the mouse is clicked */
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //gets the current z position of the gameObject

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    /** gets positioon of mouse*/
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    /** transforms game object to xy coordinates of mouse*/
    void OnMouseDrag()
    {
        if (enabled)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }
}
