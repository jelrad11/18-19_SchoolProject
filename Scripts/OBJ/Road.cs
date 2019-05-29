using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {
    public float speed = 1.0f;

    private void OnTriggerStay(Collider other)
    {
        other.transform.position += transform.forward * speed * Time.deltaTime;
    }
}
