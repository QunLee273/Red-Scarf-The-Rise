using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : ObjCharacter
{
    
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [Header("PlayerCtrl")]
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadRigidbody();
        this.LoadAnimator();
    }

    protected void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = Model.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}
