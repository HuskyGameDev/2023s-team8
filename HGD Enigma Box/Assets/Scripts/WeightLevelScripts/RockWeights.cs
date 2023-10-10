using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Currently only useful for the weight level as this is specific but may be able
 * to be changed later so that it can work for multiple levels.
 * Currently testing ways to make it work so may not currently make sense
*/
public class RockWeights : MonoBehaviour
{
    //Gets the sprite renderer so that the sprite can be changed
    SpriteRenderer spriteRenderer;
    //The two sprites for if the sprite has been selected or not
    public Sprite activated;
    public Sprite deactivated;
    //Will switch between true and false every time the sprite is clicked
    public bool selected;
    //The weight for the rock
    public int weight;

    // Start is called before the first frame update
    void Start()
    {
        //Instaniated the sprite renderer and sets the sprite to the deactivated sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deactivated;
        selected = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Will eventually change sprite and tell if it has been selected
    void OnMouseDown()
    {
        if(selected == false)
        {
            spriteRenderer.sprite = activated;
            selected = true;
        }
        else
        {
            spriteRenderer.sprite = deactivated;
            selected = false;
        }

    }
}
