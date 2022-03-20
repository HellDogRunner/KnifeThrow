using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    // Start is called before the first frame update
    public void nextlevel() {
        Application.LoadLevel(0);

    }
    public void exit() 
    {
        Application.Quit();
    }
}
