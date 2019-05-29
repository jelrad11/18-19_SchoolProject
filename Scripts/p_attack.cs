using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_attack : MonoBehaviour {
    public float AttackSpeed;
    float tmpAttack;
    public GameObject SelectedEnemy;
    public bool canAttack;
    public float minDamage;
    public float maxDamage;

	// Use this for initialization
	void Start () {
        tmpAttack = AttackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(canAttack == true)
        {
            if(tmpAttack <= 0)
            {
                DoHit();
            }
        }

        if(tmpAttack < 0)
        {
            tmpAttack = 0;
        }
        else if(tmpAttack > 0)
        {
            tmpAttack -= Time.deltaTime;
        }
	}

    void DoHit()
    {
        SelectedEnemy.transform.GetComponent<e_data>().HP -= Random.Range(minDamage, maxDamage);
        tmpAttack = AttackSpeed;
        if(SelectedEnemy.transform.GetComponent<e_data>().HP <= 0)
        {
            GetComponent<p_movement>().Attack = false;
            canAttack = false;

        }
    }
}
