using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource menuSound;
    public AudioSource buttonSound;
    public bool isPaused;
    public GameObject thePauseButton;
    public Sprite pauseSprite;
    public Sprite resumeSprite;

    // Start is called before the first frame update
    private void Start()
    {
        pauseMenu.SetActive(false);
        thePauseButton.GetComponent<Image>().sprite = pauseSprite;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuSound();
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseButton()
    {
        MenuSound();
        if(isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        thePauseButton.GetComponent<Image>().sprite = resumeSprite;
    }

    public void MenuSound()
    {
        menuSound.Play();
    }

    public void ButtonSound()
    {
        buttonSound.Play();
    }

    public void MainMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        thePauseButton.GetComponent<Image>().sprite = pauseSprite;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}