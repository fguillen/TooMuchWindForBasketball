using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayController : MonoBehaviour
{
    public static HowToPlayController instance;
    Animator animator;
    int slideNum;
    bool isVisible;

    [SerializeField] float nextSlideTime;
    float nextSlideTimeCounter;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        slideNum = 1;
        isVisible = false;
        nextSlideTimeCounter = nextSlideTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isVisible && 
            (
                Input.GetButtonDown("Jump") ||
                Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown("d")
            )
        )
        {
            NextSlide(); 
        }

        if(isVisible && Input.GetKeyDown("x"))
            Hide();
            

        if(isVisible)
        {
            nextSlideTimeCounter -= Time.deltaTime;

            if(nextSlideTimeCounter <= 0)
            {
                NextSlide();
            }
        }
    }

    public void NextSlide()
    {
        print("NextSlide 1: " + slideNum);

        slideNum ++;
        if(slideNum == 4)
            slideNum = 1;

        print("NextSlide 2: " + slideNum);

        animator.SetInteger("slideNum", slideNum);

        nextSlideTimeCounter = nextSlideTime;
    }

    public void Show()
    {
        if(!isVisible)
        {
            isVisible = true;
            animator.SetBool("visible", true);
            slideNum = 1;
            animator.SetInteger("slideNum", slideNum);
        }
    }

    public void Hide()
    {
        if(isVisible)
        {
            print("Hide");
            isVisible = false;
            animator.SetBool("visible", false);
            slideNum = 1;
            animator.SetInteger("slideNum", slideNum);
        }
    }
}
