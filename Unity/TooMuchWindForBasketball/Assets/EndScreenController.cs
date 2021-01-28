using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] Joint2D joint;
    bool isOnTheCamera;
    [SerializeField] Vector3 finalPosition;
    WindTargetController windTargetController;

    Rigidbody2D rb;
    void Start()
    {
        // Invoke("GoToTheCamera", 10f);
        GoToTheCamera();

        joint = GetComponent<Joint2D>();
        rb = GetComponent<Rigidbody2D>();
        windTargetController = GetComponent<WindTargetController>();
        joint.enabled = false;
    }

    public void GoToTheCamera()
    {
        transform.DOMove(finalPosition, 2).SetEase(Ease.InQuint).OnComplete(OnCamera);
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
        isOnTheCamera = true;
        joint.enabled = true;

        Invoke("ActivateWind", 2f);
    }

    void ActivateWind()
    {
        windTargetController.enabled = true;
    }
}
