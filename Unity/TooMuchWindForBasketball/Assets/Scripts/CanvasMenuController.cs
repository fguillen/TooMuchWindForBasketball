using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuController : MonoBehaviour
{
    [SerializeField] GameObject credits;

    public void ShowCredits()
    {
        CreditsController.instance.Show();
    }

    public void Play()
    {
        LevelLoaderController.instance.LoadScene("Game");
    }

    public void ShowHowToPlay()
    {
        HowToPlayController.instance.Show();
    }
}
