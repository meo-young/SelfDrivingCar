using UnityEngine;

public class CarStopState : MonoBehaviour, ICarState
{
    CarController cc;

    public void OnStateEnter(CarController _controller)
    {
        if (cc == null)
            cc = _controller;

        Debug.Log("Stop State");
    }

    public void OnStateUpdate()
    {
        cc.carSound.EngineSound();
    }


    public void OnStateExit()
    {

    }
}
