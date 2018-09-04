using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikerScript : MonoBehaviour
{
    public Intarface intarface;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "map")
        {
            Time.timeScale = 0;
            intarface.losePanel.SetActive(true);
        }
    }
}
