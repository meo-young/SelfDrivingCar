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
        if (cc.navi.GetDestinationInfo() != null)
            cc.powerOn = true;

        if (cc.powerOn)
            cc.ChangeState(cc.driveState);
    }
    public void OnStateExit()
    {

    }
}
