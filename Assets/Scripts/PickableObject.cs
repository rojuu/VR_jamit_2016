using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PickableObject : MonoBehaviour
{
    Rigidbody rb;

    bool isNearPlayer = false;
    bool shouldBeKinematic;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shouldBeKinematic = GetComponent<Rigidbody>().isKinematic;
    }

    void Update()
    {
        if (shouldBeKinematic && rb.velocity == Vector3.zero)
        {
            rb.isKinematic = true;
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                col.GetComponent<Player>().PickUpRock(gameObject);
            }
        }
    }
}
