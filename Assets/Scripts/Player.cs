using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody rb;
    bool gameEnded = false;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }
    
    // Update is called once per frame
	void Update ()
    {
	    if(GlobalVars.Instance.ChildCount >= GlobalVars.Instance.ChildMax && !gameEnded)
        {
            gameEnded = true;
            print("Player won");
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player2")
        {
            if (--GlobalVars.Instance.PlayerHP <= 0 && !gameEnded)
            {
                gameEnded = true;
            }

            Vector3 knockBackDir = transform.position - col.transform.position;
            knockBackDir.y = 0;
            knockBackDir.Normalize();

            rb.AddForce(knockBackDir * 10000, ForceMode.Impulse);

            StartCoroutine(Invicibility());
        }
    }

    IEnumerator Invicibility()
    {
        SetInvicibility(true);
        yield return new WaitForSeconds(3);
        SetInvicibility(false);
    }

    void SetInvicibility(bool setInvicible)
    {
        Physics.IgnoreLayerCollision(8, 9, setInvicible);
    }
}
