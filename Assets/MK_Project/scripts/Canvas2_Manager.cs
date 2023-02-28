using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Canvas2_Manager : MonoBehaviour
{

    public Button myExitButton; // reference to exit button
    public Button nextModelButton;
    public Button prevModelButton;
    public Button changeToTouchMode;
    public Button changeToARMode;
    public Button changeToVRMode;
    public TMP_Text label; // reference to the label

    public Scene2_Manager myScenemanager;

    private void Start()
    {
        myExitButton.onClick.AddListener(myScenemanager.CloseTheSimulation);
       
        nextModelButton.onClick.AddListener(myScenemanager.ShowNextModel);
        nextModelButton.onClick.AddListener(myScenemanager.DisplayObjectName);
       
        prevModelButton.onClick.AddListener(myScenemanager.ShowPrevModel);
        prevModelButton.onClick.AddListener(myScenemanager.DisplayObjectName);

        changeToARMode.onClick.AddListener(myScenemanager.ChangeModeToAR);
        changeToVRMode.onClick.AddListener(myScenemanager.ChangeModeToVR);


        label.text = myScenemanager.GetObjectName(myScenemanager.currentModelID);
    }
}
