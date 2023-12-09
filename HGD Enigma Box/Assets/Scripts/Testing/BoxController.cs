using UnityEngine;

public class BoxController : MonoBehaviour {
    public LevelController levelController;
    private Rigidbody2D rigidBody2D;

    /**
     * This is simply making referencing the object's regidbody easier and saving some computation.
     * Additionally making sure that all boxes have the proper freeze tags enabled.
    */
    private void Start() {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    /**
     * When the mouse is pressed ontop of a box this method is called.
     */
    private void OnMouseDown() {
        levelController.Move(rigidBody2D);                                  //Set the rigidbody to be moved.
    }

    /**
     * When the mouse is released ontop of a box this method is called.
     */
    private void OnMouseUp() {
        levelController.Release();                                          //Release the currently held box.
    }

    /**
     * This method is optional but I included it due to you wanting the boxes to be dropped when they collided, at least from my understanding.
     * This method is called when the box makes contact with another collider.
     * Note that in further implementation this may have to be tweaked to work properly, just contact me if you need help.
     */
    private void OnCollisionEnter2D(Collision2D collision) {
        levelController.Release();                                          //Release the currently held box
    }
}
