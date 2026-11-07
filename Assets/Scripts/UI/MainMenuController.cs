using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuButtons;
    public GameObject options;

    public Toggle fullscreen;

    public TextMeshProUGUI inputfield;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            options.SetActive(false);
        }

        if(fullscreen.isOn == true)
        {
            inputfield.text = "Fullscreen BE";
        }

    }

    public void OpenOptions()
    {
        options.SetActive(true);
    }

    public void ToggleON()
    {
        Debug.Log("Fullscreen modeban vagyunk");
    }


    public void Game()
    {
        SceneManager.LoadScene("Level2");
    }

}
