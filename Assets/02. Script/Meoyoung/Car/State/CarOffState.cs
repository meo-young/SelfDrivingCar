using UnityEngine;

public class CarOffState : MonoBehaviour, ICarState
{
    CarController cc;

    public void OnStateEnter(CarController _controller)
    {
        if(cc == null)
            cc = _controller;

        cc.carSound.StopSound();
    }

    public void OnStateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            cc.powerOn = true;

        if (cc.powerOn)
            cc.ChangeState(cc.driveState);
    }
    public void OnStateExit()
    {

    }
}
