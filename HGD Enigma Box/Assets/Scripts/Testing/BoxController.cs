using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {
    public LevelController levelController;
    private SpringJoint2D springJoint;

    private void Start() {
        this.springJoint = this.GetComponentInParent<SpringJoint2D>();
    }

    private void OnMouseDown() {
        levelController.Move(this.springJoint);
    }

    private void OnMouseDrag() {
        levelController.Move(this.springJoint);
    }

    private void OnMouseUp() {
        levelController.Release(this.springJoint);
    }
}
