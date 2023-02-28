using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeGestureManager : MonoBehaviour
{
    public float minSwipeLength = 200f;
    Vector2 startPos;
    Vector2 endPos;

    bool couldBeSwipe;
    float lastTimeSwipe;
    float minSwipeTime = 0.2f;

    public delegate void SwipeAction(SwipeDirection direction);
    public static event SwipeAction OnSwipe;

    private void Update()
    {
      /*  if (Input.GetMouseButtonDown(0))
        {
            couldBeSwipe = true;
            startPos = Input.mousePosition;
            lastTimeSwipe = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            float swipeTime = Time.time - lastTimeSwipe;
            float swipeLength = (Input.mousePosition - startPos).magnitude;

            if(couldBeSwipe && swipeTime < min)
            {

            }
            
        }*/

    }

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }

}
