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

    public void OnStateEnter(CarController _controller)
    {
        if (cc == null)
            cc = _controller;

        agent = cc.carData.agent;
        agent.speed = 0f;
        currentSpeed = 0f;

        agent.SetDestination(cc.targetPos.position);
    }

    public void OnStateUpdate()
    {
        float remainingDistance = agent.remainingDistance;
        if (remainingDistance > decelerationDistance)
        {
            // 가속 로직 호출
            Accelerate();
        }
        else
        {
            // 감속 로직 호출
            Decelerate(remainingDistance);
        }

        // NavMeshAgent에 현재 속도 적용
        agent.speed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // 정지 조건
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

    }

    // 가속 함수
    private void Accelerate()
    {
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    // 감속 함수
    private void Decelerate(float remainingDistance)
    {
        float decelerationFactor = remainingDistance / decelerationDistance; // 남은 거리 비율
        currentSpeed = Mathf.Lerp(0, maxSpeed, decelerationFactor);
    }
}
