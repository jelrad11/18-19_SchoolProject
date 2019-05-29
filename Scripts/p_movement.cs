using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class p_movement : MonoBehaviour {
    public int Score;
    public float HP = 100f;
    RaycastHit hit;
    public float distance;
    public Camera cam;
    Vector3 moveToPoint;
    public bool Move;
    public LayerMask TerrainMask;
    public LayerMask EnemyMask;
    public float MovementSpeed;
    NavMeshAgent MeshAgent;
    public Vector3 CamPos;
    public GameObject SelectedEnemy;
    public bool Attack = false;
    public float AttackDistance;
    public float minDistanceToUse;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    public RobotRistos robotRistos;

    // Use this for initialization
    void Start () {
        MeshAgent = GetComponent<NavMeshAgent>();
        m_EventSystem = GetComponent<EventSystem>();
        m_Raycaster = GetComponent<RoadRotate>().UIPrefab.transform.parent.GetComponent<GraphicRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> Results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, Results);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                //Debug.DrawRay(cam.transform.position, cam.transform.forward * distance);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, TerrainMask))
                {
                    Debug.Log(hit.collider.transform.root.name);
                    if (Results.Count == 0)
                    {
                        if (hit.collider.transform.root.name == "Terrain")
                        {
                            MeshAgent.destination = hit.point;
                            Attack = false;
                            GetComponent<p_attack>().canAttack = false;
                        }
                    }
                }

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, EnemyMask))
                {
                    if (hit.collider.transform.root.tag == "Enemy")
                    {
                        Attack = true;
                        SelectedEnemy = hit.collider.transform.root.gameObject;
                        GetComponent<p_attack>().SelectedEnemy = SelectedEnemy;
                        MeshAgent.destination = new Vector3(SelectedEnemy.transform.position.x + 3, SelectedEnemy.transform.position.y, SelectedEnemy.transform.position.z + 3);
                    }
                }

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.root.GetComponent<TargetRoad>())
                    {
                        
                        transform.GetComponent<RoadRotate>().TargetBody = hit.transform.root.GetComponent<TargetRoad>().TargetBody;
                    }
                }
        }
        

        if (transform.GetComponent<RoadRotate>().TargetBody != null)
        {
            if(Vector3.Distance(transform.position, transform.GetComponent<RoadRotate>().TargetBody.transform.position) <= minDistanceToUse)
            {
                transform.GetComponent<RoadRotate>().TurnOn();
            }
            else
            {
                transform.GetComponent<RoadRotate>().TurnOff();
                transform.GetComponent<RoadRotate>().TargetBody = null;
            }
        }

        if (Attack == true)
        {
            

            if (MeshAgent.remainingDistance < AttackDistance)
            {
                GetComponent<p_attack>().canAttack = true;
                //MeshAgent.Stop();
                Attack = false;
            }
            else
            {
                GetComponent<p_attack>().canAttack = false;
                MeshAgent.destination = SelectedEnemy.transform.position;
            }
        }

        
        cam.transform.LookAt(transform);
        cam.transform.position = transform.position + CamPos;
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cam.orthographicSize = cam.orthographicSize + (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 400);
        }
    }

}
