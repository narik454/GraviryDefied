using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intarface : MonoBehaviour
{
    public TimeScript timeScript;
    public carController carController;
    public GameObject pausePanel;
    private MenuScript menuScript;
    public GameObject losePanel;

    private void Awake()
    {
        menuScript = Camera.main.GetComponent<MenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeScript.finishPanel.activeSelf == true)
        {
            for (int i = 0; i < carController.ControleCar.Length; i++)
            {
                carController.ControleCar[i].clickedIs = false;
                carController.ControleCar[i].gameObject.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (pausePanel.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (pausePanel.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }
}