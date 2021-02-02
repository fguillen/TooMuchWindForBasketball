using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenController : MonoBehaviour
{
    bool isPaused;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        animator.SetBool("isPaused", true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        animator.SetBool("isPaused", false);
    }

    public void ResumeGameFinished()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
