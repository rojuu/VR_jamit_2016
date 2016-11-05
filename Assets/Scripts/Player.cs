using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    bool playerWon = false;
    bool monsterWon = false;
    
    // Update is called once per frame
	void Update ()
    {
	    if(GlobalVars.Instance.ChildCount >= GlobalVars.Instance.ChildMax && !monsterWon)
        {
            playerWon = true;
            print("Player won");
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player2")
        {
            if (--GlobalVars.Instance.PlayerHP <= 0 && !playerWon)
            {
                monsterWon = true;
                print("Monster won the game");
            }

            StartCoroutine(Invicibility());
        }
    }

    IEnumerator Invicibility()
    {
        SetInvicibility(true);
        yield return new WaitForSeconds(3);
        SetInvicibility(false);
    }

    void SetInvicibility(bool isInvicible)
    {

    }
}
