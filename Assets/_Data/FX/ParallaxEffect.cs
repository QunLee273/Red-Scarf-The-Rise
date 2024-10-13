using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hiệu ứng thị giác Background
public class ParallaxEffect : GameBehaviour
{
    [Header("ParallaxEffect")]
    [SerializeField] protected Camera cam;
    [SerializeField] protected Transform targetFollow;

    Vector2 startingPosition;
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    // Luôn lấy giá trị dương của khoảng cách giữa vật thể và camera
    float zDistanceTarget => Mathf.Abs(transform.position.z - targetFollow.transform.position.z);

    // Chỉ cần dùng farClipPlane nếu camera hướng tới vật thể xa
    float clippingPlane => cam.farClipPlane;

    // Điều chỉnh parallaxFactor cho Z dương
    float parallaxFactor => zDistanceTarget / clippingPlane;

    float startingZ;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCam();
        this.LoadTarget();
    }

    protected override void Start()
    {
        base.Start();
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    protected void Update()
    {
        Vector2 newPos = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startingZ);
    }

    protected void LoadCam()
    {
        if (this.cam != null) return;
        this.cam = Camera.main;
        Debug.Log(transform.name + ": LoadCam", gameObject);
    }

    protected void LoadTarget()
    {
        if (this.targetFollow != null) return;
        GameObject model = GameObject.Find("Player/Model");
        this.targetFollow = model.transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }
}
