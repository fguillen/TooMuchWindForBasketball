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

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        RenderPoints(0);
        RenderLevelName("None");
        InvokeRepeating("RenderForceAndAngle", 1.0f, 1f);
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

    public void RenderLevelName(string levelName)
    {
        levelNameText.text = "Level: \"" + levelName + "\"";
    }
}
