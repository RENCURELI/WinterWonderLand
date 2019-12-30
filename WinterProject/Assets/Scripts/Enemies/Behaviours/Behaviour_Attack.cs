﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Behaviour_Attack : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The AI agent
    /// </summary>
    NavMeshAgent g_agent;

    /// <summary>
    /// The agent's target i.e. the player
    /// </summary>
    Transform g_target;

    [System.NonSerialized]
    public bool g_completed = false;

    [SerializeField]
    private float g_attRange = 2.5f; //The range of the zombie melee attack

    public Transform g_attPoint;

    public LayerMask g_playerLayer;
    #endregion

    #region Base Methods
    // Start is called before the first frame update
    void OnEnable()
    {
        g_target = FindObjectOfType<Player>().transform;
        g_completed = false;
        g_agent = gameObject.GetComponentInParent<NavMeshAgent>();
        g_agent.SetDestination(g_target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(g_agent.destination, g_agent.transform.position) < g_attRange)
        {
            g_agent.isStopped = true; //Stops the agent
            Attack();
        }
    }

    #endregion

    #region Custom Methods

    private void Attack()
    {
        //Contain all collisions with player
        Collider[] m_playerCol = Physics.OverlapSphere(g_attPoint.position, g_attRange, g_playerLayer);

        foreach (Collider m_player in m_playerCol)
        {
            Debug.Log("Player was hit");
        }
    }

    #endregion
}
