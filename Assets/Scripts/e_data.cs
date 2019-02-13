using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class e_data : MonoBehaviour {
    public float HP = 100f;
    public Image img;
    NavMeshAgent MeshAgent;
    public GameObject Target;
    public bool canAttack = false;
    public bool follow = false;
    public float distanceToAttack;
    public float distanceToLose;
    public float AttackSpeed;
    float tmpAttack;
    public float minDamage;
    public float maxDamage;

    // Use this for initialization
    void Start () {
        MeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        img.fillAmount = HP / 100;

        if(follow == true)
        {
            MeshAgent.destination = Target.transform.position;
        }

        if (tmpAttack < 0)
        {
            tmpAttack = 0;
        }
        else if (tmpAttack > 0)
        {
            tmpAttack -= Time.deltaTime;
        }

        if (canAttack == true)
        {
            if (tmpAttack <= 0)
            {
                DoHit();
            }
        }
    }

    private void LateUpdate()
    {
        if(follow == true)
        {
            if (MeshAgent.remainingDistance < distanceToAttack - 2)
            {
                canAttack = true;
                MeshAgent.destination = transform.position;
            }
            if (MeshAgent.remainingDistance < distanceToAttack)
            {
                canAttack = true;
            }
            if (MeshAgent.remainingDistance < distanceToLose && MeshAgent.remainingDistance > distanceToAttack)
            {
                canAttack = false;

            }
            if (MeshAgent.remainingDistance > distanceToLose)
            {
                canAttack = false;
                follow = false;
            }
        }
    }

    void DoHit()
    {
        Target.transform.GetComponent<p_movement>().HP -= Random.Range(minDamage, maxDamage);
        tmpAttack = AttackSpeed;
        if (Target.transform.GetComponent<p_movement>().HP <= 0)
        {
            canAttack = false;
            follow = false;
        }
    }
}
