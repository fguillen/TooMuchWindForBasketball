using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{

    public static CanvasController instance;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI forceText;
    [SerializeField] TextMeshProUGUI angleText;
    [SerializeField] TextMeshProUGUI levelNameText;
    [SerializeField] bool debugEnabled;
    bool lastDebugEnabled;
    Animator animator;

    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(lastDebugEnabled != debugEnabled)
        {
            lastDebugEnabled = debugEnabled;
            SetInvokeRepeating();
            SetDebugTextEnabled();
        }

        if(Input.GetKeyDown("o"))
        {
            debugEnabled = !debugEnabled;
        }
    }

    void SetInvokeRepeating()
    {
        if(debugEnabled)
        {
            InvokeRepeating("RenderForceAndAngle", 0f, 1f);
        } else {
            CancelInvoke("LaunchProjectile");
        }
    }

    void SetDebugTextEnabled()
    {
        forceText.enabled = debugEnabled;
        angleText.enabled = debugEnabled;
    }

    void Start()
    {
        RenderPoints(0);
        SetInvokeRepeating();
        SetDebugTextEnabled();
    }

    public void RenderPoints(int value)
    {
        pointsText.text = "Points: " + value.ToString();
    }

    public void RenderForceAndAngle()
    {
        forceText.text = "Wind Force: " + Mathf.CeilToInt(WindController.instance.GetForce()).ToString();
        angleText.text = "Wind Angle: " + Mathf.CeilToInt(WindController.instance.GetAngle()).ToString();
    }

    public void ShowLevelName(string levelName)
    {
        levelNameText.text = levelName;
        animator.SetTrigger("showLevelName");
    }
}
