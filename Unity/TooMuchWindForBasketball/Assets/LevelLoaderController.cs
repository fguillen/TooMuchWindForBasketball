using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderController : MonoBehaviour
{
    Animator animator;
    string sceneToLoad;

    public static LevelLoaderController instance;

    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        FadeOut();
    }

    void FadeIn(){
        animator.SetTrigger("fadeIn");
    }

    void FadeOut(){
        animator.SetTrigger("fadeOut");
    }

    void FadeInFinished(){
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadScene(string sceneName)
    {
        this.sceneToLoad = sceneName;
        FadeIn();
    }
}
