using UnityEngine;

public class CarController : MonoBehaviour
{
    public static CarController instance;

    public ICarState offState, driveState, stopState;

    [HideInInspector] public CarDataManager carData;
    [HideInInspector] public CarSound carSound;

    [HideInInspector] public float moveInput;
    [HideInInspector] public float steerInput;
    [HideInInspector] public bool powerOn;

    public Transform targetPos;
    public ICarState CurrentState
    {
        get; private set;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        offState = gameObject.AddComponent<CarOffState>();
        driveState = gameObject.AddComponent<CarDriveState>();
        stopState = gameObject.AddComponent<CarStopState>();

        carData = GetComponent<CarDataManager>();
        carSound = GetComponent<CarSound>();
    }

    private void Start()
    {
        CurrentState = offState;
        ChangeState(CurrentState);
    }

    private void Update()
    {
        UpdateState();
    }


    void UpdateState()
    {
        if (CurrentState != null)
            CurrentState.OnStateUpdate();
    }


    public void ChangeState(ICarState state)
    {
        if (CurrentState != null)
            CurrentState.OnStateExit();
        CurrentState = state;

        CurrentState.OnStateEnter(this);
    }
}
