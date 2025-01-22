using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class MoveAgent : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform[] monolithsMoveTo;
    [SerializeField]
    private Transform monolithsBase;
    [Range(1, 2)]
    private int randomNumber;
    [NonSerialized]
    public bool key;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            while (Input.GetMouseButtonDown(0))
            {
                MoveTo(Input.mousePosition);
            }
        } else
        {
            StartCoroutine(MoveToBlock(monolithsMoveTo[randomNumber]));
        }
    }
    public void MoveTo(Vector3 destination)
    {
        Ray ray = camera.ScreenPointToRay(destination);
        agent.SetDestination(destination);
    }
    IEnumerator MoveToBlock(Transform target)
    {
        agent.SetDestination(target.position);
        yield return new WaitForSeconds(randomNumber);
    }
}
