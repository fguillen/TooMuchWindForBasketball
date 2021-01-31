using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuController : MonoBehaviour
{
    [SerializeField] GameObject credits;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        
    }
}
