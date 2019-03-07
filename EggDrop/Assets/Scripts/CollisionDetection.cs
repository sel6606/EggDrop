using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to detect collision between branches and the player.
/// </summary>
public class CollisionDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Branch1") || collision.gameObject.CompareTag("Branch2"))
        {
            if (!gameObject.GetComponent<Egg>().IsHit)
            {
                //Stop moving branches
                GameInfo.instance.MoveSpeed = 0;

                //Destroy egg
                gameObject.GetComponent<Egg>().Explode();
            }
        }
    }
}
