using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Controller : MonoBehaviour {
    public bool on;
    private SpriteRenderer sprite;
    private Color red;
    private Color green;

    private void Start() {
        red = new Color(0.5f, 0f, 0f);
        green = new Color(0.19f, 0.83f, 0);

        this.on = false;
        sprite = this.GetComponent<SpriteRenderer>();

        sprite.color = red;
    }

    public void changeState() {
        if (on) {
            sprite.color = red;
            this.on = false;
        } else {
            sprite.color = green;
            this.on = true;
        }
    }
}
