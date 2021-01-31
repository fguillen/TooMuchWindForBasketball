using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuController : MonoBehaviour
{
    [SerializeField] GameObject credits;

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
    }

    public void Play()
    {
        LevelLoaderController.instance.LoadScene("Game");
    }
}
