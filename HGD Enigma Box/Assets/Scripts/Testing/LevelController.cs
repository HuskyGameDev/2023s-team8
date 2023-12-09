using UnityEngine;

public class LevelController : MonoBehaviour {
    public Vector2 mousePoint;
    private Vector2 vel;
    private Rigidbody2D curr;

    /**
     * The contents of this method are handling the movement of the box.
     */
    private void FixedUpdate() {
        if (curr) {                 //Make sure that a box is currently selected by seeing if curr is null, if it is not then it is interpreted as "true" by the statement.
            vel = curr.velocity;    //Save the current box velocity as a Vector2 so it can be referenced.
            mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);                   //Save the in-game position of the mouse only on a 2D plane since this is a Vector2.
            curr.MovePosition(Vector2.SmoothDamp(curr.position, mousePoint, ref vel, 0.025f));  //Just look at the documentation to see how this line works; in summary it moves the box with the previously gathered information.
        }
    }

    //Side note... the comment below looks ugly but is required so the decription is shown when hovering over the method name and its parameter.

    /// <summary>
    /// This method sets the rigidbody to be moved.
    /// </summary>
    /// <param name="rigidbody">
    /// The rigidbody that is going to be moved.
    /// </param>
    public void Move(Rigidbody2D rigidbody) {
        curr = rigidbody;
        curr.constraints = RigidbodyConstraints2D.FreezeRotation;   //Remove position constraints so that the box can now be moved but still cannot be rotated.
    }

    /// <summary>
    /// This method releases the currently held object.
    /// </summary>
    public void Release() {
        if (curr) {
            curr.constraints = RigidbodyConstraints2D.FreezeAll;    //Add constraints to freeze all forms of movement when the box is not held.
            curr = null;
        }
    }
}
