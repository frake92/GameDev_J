using UnityEngine;
using UnityEngine.InputSystem;

public class FirstScript : MonoBehaviour
{
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0, 0, 255);
    }

    /*
    private void Awake()
    {
        
    }
    */

    // Update is called once per frame
    //20fps -> 1 sec alatt 20x 
    void Update()
    {
        if (Keyboard.current.eKey.isPressed)
        {
            sr.color = new Color(255, 0, 0);
        }
    }

    //60x 120fps, 240fps
    /*
    private void FixedUpdate()
    {
        
    }
    */

}
