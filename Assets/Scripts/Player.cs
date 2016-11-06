using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Camera))]
public class Player : MonoBehaviour
{
    public GameObject rockTransform;
    GameObject rock;

    Camera cam;
    Rigidbody rb;
    CharacterController characterController;
    bool gameEnded = false;
    bool canShoot;

    Light lightScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        lightScript = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVars.Instance.ChildCount >= GlobalVars.Instance.ChildMax && !gameEnded)
        {
            gameEnded = true;
            print("Player won");
        }

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            canShoot = false;
            rock.transform.SetParent(null);
            Rigidbody rb = rock.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(cam.transform.forward * 1000);
            rock = null;
        }

        if (!Input.GetButton("Fire1") && rock != null)
        {
            canShoot = true;
        }

        if(Input.GetButtonDown("Jump") && lightScript != null)
        {
            lightScript.ToggleLight();
        }
    }

    public void PickUpRock(GameObject _rock)
    {
        if (rock != null)
        {
            return;
        }

        rock = _rock;

        rock.GetComponent<Rigidbody>().isKinematic = true;
        rock.transform.SetParent(rockTransform.transform);
        rock.transform.localPosition = Vector3.zero;
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

            try
            {
                FindObjectOfType<Enemy>().SpawnInRandomLocation();
            }
            catch { }

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
        while (currentLerpTime < lerpTime)
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
