using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {
    public LevelController levelController;
    private SpringJoint2D springJoint;
    private Rigidbody2D rigidbody;

    private void Start() {
        this.springJoint = this.GetComponentInParent<SpringJoint2D>();
        this.rigidbody = this.GetComponentInParent<Rigidbody2D>();
    }

    private void OnMouseDown() {
        levelController.Move(this.rigidbody);
    }

    private void OnMouseUp() {
        levelController.Release();
        rigidbody.velocity = Vector2.zero;
    }
}
