using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            print("keräsit lapsen penikan");
            Destroy(gameObject);
        }
    }
}
