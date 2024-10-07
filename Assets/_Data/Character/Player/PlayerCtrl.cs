using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : ObjCharacter
{
    [Header("PlayerCtrl")]
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }
}
