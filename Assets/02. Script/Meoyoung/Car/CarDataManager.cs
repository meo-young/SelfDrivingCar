using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarDataManager : MonoBehaviour
{ 
    [Header("# Acceleration")]
    public float maxSpeed = 10.0f;
    public float acceleration = 2f;
    public float stopThreshold = 1f;
    public float decelerationDistance = 20f;

    [Header("# Detection Info")]
    public float detectionDistance = 20.0f;

    [Header("# Component")]
    public Rigidbody rb;
    public NavMeshAgent agent;
}
