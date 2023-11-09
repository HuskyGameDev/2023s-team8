using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/**
* @author Wade Canavan 
*
* created to be able to drag objects around in level editor.
*/
public class DragObject : MonoBehaviour
{

    public GameObject childObject;
    public Vector3 maxVelocity, minVelocity;
    private Vector3 mOffset;
    private Vector3 lastCoord;
    private float mZCoord;
    private bool mDragging = false;

    void Update()
    {

    }

    /** gets the coordinates the object should be moved to position when the mouse is clicked */
    void OnMouseDown()
    {
        mDragging= true;
        if (mDragging) {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //gets the current z position of the gameObject

            childObject.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePosition;
            childObject.GetComponent<Rigidbody2D>().mass = (float)0.0001;

            // Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
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

    void OnMouseUp()
    {
        mDragging = false;
        childObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        childObject.GetComponent<Rigidbody2D>().mass = 1000000;
        transform.position = childObject.transform.position;
        childObject.transform.position = transform.position;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //mDragging = false;
    }

    /** transforms game object to xy coordinates of mouse*/
    void OnMouseDrag()
    {
        if (enabled && mDragging)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }
}
