using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
       // transform.Rotate(new Vector3(Mathf.PingPong(Time.time, 3) - 1.5f, 0, 0));

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            print("keräsit lapsen penikan");
            GlobalVars.Instance.ChildCount++;
            Destroy(gameObject);
        }
    }
}
