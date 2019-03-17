using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What are you here to hack into? \n\n");
        Terminal.WriteLine("Press 1 for a resident house \n");
        Terminal.WriteLine("Press 2 for a factory \n");
        Terminal.WriteLine("Press 3 for a bank \n\n");
        Terminal.WriteLine("Enter your selection: ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
