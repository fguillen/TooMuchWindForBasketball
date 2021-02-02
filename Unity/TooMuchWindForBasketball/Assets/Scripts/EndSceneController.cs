using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class EndSceneController : MonoBehaviour
{
    public static EndSceneController instance;
    Joint2D joint;
    [SerializeField] Vector3 finalPosition;
    WindTargetController windTargetController;
    Rigidbody2D rb;
    AudioSource audioSource;

    bool isStarted;

    [SerializeField] GameObject textObject;

    void Awake()
    {
        instance = this; 

        joint = GetComponent<Joint2D>();
        rb = GetComponent<Rigidbody2D>();
        windTargetController = GetComponent<WindTargetController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void GoToTheCamera()
    {
        audioSource.Play();
        transform.DOMove(finalPosition, 2f).SetEase(Ease.InQuint).OnComplete(OnCamera);
        transform.DOLocalRotate(new Vector3(3f, 10f, 0f), 0.05f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetRelative();
    }

    void OnCamera()
    {
        transform.DOKill();
        transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 1f).SetEase(Ease.OutBounce).OnComplete(TouchingCamera);
        transform.DOMove(finalPosition, 2).SetEase(Ease.InQuint);
    }

    void TouchingCamera()
    {
        joint.enabled = true;

        Invoke("ActivateWind", 2f);
        Invoke("ShowEndButtons", 4f);
    }

    void ActivateWind()
    {
        windTargetController.enabled = true;
    }

    void ShowEndButtons()
    {
        CanvasController.instance.ShowEndButtons();
    }

    public void StartEndScene()
    {
        if(!isStarted)
        {
            isStarted = true;
            textObject.SetActive(true);
            joint.enabled = false;
            GoToTheCamera();
        }
    }
}
