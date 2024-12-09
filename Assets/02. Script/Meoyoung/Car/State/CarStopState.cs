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
        GetInputLight();
        cc.carSound.EngineSound();
    }


    public void OnStateExit()
    {

    }

    private void GetInputLight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            cc.lc.ControlFrontLight();
    }
}
