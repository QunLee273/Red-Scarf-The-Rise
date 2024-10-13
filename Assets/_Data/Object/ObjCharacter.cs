using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCharacter : GameBehaviour
{
    [Header("ObjCharacter")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected ObjMovement objMove;
    public ObjMovement ObjMove => objMove;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadModel();
        this.LoadMovement();
        this.LoadDamageReceiver();
        this.LoadDespawn();
    }

    protected void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected void LoadMovement()
    {
        if (this.objMove != null) return;
        this.objMove = GetComponentInChildren<ObjMovement>();
        Debug.Log(transform.name + ": LoadMovement", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
}
