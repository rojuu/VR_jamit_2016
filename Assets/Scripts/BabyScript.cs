using UnityEngine;
using System.Collections;

public class BabyScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject beacon;
	public AudioClip saved;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Mathf.PingPong(Time.time, 1) - 0.5f, 0));
        if(rb.isKinematic && beacon.activeSelf)
        {
            beacon.SetActive(false);
        }
        else if(!rb.isKinematic && !beacon.activeSelf && rb.velocity == Vector3.zero)
        {
            beacon.SetActive(true);
        }
    }


    void OnTriggerEnter(Collider col)
    {
        //if (col.tag == "Player")
        //{
        //    print("keräsit lapsen penikan");
        //    GlobalVars.Instance.ChildCount++;
        //    Destroy(gameObject);
        //}

        if (col.tag == "Home")
        {
            GlobalVars.Instance.ChildCount++;
			GetComponent<AudioSource>().PlayOneShot(saved, 1.0F);
			GetComponent<Renderer>().enabled = false;
			Destroy(gameObject, saved.length);
        }
    }
}
