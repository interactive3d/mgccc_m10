using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Material highlighedMaterial; // this store reference to material that will be change to when selected

    private Material oryginalMaterial; // this will store the information about the object original materials

    private bool statusOfChange = false; // to store the trigger to change back and FOTH ?


    private void OnMouseDown()
    {
        if (statusOfChange)
        {
            ChangeThisMaterial(gameObject);
        }
        else
        {
            RevertBackTheMaterial(gameObject);
        }
        statusOfChange = !statusOfChange;

    }


    public void ChangeThisMaterial(GameObject myObject)
    {
        // first collect information that the object has the MeshRenderer
        // then store the original metarial before you will change it (so we can revert back when needed)
        // then apply the new material to the MeshRenderer of the object


        if (myObject.GetComponent<MeshRenderer>() == null)
        {
            // this object does not have component renderer show the error message now
            Debug.Log("this object can't be changed");
        }
        else
        {
            MeshRenderer myObjectRenderer = myObject.GetComponent<MeshRenderer>();
            oryginalMaterial = myObjectRenderer.material;  // this take the original material from the object
            myObject.GetComponent<MeshRenderer>().material = highlighedMaterial; // this assign new material to the object
        }
    }

    public void RevertBackTheMaterial(GameObject myObject)
    {
        myObject.GetComponent<MeshRenderer>().material = oryginalMaterial;
    }

}
