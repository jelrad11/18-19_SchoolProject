using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRistos : MonoBehaviour
{
    public Transform handPoint;
    public Transform targetPoint;
    public Vector3 targetPosToFly;
    Animator anim;
    public bool forwardingPlayer;
    GameObject PlayerPrefab;
    public float MoveSpeed;

    public Transform[] listofRobotParts;
    int tmp = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        PlayerPrefab = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    public void getDamage()
    {
        //targetPoint = listofRobotParts[tmp];
        //tmp++;
        //listofRobotParts[0].root.GetComponent<p_movement>().Move = false;

        //if (tmp > listofRobotParts.Length)
        //{
        //    Debug.Log("GameOver");
        //}
    }

    public void Grab()
    {
        targetPoint.SetParent(handPoint);
    }

    public void Drop()
    {
        targetPoint.SetParent(null);
        targetPoint.GetComponent<Rigidbody>().useGravity = true;
        listofRobotParts[0].root.GetComponent<p_movement>().Move = true;
    }

    private void Update()
    {
        if (forwardingPlayer)
        {
            
            if (Vector3.Distance(transform.position, PlayerPrefab.transform.Find("RobotPos").transform.position) < 0.1)
            {
                if(transform.rotation.y != PlayerPrefab.transform.Find("RobotPos").transform.rotation.y)
                {
                    //transform.Rotate(PlayerPrefab.transform.forward * Time.deltaTime * 5);
                    transform.rotation = PlayerPrefab.transform.Find("RobotPos").transform.rotation;
                    
                }
                StartCoroutine(SayHello());
            }
            else
            {
                transform.LookAt(PlayerPrefab.transform.Find("RobotPos"));
                transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
            }
        }
    }

    private IEnumerator SayHello()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().Pause();
    }
}
