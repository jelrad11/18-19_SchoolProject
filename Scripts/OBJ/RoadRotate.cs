using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRotate : MonoBehaviour {
    public GameObject TargetBody;
    public bool CanRot;
    Vector3 left = new Vector3(0,90,0);
    Vector3 down = new Vector3(0, 180, 0);
    Vector3 right = new Vector3(0, 270,0);
    Vector3 up = new Vector3(0, 0, 0);
    Vector3 targetRot = new Vector3(0, 0, 0);
    float maxTime = 0.01f;
    float tmpTime = 0;
    public bool Show = false;
    public GameObject UIPrefab;


    // Use this for initialization
    void Start () {
	}

    public void TurnOn()
    {
        if (Show == false)
        {
            Show = true;
            UIPrefab.SetActive(true);
        }
    }

    public void TurnOff()
    {
        if (Show == true)
        {
            Show = false;
            UIPrefab.SetActive(false);
            TargetBody = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(CanRot == true)
        {
            tmpTime += Time.deltaTime;
            if (tmpTime >= maxTime)
            {
                TargetBody.transform.RotateAround(TargetBody.transform.position,Vector3.up,10f);
                tmpTime = 0f;
            }
        }
	}

    private void LateUpdate()
    {
        if(CanRot == true)
        {
            if (TargetBody.transform.rotation.eulerAngles.y == targetRot.y)
            {
                CanRot = false;
                tmpTime = 0;
            }
        }
    }

    public void RotateLeft()
    {
        TargetBody.transform.rotation = Quaternion.Euler(0, 270, 0);
    }

    public void RotateRight()
    {
        TargetBody.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    public void RotateUp()
    {
        TargetBody.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void RotateDown()
    {
        TargetBody.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public void EndOfRot()
    {
        CanRot = false;
    }
}
