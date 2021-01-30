using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    Rigidbody2D rb;
    WindTargetController windTargetController;
    LeafController leafController;

    [SerializeField] float firstImpulseForce;

    void Awake()
    {
        windTargetController = GetComponent<WindTargetController>();
        leafController = GetComponent<LeafController>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void WindTargetEnabled(bool value)
    {
        rb.isKinematic = !value;
        windTargetController.enabled = value;
        leafController.enabled = value;
        rb.AddForce(new Vector2(0.5f, 1f) * firstImpulseForce, ForceMode2D.Impulse);
    }
}
