using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ObjPlayerMove : ObjMovement
{
    [Header("ObjPlayerMove")]
    [SerializeField] protected bool _isMoving = false;

    [SerializeField] protected bool _isRunning = false;

    [SerializeField] protected bool _IsFacingRight = true;

    protected bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
            animator.SetBool(AnimString.isMoving, _isMoving); // Cập nhật trạng thái di chuyển trong animator
            if (!_isMoving) // Nếu không đi bộ, cũng không thể chạy
            {
                IsRunning = false;
            }
        }
    }

    protected bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            animator.SetBool(AnimString.isRunning, _isRunning); // Cập nhật trạng thái chạy trong animator
            if (_isRunning)
            {
                IsMoving = true; // Để chạy thì cũng phải đang đi
            }
        }
    }

    public bool IsFacingRight
    {
        get
        {
            return _IsFacingRight;
        }
        set
        {
            if (_IsFacingRight != value)
                model.localScale *= new Vector2(-1, 1); // Đảo chiều của nhân vật
            _IsFacingRight = value;
        }
    }

    public void OnIdle()
    {
        IsMoving = false; // Đặt trạng thái đi bộ thành false
        IsRunning = false; // Đặt trạng thái chạy thành false
    }

    public void OnMove(float sliderValue)
    {
        if (sliderValue != 0)
        {
            IsMoving = true;
            rb.velocity = new Vector2(sliderValue * 100 * walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
            SetFacingDirection(new Vector2(sliderValue, 0));
        }
        else
        {
            OnIdle();
        }
    }

    public void OnRun(Slider slider, float sliderValue)
    {
        if (slider.value > 0.5f || slider.value < -0.5f)
        {
            IsRunning = true;
            rb.velocity = new Vector2(sliderValue * 100 * runSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            IsRunning = false;
        }
    }

    protected void SetFacingDirection(Vector2 targetPosition)
    {
        if (targetPosition.x > 0 && !IsFacingRight)
        {
            // Quay sang phải
            IsFacingRight = true;
        }
        else if (targetPosition.x < 0 && IsFacingRight)
        {
            // Quay sang trái
            IsFacingRight = false;
        }
    }
}
