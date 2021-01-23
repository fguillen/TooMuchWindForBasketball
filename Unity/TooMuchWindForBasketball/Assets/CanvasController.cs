using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{

    public static CanvasController instance;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        RenderPoints(0);
    }

    

    public void RenderPoints(int points)
    {
        text.text = points.ToString();
    }
}
