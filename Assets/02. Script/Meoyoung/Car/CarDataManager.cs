using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarDataManager : MonoBehaviour
{
    [Header("# Acceleration")]
    [SerializeField] float maxSpeed = 10.0f;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float stopThreshold = 1f;
    [SerializeField] float decelerationDistance = 20f;

    [Header("# Detection Info")]
    [SerializeField] float detectionDistance = 20.0f;

    [Header("# Component")]
    [SerializeField] Rigidbody rb;
    [SerializeField] NavMeshAgent agent;


    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public float GetAcceleration()
    {
        return acceleration;
    }

    public float GetDetectionDistance()
    {
        return detectionDistance;
    }

    public float GetStopThreshold()
    { 
        return stopThreshold; 
    }

    public float GetDecelerationDistance()
    {
        return decelerationDistance;
    }

    public Rigidbody GetRigidBody()
    {
        return rb;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }
}
