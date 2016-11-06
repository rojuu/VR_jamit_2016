using UnityEngine;
using System.Collections;

public class Light : MonoBehaviour {

    public GameObject lightObject;
    
    public void ToggleLight()
    {
        lightObject.SetActive(!lightObject.activeSelf);
    }
}
