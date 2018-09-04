using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScript : MonoBehaviour
{
    public GameObject scrollPanel; // Панель с номером уровней
    public GameObject exitPanel; // Панель выхода
    public Text bestTime; // Текстовое поле для отображения времени

    void Update()
    {
        if (scrollPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            scrollPanel.SetActive(false);
        }
        else if (exitPanel.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(false);
        }

        StreamReader reader = new StreamReader("BestTime.an");
        bestTime.text = "Лучшее время: " + reader.ReadLine();
        reader.Close();
    }

    public void OnClickStart()
    {
        scrollPanel.SetActive(true);
    }

    public void OnClickBack()
    {
        exitPanel.SetActive(false);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void levelButtons(int lvl)
    {
        SceneManager.LoadScene(lvl);
        Time.timeScale = 1;
    }
}
