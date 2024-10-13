using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : GameBehaviour
{
    [Header("ObjMovement")]
    [SerializeField] protected Vector2 targetPosition;
    [SerializeField] protected float walkSpeed = 2.5f;
    [SerializeField] protected float runSpeed = 4f;
}
