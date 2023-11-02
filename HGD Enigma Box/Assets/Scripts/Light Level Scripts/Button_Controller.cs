using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Controller : MonoBehaviour {
    public List<Light_Controller> light_Controllers = new List<Light_Controller>();

    private void OnMouseDown() {
        foreach (Light_Controller light_Controller in light_Controllers) {
            light_Controller.changeState();
        }
    }
}
