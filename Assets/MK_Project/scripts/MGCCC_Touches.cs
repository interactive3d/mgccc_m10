using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // to use UI elements
using UnityEngine.Events; // adding this namespace for the support of the events

public class MGCCC_Touches : MonoBehaviour
{
    // public TMP_Text myLabel; // reference to the label
    // public Image[] imgFinger; // reference to the image for finger 0
    // public TMP_Text[] fingerLabel; // array of the text fields on each finger position

    public int thisFingerID;

    public UnityEvent onBegan; // this is a declaration of an event (Unity event)
    public UnityEvent onStationary; // this is a declaration of an event (Unity event)
    public UnityEvent onMoved; // this is a declaration of an event (Unity event)
    public UnityEvent onEnded; // this is a declaration of an event (Unity event)
    public UnityEvent onCanceled; // this is a declaration of an event (Unity event)



    private void Update()
    {
        #region Task1
        /*
        
        if (Input.touchCount > 0)
        {
            Debug.Log("There are " + Input.touchCount + " touches");
            myLabel.text = Input.touchCount.ToString();

            for (int i=0; i< Input.touchCount; i++)
            {
                imgFinger[i].transform.position = Input.GetTouch(i).position; // this to represent the position
                fingerLabel[i].text = i.ToString(); // this to display the text on the image
            }
        }
        */
        #endregion

        int touchCount = Input.touchCount; // this store info on how many touches there are in the scene

        for (int i=0; i<touchCount; i++)
        {
            if (Input.GetTouch(i).fingerId == thisFingerID)
            {
                transform.position = Input.GetTouch(i).position;
                // I would like to check what Phase is actually of the Touch
                ProcessPhase(Input.GetTouch(i).phase);
            }
        }
    }

    public void ProcessPhase(TouchPhase ourPhase)
    {
        switch (ourPhase)
        {
            case TouchPhase.Began:
                // invoke the event
                onBegan.Invoke();
                break;
            case TouchPhase.Stationary:
                // invoke the event
                onStationary.Invoke();
                break;
            case TouchPhase.Moved:
                // invoke the event
                onMoved.Invoke();
                break;
            case TouchPhase.Ended:
                // invoke the event
                onEnded.Invoke();
                break;
            case TouchPhase.Canceled:
                // invoke the event
                onCanceled.Invoke();
                break;
        }
    }

}
