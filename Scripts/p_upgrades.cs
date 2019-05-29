using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_upgrades : MonoBehaviour
{
    public Transform Head;
    public Transform Body;
    public Transform ArmLeft;
    public Transform ArmRight;
    public Transform LegLeft;
    public Transform LegRight;

    public List<Transform> Points = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpgrade(GameObject Prefab,Type type)
    {
        if(type == Type.ArmLeft)
        {
            Instantiate(Prefab, ArmLeft);
        }

        if (type == Type.ArmRight)
        {
            Instantiate(Prefab, ArmRight);
        }

        if (type == Type.Head)
        {
            Instantiate(Prefab, Head);
        }

        if (type == Type.LegLeft)
        {
            Instantiate(Prefab, LegLeft);
        }

        if (type == Type.LegRight)
        {
            Instantiate(Prefab, LegRight);
        }

        if (type == Type.Body)
        {
            Instantiate(Prefab, Body);
        }
    }

    public enum Type
    {
    Head,
    Body,
    ArmLeft,
    ArmRight,
    LegLeft,
    LegRight
    }
}
