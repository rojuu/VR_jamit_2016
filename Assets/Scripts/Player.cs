using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    Rigidbody rb;
    CharacterController characterController;
    bool gameEnded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVars.Instance.ChildCount >= GlobalVars.Instance.ChildMax && !gameEnded)
        {
            gameEnded = true;
            print("Player won");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player2")
        {
            if (--GlobalVars.Instance.PlayerHP <= 0 && !gameEnded)
            {
                gameEnded = true;
            }

            Vector3 knockBackDir = transform.position - col.transform.position;
            knockBackDir.y = 0;
            knockBackDir.Normalize();

            //rb.AddForce(knockBackDir * 100, ForceMode.Impulse);
            StartCoroutine(KnockBack(knockBackDir));

            StartCoroutine(Invicibility());
        }
    }

    IEnumerator Invicibility()
    {
        SetInvicibility(true);
        yield return new WaitForSeconds(2f);
        SetInvicibility(false);
    }

    IEnumerator KnockBack(Vector3 knockBackDir)
    {
        float lerpTime = 0.2f;
        float currentLerpTime = 0;

        float startForce = 0;
        float endForce = 30;
        while(currentLerpTime < lerpTime)
        {
            float t = currentLerpTime / lerpTime;
            t = Mathf.Cos(t * Mathf.PI * 0.5f);
            characterController.Move(knockBackDir * Mathf.Lerp(startForce, endForce, t) * Time.deltaTime);

            currentLerpTime += Time.deltaTime;
            yield return null; 
        }
    }

    void SetInvicibility(bool setInvicible)
    {
        Physics.IgnoreLayerCollision(8, 9, setInvicible);
    }
}
