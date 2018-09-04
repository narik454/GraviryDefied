using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TimeScript : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;
    public Text time;
    public GameObject finishPanel;

    void Start () // Запускается при запуске сцены
    {
        startTime = Time.time;
    }

    void Update ()
    {
        if (finished)
            return;

        float t = Time.time - startTime;

        string timer = t.ToString("f3");

        timerText.text = "Время: " + timer;
    }

    private void OnTriggerEnter2D(Collider2D trigger) // Срабатывает при соприкосновении с объектом "Finish"
    {
        if (trigger.gameObject.tag == "Finish")
        {
            finishPanel.SetActive(true);
            GameObject.Find("bike").SendMessage("Finish");
            time.text = timerText.text;

            StreamReader reader = new StreamReader("BestTime.an");
            float[] timeMass = new float[6];
            int i = 0;
            string times = reader.ReadLine();
            while (times != null)
            {
                timeMass[i] = float.Parse(times);
                i++;
                times = reader.ReadLine();
            }
            reader.Close();

            if ((float.Parse(time.text.Substring(7)) <= timeMass[0]) && (timeMass[0] != 0))
            {
                StreamWriter writer = new StreamWriter("BestTime.an");
                writer.WriteLine(time.text.Substring(7));
                for (int j = 1; j < timeMass.Length; j++)
                {
                    writer.WriteLine(timeMass[j]);
                }
                writer.Close();    
            }
        }
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
    }
}
