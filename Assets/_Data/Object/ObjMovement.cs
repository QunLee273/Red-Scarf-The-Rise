using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : GameBehaviour
{
    [Header("ObjMovement")]
    [SerializeField] protected Vector2 targetPosition;
    [SerializeField] protected float walkSpeed = 2.5f;
    [SerializeField] protected float runSpeed = 4f;

    [SerializeField] protected Transform model;

    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadModel();
        this.LoadRigidbody();
        this.LoadAnimator();
    }

    protected void LoadModel()
    {
        if (this.model != null) return;
        this.model = GameObject.Find("Player/Model")?.transform;
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = model.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = model.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}
