using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarDriveState : MonoBehaviour, ICarState
{
    CarController cc;

    NavMeshAgent agent;
    float currentSpeed;

    float maxSpeed => cc.carData.maxSpeed;
    float acceleration => cc.carData.acceleration;
    float decelerationDistance => cc.carData.decelerationDistance;
    float stopThreshold => cc.carData.stopThreshold;
    float detectionDistance =>cc.carData.detectionDistance;

    public void OnStateEnter(CarController _controller)
    {
        if (cc == null)
            cc = _controller;

        agent = cc.carData.agent;
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
        if (remainingDistance > decelerationDistance)
            // ���� ���� ȣ��
            Accelerate();
        else
            // ���� ���� ȣ��
            Decelerate(remainingDistance);

        // NavMeshAgent�� ���� �ӵ� ����
        agent.speed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // ���� ����
        if (remainingDistance <= 5f && currentSpeed < stopThreshold)
        {
            agent.speed = 0;
            currentSpeed = 0;
            cc.ChangeState(cc.stopState);
        }
        cc.carSound.EngineSound();
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
            // ���� ������ �Ǵ� �� ���� ���� ȣ��
        }
    }

    private void DetectObstacle()
    {
        if (cc.od.IsObstacleInFront(detectionDistance))
        {
            Debug.Log("Obstacle");
            // ���� ���� ȣ��
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
    private void Decelerate(float remainingDistance)
    {
        cc.lc.OnBackLight();
        float decelerationFactor = remainingDistance / decelerationDistance; // ���� �Ÿ� ����
        currentSpeed = Mathf.Lerp(0, maxSpeed, decelerationFactor);
    }
}
