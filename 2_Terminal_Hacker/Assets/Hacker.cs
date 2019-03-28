using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "Pet", "Bed", "Room", "Cat", "Dog" };
    string[] level2Passwords = { "Tanks", "Uniform", "Chairs", "Production", "Workers" };
    string[] level3Passwords = { "Paperless", "Automation", "Dispenser", "Construction", "Supercomputer" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What are you here to hack into? \n\n");
        Terminal.WriteLine("Press 1 for a resident house \n");
        Terminal.WriteLine("Press 2 for a factory \n");
        Terminal.WriteLine("Press 3 for a bank \n\n");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web, close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "117") // easter egg
        {
            Terminal.WriteLine("Please select a level, Master Chief!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Look at the cat!");
                Terminal.WriteLine("Play again for a greater challenge!");
                Terminal.WriteLine(@"
       /\_/\
  /\  / o o \
 //\\ \~(*)~/
 `  \/   ^ /
    | \|| ||  
    \ '|| ||  
     \)()-())
"               );
                break;
            case 2:
                Terminal.WriteLine("Look at the factory!");
                Terminal.WriteLine("Play again for a greater challenge!");
                Terminal.WriteLine(@"
   i______i
   I______I
   I      I
   I______I
  /      /I
 (______( I
 I I    I I
 I      I
");
                break;
            case 3:
                Terminal.WriteLine("Look at the money!");
                Terminal.WriteLine(@"
 _ __ ___   ___  _ __   ___ _   _ 
| '_ ` _ \ / _ \| '_ \ / _ \ | | |
| | | | | | (_) | | | |  __/ |_| |
|_| |_| |_|\___/|_| |_|\___|\__, |
                             __/ |
                            |___/ 
");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
}
