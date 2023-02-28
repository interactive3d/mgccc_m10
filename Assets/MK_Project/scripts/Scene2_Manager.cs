using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2_Manager : MonoBehaviour
{
    
    public List<GameObject> myObjects = new List<GameObject>(); // this list store the objects (models)
    public List<string> myObjectNames = new List<string>();
    public Dictionary<string, GameObject> myGaleryObjects = new Dictionary<string, GameObject>();

    public Camera myCamera; // reference to the camera
    public int currentModelID = 0; // this will be the id of the model that will be displayed

    public Canvas2_Manager myCanvas;
    
    [SerializeField]
    private bool navOnMobile; // this will be the mode {false for desktop, true for mobile}
    private orbitOnDesktop desktopOrbitComponent;
    private orbitOnMobile mobileOrbitCompoent;

    private void Start()
    {
        FillDictionary();
        ShowModelID(currentModelID);
        if (myCamera == null)
        {
            myCamera = Camera.main;
        }
        desktopOrbitComponent = myCamera.GetComponent<orbitOnDesktop>();
        mobileOrbitCompoent = myCamera.GetComponent<orbitOnMobile>();
        
        if (navOnMobile)
        {
            desktopOrbitComponent.enabled = false;
            mobileOrbitCompoent.enabled = true;
        }
        else
        {
            desktopOrbitComponent.enabled = true;
            mobileOrbitCompoent.enabled = false;
        }
    }

    private void Update()
    {
        // testing the change of the model ID
        if (Input.GetKeyDown(KeyCode.N)) {
            ShowNextModel();
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            ShowPrevModel();
        }



    }


    #region Helper Functions
    public void ShowNextModel()
    {
        if (currentModelID < myObjects.Count - 1)
        {
            currentModelID = currentModelID + 1;
        }
        else
        {
            currentModelID = 0;
        }
        ShowModelID(currentModelID);
    }

    public void ShowPrevModel()
    {
        if (currentModelID == 0)
        {
            currentModelID = myObjects.Count - 1;
        }
        else
        {
            currentModelID = currentModelID - 1;
        }
        ShowModelID(currentModelID);
    }

    public void HideAllModels()
    {
        for (int a = 0; a < myObjects.Count; a++)
        {
            myObjects[a].SetActive(false);
        }
    }
    public void ShowModelID(int modelID)
    {
        for (int a = 0; a < myObjects.Count; a++)
        {
            if (a == modelID)
            {
                myObjects[a].SetActive(true);
                GetObjectName(a);
                // change the camera focus to the object
                SetTheFocusTransformOnOrbit(a);
            }
            else
            {
                myObjects[a].SetActive(false);
            }
        }
    }

    public string GetObjectName(int modelID)
    {
        string theNameOfTheObject = "";
        if (myObjectNames.Count != 0 && modelID >= 0 && modelID < myObjectNames.Count)
        {
            theNameOfTheObject = myObjectNames[modelID];
        }
        else
        {
            Debug.Log("This will return error");
        }
        return theNameOfTheObject;
    }

    public void DisplayObjectName()
    {
        myCanvas.label.text = GetObjectName(currentModelID);
    }

    public void SetVolumeTo(float myVolume)
    {

    }

    public void CloseTheSimulation()
    {
        
        
        
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Application.Quit();
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.Quit();
        }
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

    }

    public void SetTheFocusTransformOnOrbit(int objectID)
    {
        // this function will dynamically change the focus target to currently displayed object 
        // so that when orbiting the current object is always in focus
        if (!navOnMobile)
        {
            // desktopOrbitComponent.target = myObjects[objectID].transform;
        }
        else
        {
            // mobileOrbitCompoent.target = myObjects[objectID].transform;
        }
        
    }
    public void ChangeModeToAR()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void ChangeModeToVR()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void ChangeModeToTouch()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    private void FillDictionary()
    { 
        if (myObjects.Count == myObjectNames.Count)
        {
            for (int i = 0; i < myObjects.Count; i++)
            {
                myGaleryObjects.Add(myObjectNames[i], myObjects[i]);
            }
        }
        else
        {
            Debug.Log("cant do it");
        }
        
    }
    #endregion
}
