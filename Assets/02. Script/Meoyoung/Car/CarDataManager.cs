using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarDataManager : MonoBehaviour
{ 
    public enum Axel
    {
        Front,
        Rear
    }

    [System.Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    [Header("# Acceleration")]
    public float maxSpeed = 10.0f;
    public float acceleration = 2f;
    public float stopThreshold = 1f;
    public float decelerationDistance = 20f;
    public float brakeAcceleration = 50.0f;

    [Header("# Sensitivity")]
    public float turnSensitivity = 1.0f;

    [Header("# Steer")]
    public float maxSteerAngle = 30.0f;

    [Header("# Wheel Info")]
    public List<Wheel> wheels;

    [Header("# Component")]
    public Rigidbody rb;
    public NavMeshAgent agent;
}
