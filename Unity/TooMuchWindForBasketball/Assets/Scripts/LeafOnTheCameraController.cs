using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeafOnTheCameraController : MonoBehaviour
{
    [SerializeField] Vector2 timeToLiveLimits;
    [SerializeField] Joint2D joint;
    float timeToLiveCounter;
    bool isOnTheCamera;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        // Invoke("GoToTheCamera", 10f);
        // GoToTheCamera();

        joint = GetComponent<Joint2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(isOnTheCamera)
        {
            CheckIfItShouldBeRelieved();
        }
    }

    void CheckIfItShouldBeRelieved(){
        timeToLiveCounter -= Time.deltaTime;
        if(timeToLiveCounter <= 0)
        {
            Relieve();
        }
    }

    void Relieve()
    {
        joint.enabled = false;
        isOnTheCamera = false;

        gameObject.layer = LayerMask.NameToLayer("NoStickyLeaves");
    }

    public void GoToTheCamera()
    {
        gameObject.layer = LayerMask.NameToLayer("OnCameraLeaves");

        Vector3 inCameraPoint = GetInCameraPoint();
        transform.DOMove(inCameraPoint, 2).SetEase(Ease.InQuint).OnComplete(OnCamera);
        transform.DOLocalRotate(new Vector3(3f, 10f, 0f), 0.05f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetRelative();

        spriteRenderer.sortingLayerName = "InFrontOfCamera";
    }

    void OnCamera()
    {
        print("I'm in the Camera");
        transform.DOKill();
        transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 1f).SetEase(Ease.OutBounce).OnComplete(TouchingCamera);
    }

    void TouchingCamera()
    {
        isOnTheCamera = true;
        joint.enabled = true;
        timeToLiveCounter = Random.Range(timeToLiveLimits.x, timeToLiveLimits.y);
    }

    Vector3 GetInCameraPoint()
    {
        Vector3 cameraPointLimitNW = LeavesOnTheCameraController.instance.cameraPointLimitNW.position;
        Vector3 cameraPointLimitSE = LeavesOnTheCameraController.instance.cameraPointLimitSE.position;

        float x = Random.Range(cameraPointLimitNW.x, cameraPointLimitSE.x);
        float y = Random.Range(cameraPointLimitNW.y, cameraPointLimitSE.y); 
        float z = Random.Range(cameraPointLimitNW.z, cameraPointLimitSE.z); 

        return new Vector3(x, y , z);
    }
}
