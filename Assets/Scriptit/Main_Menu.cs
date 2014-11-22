using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {

    public bool isQuit = false;
    public bool isCred = false;

    void OnMouseEnter()
    {
        renderer.material.color = Color.green;
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    void OnMouseDown()
    {
        if (isQuit)
        {
            Application.Quit();
        }
        else if (isCred)
        {
            //Application.LoadLevel(Credits); 
        }
        else
        {
            Application.LoadLevel(1); //Make sure that level "1" is located in your build settings. You can also change the 1 with a name of your scene.

        }
    }
}