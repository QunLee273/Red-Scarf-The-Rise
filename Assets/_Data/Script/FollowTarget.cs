using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : GameBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected Vector3 offset = new Vector3(0, 1, 0); // khoảng cách cách target, ở đây cách 1 đơn vị phía trên


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected void LoadTarget()
    {
        if (this.target != null) return;
        GameObject player = GameObject.Find("Player/Model");
        if (player != null)
        {
            this.target = player.transform;
            Debug.Log(transform.name + ": LoadTarget", gameObject);
        }
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        // Camera sẽ di chuyển tới vị trí của target + offset (ở trên target)
        Vector3 targetPosition = this.target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * this.speed);
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
