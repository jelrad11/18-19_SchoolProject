using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_col : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.name);
        if (other.transform.root.tag == "Player")
        {
            transform.parent.GetComponent<e_data>().Target = other.transform.root.gameObject;
            transform.parent.GetComponent<e_data>().follow = true;
        }
    }
}
