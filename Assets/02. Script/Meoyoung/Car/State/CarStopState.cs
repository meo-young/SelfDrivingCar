using UnityEngine;

public class CarStopState : MonoBehaviour, ICarState
{
    CarController cc;
    float detectionDistance => cc.carData.GetDetectionDistance();

    public void OnStateEnter(CarController _controller)
    {
        if (cc == null)
            cc = _controller;

        Debug.Log("Stop State");
    }

    public void OnStateUpdate()
    {
        GetInputLight();
        DetectObstacle();
        cc.carSound.PlayEngineSound();
    }


    public void OnStateExit()
    {

    }

    private void GetInputLight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            cc.lc.ControlFrontLight();
    }

    private void DetectObstacle()
    {
        if (cc.od.IsObstacleInFront(detectionDistance))
        {
            return;
        }

        if (cc.tld.IsTrafficLightInFront(detectionDistance))
        {
            return;
        }

        cc.bDeceleration = false;
        cc.ChangeState(cc.driveState);
    }
}
