using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBall : MonoBehaviour
{
    public int myID;
    p_movement TargetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        TargetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<p_movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.tag == "Ball")
        {
            if(collision.transform.root.GetComponent<Ball>().myid == myID)
            {
                TargetPlayer.Score += 1;
            }
            else
            {
                TargetPlayer.robotRistos.getDamage();
            }

            Destroy(collision.transform.root.gameObject);
        }
    }
}
