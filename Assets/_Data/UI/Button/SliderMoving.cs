using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderMoving : ObjPlayerMove, IPointerDownHandler, IPointerUpHandler
{
    [Header("SliderMove")]
    [SerializeField] protected GameObject sliderMove;
    public GameObject SliderMove => sliderMove;

    [SerializeField] protected Slider slider;
    public Slider Slider => slider;

    [SerializeField] protected Sprite[] imgHandle;

    protected RectTransform handle;
    protected Image img;
    [SerializeField] protected bool isDragging = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSliderMove();
        this.LoadSlider();
        this.LoadImgHandle();
    }

    protected void FixedUpdate()
    {
        this.ChangeState();

        // Nếu không kéo thì thiết lập giá trị Slider về 0.5
        if (!isDragging)
        {
            slider.value = 0f;
        }

        HandleMovement();
    }

    protected void LoadSliderMove()
    {
        if (this.sliderMove != null) return;
        this.sliderMove = GameObject.Find("SliderMove");
        Debug.Log(transform.name + ": LoadSliderMove", gameObject);
    }

    protected void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = this.GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    protected void LoadImgHandle()
    {
        this.imgHandle = Resources.LoadAll<Sprite>("ButtonMovement");
        handle = slider.handleRect;
        img = handle.GetComponent<Image>();
        //Debug.Log(transform.name + ": LoadImgHandle", gameObject);
    }

    protected void ChangeState()
    {
        if (slider.value < 0f && slider.value >= -0.5f)
            img.sprite = imgHandle[3];
        else if (slider.value < -0.5f && slider.value >= slider.minValue)
            img.sprite = imgHandle[1];
        else if (slider.value > 0f && slider.value <= 0.5f)
            img.sprite = imgHandle[4];
        else if (slider.value > 0.5f && slider.value <= slider.maxValue)
            img.sprite = imgHandle[2];
        else
            img.sprite = imgHandle[0];
    }

    protected void HandleMovement()
    {
        float sliderValue = slider.value; // Giá trị từ -0.5 đến 0.5
        OnMove(sliderValue);

        // Xử lý chạy nếu giá trị slider ở mức cao
        OnRun(slider, sliderValue);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        slider.value = 0.5f; // Đặt lại thanh trượt về trung tâm khi không kéo
    }
}
