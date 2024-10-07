using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCharacter : GameBehaviour
{
    [Header("ObjCharacter")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Transform objMove;
    public Transform ObjMove => objMove;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadModel();
        this.LoadMovement();
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
        this.objMove = transform.Find("Movement");
        Debug.Log(transform.name + ": LoadMovement", gameObject);
    }
}
