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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        RenderPoints(0);
        InvokeRepeating("RenderForce", 1.0f, 0.5f);
        InvokeRepeating("RenderAngle", 1.0f, 0.5f);
    }


    public void RenderPoints(int value)
    {
        pointsText.text = "Points: " + value.ToString();
    }

    public void RenderForce()
    {
        forceText.text = "Wind Force: " + Mathf.CeilToInt(WindController.instance.GetForce()).ToString();
    }

    public void RenderAngle()
    {
        angleText.text = "Wind Angle: " + Mathf.CeilToInt(WindController.instance.GetAngle()).ToString();
    }
}
