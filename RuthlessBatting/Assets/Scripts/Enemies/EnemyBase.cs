﻿using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Variables")]
    [Range(2, 20)]
    public float distToChase;
    [Range(1, 15)]
    public float distToStop;
    [Range(1, 7)]
    public float speed;
    [Range(0.5f, 4.0f)]
    public float fireRate;
    public LayerMask possibleObstacules;

    protected bool drawGizmos = true;
    protected bool alive = true;

    [HideInInspector] public IPatrol patrol;
    [HideInInspector] public IAttack attackFSM;
    [HideInInspector] public Transform player;
    [HideInInspector] public Transform deathBodyHolder;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public NavMeshAgent nav;
    [HideInInspector] public Health health;
    [HideInInspector] public float actualTime = 0.0f;

    protected const string overBloodLayer = "OverBlood";
    protected const string overBloodUpLayer = "OverBloodUp";
    protected int overBloodSortingOrder = 0;

    [HideInInspector][SerializeField] UnityEvent onAttack;

    virtual protected void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform;
        deathBodyHolder = BodiesHolder.Instance.transform;

        rb = GetComponent<Rigidbody>();

        nav = GetComponent<NavMeshAgent>();
        nav.angularSpeed = 0;
        nav.speed = speed;

        attackFSM = GetComponentInChildren<IAttack>();
        patrol    = GetComponent<IPatrol>();

        health = GetComponent<Health>();
        health.OnDeath().AddListener(OnNoHealth);

        if (player)
        {
            Health playerHealth = player.GetComponentInParent<Health>();
            playerHealth.OnDeath().AddListener(OnPlayerDeath);
        }
    }

    protected void Update()
    {
        OnUpdate();
    }

    protected void FixedUpdate()
    {
        
    }

    public void EnemyInSight()
    {

    }

    public void EnemyInAttackRange()
    {
        
    }

    public void StopMoving()
    {

    }

    abstract protected void OnUpdate();

    virtual protected void OnEnemyInSight()
    {

    }
    virtual protected void OnEnemyOutOfSight()
    {

    }
    virtual protected void OnEnemyInAttackRange()
    {

    }
    virtual protected void OnEnemyOutOfAttackRange()
    {

    }
    virtual protected void OnHit()
    {

    }
    virtual protected void OnNoHealth()
    {

    }
    virtual protected void OnPlayerDeath()
    {

    }

    public bool PlayerOnSight()
    {
        Vector3 diff = GetDistance();
        Vector3 dir = diff.normalized;
        float dist = diff.magnitude;

        if (nav.enabled)
        {
            RaycastHit hit;

            if (dist < distToChase)
                if (!Physics.Raycast(transform.position, dir, out hit, dist, possibleObstacules))
                    return true;
        }

        return false;
    }

    public bool PlayerOnAttackRange()
    {
        Vector3 diff = GetDistance();
        Vector3 dir = diff.normalized;
        float dist = diff.magnitude;

        if (nav.enabled)
        {
            RaycastHit hit;

            if (dist < distToStop)
                if (!Physics.Raycast(transform.position, dir, out hit, dist, possibleObstacules))
                    return true;
        }

        return false;
    }

    public Vector3 GetDistance()
    {
        if (player)
            return player.transform.position - transform.position;
        else
            return new Vector3(0.1f, 0.1f);
    }

    public Vector3 GetDestinationDistance()
    {
        return nav.transform.position - nav.destination;
        //return Utilities.GetDirection(transform, nav.destination - nav.transform.position);
    }

    public UnityEvent OnAttack
    {
        get { return onAttack; }
    }

    // Comment /* ~~~ */ OnDrawGizmos in case of trying to build a new version.
    /*private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            UnityEditor.Handles.color = Color.red;
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, distToStop);

            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, distToChase);
        }
    }*/
}