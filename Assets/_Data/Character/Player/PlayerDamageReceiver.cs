using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [Header("Ship Damage Receiver")]
    [SerializeField] protected ObjCharacter objCharacter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.objCharacter != null) return;
        this.objCharacter = transform.parent.GetComponent<ObjCharacter>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.objCharacter.Despawn.DespawnObject();
    }
}
