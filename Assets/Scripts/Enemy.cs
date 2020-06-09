using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class Enemy : CharacterTemplate
{
    [SerializeField] float viewRadius, attackRange;
    [Range(0, 360)]
    [SerializeField] float viewAngle;
    [SerializeField] LayerMask stageMask;
    [SerializeField] GameObject[] points;
    [SerializeField] GameObject chest, ammo;

    private Vector3 dirToTarget, curDestination;
    private float distToTarget;
    private int pointNum = 0;
    private bool found;

    private GameObject target;
    private NavMeshAgent EnemyAI;
    protected delegate void EnemyDelegate();
    protected EnemyDelegate UpdateEnemy;

    public override void Start()
    {
        base.Start();

        UpdateEnemy = Patrol;
        EnemyAI = GetComponent<NavMeshAgent>();
        EnemyAI.speed = speed;
        target = GameObject.FindGameObjectWithTag("Player");
        curDestination = points[0].transform.position;
        DestinationSet();
    }

    void Update()
    {
        FieldOfView();
        UpdateEnemy?.Invoke();
    }

    public void Patrol() //Estado en donde enemigo patrola 
    {
        if (transform.position.x == curDestination.x && transform.position.z == curDestination.z)
        {
            if (pointNum == points.Length - 1)
            {
                pointNum = 0;
            }
            else
            {
                pointNum++;
            }
            curDestination = points[pointNum].transform.position;
            DestinationSet();
        }
    }

    private void AttackMode() //Estado en donde el enemigo ataca
    {
        if (Vector3.Distance(target.transform.position, transform.position) >= attackRange)
        {
            curDestination = target.transform.position;
        }
        else
        {

            curDestination = transform.position;
            transform.LookAt(target.transform);
            Attack();
        }
        DestinationSet();
    }

    private void DestinationSet()
    {
        EnemyAI.SetDestination(new Vector3(curDestination.x, 0, curDestination.z));
    }

    private void FieldOfView() //Detecta si el enemigo esta en su rango de vista
    {
        Collider[] targetsInRadius = Physics.OverlapSphere(transform.position, viewRadius);
        found = false;

        for (int i = 0; i <targetsInRadius.Length; i++)
        {
            if (targetsInRadius[i].tag == "Player")
            {
                dirToTarget = (targetsInRadius[i].transform.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, stageMask))
                    {
                        UpdateEnemy = AttackMode;
                        found = true;
                    }
                }
            }
            else if (i == targetsInRadius.Length - 1 && !found)
            {
                curDestination = points[pointNum].transform.position;
                DestinationSet();
                UpdateEnemy = Patrol;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.white;
        Handles.DrawWireArc(transform.position, Vector3.up, Vector3.forward, 360, viewRadius);

        Vector3 viewAngleA = DirFromAngle(viewAngle / 2, false);
        Vector3 viewAngleB = DirFromAngle(-viewAngle / 2, false);

        Handles.color = Color.red;
        Handles.DrawLine(transform.position, transform.position + viewAngleA * viewRadius);
        Handles.DrawLine(transform.position, transform.position + viewAngleB * viewRadius);
    }

    public void SpawnLoot()
    {
        int num = Random.Range(0, 101);
        Debug.Log("Num1:"+num);
        if (num >= 50)
        {
            num = Random.Range(0, 101);
            Debug.Log("Num2:" + num);
            if (num <= 50)
            {
                GameObject arrow = ammo;
                arrow.AddComponent<ItemPickup>();
                arrow.GetComponent<ItemPickup>().arrow = true;
                Instantiate(arrow, transform.position, transform.rotation);
            }
            else
            {
                chest.GetComponent<LootSpawner>().SpawnItem(transform.position, transform.rotation);
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
