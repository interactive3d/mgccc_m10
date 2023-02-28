using UnityEngine;
using UnityEngine.Events;
public class FingerSwipeDetection : MonoBehaviour
{
    public int trackedFingerID;
    public int threshold = 200;
    public float duration = 0.25f;
    private Vector2 initialPosition;
    private float initialTime;
    
    public UnityEvent swipeLeft;
    public UnityEvent swipeRight;
    public UnityEvent swipeUp;
    public UnityEvent swipeDown;
    
    
    public void Update()
    {
        Touch touch;
        for (int i = Input.touchCount - 1; i >= 0; i--)
        {
            touch = Input.GetTouch(i);
            if (touch.fingerId == trackedFingerID)
            {
                ProcessTouchPhase(touch);
            }
        }
    }
    public void ProcessTouchPhase(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
            case TouchPhase.Stationary:
                initialPosition = touch.position;
                initialTime = Time.time;
                break;
            case TouchPhase.Ended:
                if ((Time.time - initialTime) < duration)
                    ValidateSwipe(touch);
                break;
        }
    }
    public void ValidateSwipe(Touch touch)
    {
        Vector2 delta = touch.position - initialPosition;
        if (Mathf.Abs(delta.x) > threshold)
        {
            if (delta.x > 0)
            {
                swipeRight?.Invoke();
            }
            else
            {
                swipeLeft?.Invoke();
            }
        }
        if (Mathf.Abs(delta.y) > threshold)
        {
            if (delta.y > 0)
            {
                swipeUp?.Invoke();
            }
            else
            {
                swipeDown?.Invoke();
            }
        }
    }
}