using UnityEngine;

public class CarController : MonoBehaviour
{
    public static CarController instance;

    public ICarState offState, driveState, stopState;

    [HideInInspector] public CarDataManager carData;
    [HideInInspector] public CarSound carSound;
    [HideInInspector] public UIMainView ui;
    [HideInInspector] public NavigationSystem navi;
    [HideInInspector] public TrafficLightDetection tld;
    [HideInInspector] public ObstacleDetection od;
    [HideInInspector] public LightController lc;
    [HideInInspector] public TimeChecker tc;

    [HideInInspector] public bool powerOn = false;
    [HideInInspector] public bool bDeceleration = false;

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
        navi = GetComponent<NavigationSystem>();
        tld = GetComponent<TrafficLightDetection>();
        od = GetComponent<ObstacleDetection>();
        lc = GetComponent<LightController>();
        ui = FindFirstObjectByType<UIMainView>();
        tc = GetComponent<TimeChecker>();
    }

    private void Start()
    {
        CurrentState = offState;
        ChangeState(CurrentState);
    }

    private void Update()
    {
        UpdateState();
        ui.UpdateDistance(navi.GetDistance());
        ui.UpdateTimeUI(tc.GetTime());
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
