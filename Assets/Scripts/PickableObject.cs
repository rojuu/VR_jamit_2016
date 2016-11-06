using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PickableObject : MonoBehaviour
{
    Rigidbody rb;

    bool isNearPlayer = false;
    bool shouldBeKinematic;
    bool checkVelocityAgain = true;
    public bool canDoDamage = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shouldBeKinematic = GetComponent<Rigidbody>().isKinematic;
    }

    void Update()
    {
        //if (shouldBeKinematic && rb.velocity == Vector3.zero && !rb.isKinematic && checkVelocityAgain)
        //{
        //    checkVelocityAgain = false;

        //    StartCoroutine(checkVelocity());
        //    rb.isKinematic = true;
        //}
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

    void OnCollisionEnter(Collision col)
    {
        canDoDamage = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player2" && canDoDamage)
        {
            col.gameObject.GetComponentInParent<Enemy>().Stun();
        }
    }

    IEnumerator checkVelocity()
    {
        yield return new WaitForSeconds(0.5f);

        if(rb.velocity == Vector3.zero)
        {
            rb.isKinematic = true;
        }

        checkVelocityAgain = true;
    }
}
