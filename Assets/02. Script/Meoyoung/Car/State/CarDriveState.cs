using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarDriveState : MonoBehaviour, ICarState
{
    CarController cc;

    NavMeshAgent agent;
    float currentSpeed;

    float maxSpeed => cc.carData.GetMaxSpeed();
    float acceleration => cc.carData.GetAcceleration();
    float decelerationDistance => cc.carData.GetDecelerationDistance();
    float stopThreshold => cc.carData.GetStopThreshold();
    float detectionDistance =>cc.carData.GetDetectionDistance();

    public void OnStateEnter(CarController _controller)
    {
        if (cc == null)
            cc = _controller;

        agent = cc.carData.GetNavMeshAgent();
        agent.speed = 0f;
        currentSpeed = 0f;

        agent.SetDestination(cc.navi.GetDestinationInfo().position);
    }

    public void OnStateUpdate()
    {
        //��� ��� �� update�� ����
        if (agent.pathPending)
            return;

        GetInputLight();
        DetectTrafficLight();
        DetectObstacle();

        float remainingDistance = agent.remainingDistance;
        if (remainingDistance < decelerationDistance)
            cc.bDeceleration = true;

        if (cc.bDeceleration)
            Decelerate();
        else
            Accelerate();
        // NavMeshAgent�� ���� �ӵ� ����
        agent.speed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // ���� ����
        if ((remainingDistance <= 5f || cc.bDeceleration) && currentSpeed < stopThreshold)
        {
            agent.speed = 0;
            currentSpeed = 0;
            cc.ChangeState(cc.stopState);
        }
        cc.carSound.PlayEngineSound();
    }

    public void OnStateExit()
    {
        cc.lc.OffBackLight();
    }

    private void GetInputLight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            cc.lc.ControlFrontLight();
    }
    private void DetectTrafficLight()
    {
        if (cc.tld.IsTrafficLightInFront(detectionDistance))
        {
            Debug.Log("Traffic Light");
            cc.bDeceleration = true;
        }
    }

    private void DetectObstacle()
    {
        if (cc.od.IsObstacleInFront(detectionDistance))
        {
            Debug.Log("Obstacle");
            cc.bDeceleration = true;
        }
    }

    // ���� �Լ�
    private void Accelerate()
    {
        cc.lc.OffBackLight();
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    // ���� �Լ�
    private void Decelerate()
    {
        cc.lc.OnBackLight();
        // õõ�� ����
        currentSpeed = Mathf.Max(0, currentSpeed - 2.5f * Time.deltaTime);
    }
}
