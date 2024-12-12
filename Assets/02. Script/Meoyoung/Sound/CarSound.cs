using UnityEngine;
using UnityEngine.AI;

public class CarSound : MonoBehaviour
{
    [Header("# Speed")]
    [SerializeField] public float minSpeed;
    [SerializeField] public float maxSpeed;
    [SerializeField] private float currentSpeed;

    [Header("# Pitch")]
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;

    private float pitchFromCar;
    private NavMeshAgent agent;
    private AudioSource carAudio;
    private CarSoundDatamanager soundData;

    private void Awake()
    {
        carAudio = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>(); 
        soundData = GetComponent<CarSoundDatamanager>();
    }

    public void StopSound()
    {
        carAudio.mute = true;
    }
    public void PlayEngineSound()
    {
        carAudio.clip = soundData.GetEngineSound();
        carAudio.mute = false;

        currentSpeed = agent.speed;
        pitchFromCar = agent.speed / 50f;

        if(currentSpeed < minSpeed)
        {
            carAudio.pitch = minPitch;
        }

        if(currentSpeed > minSpeed && currentSpeed < maxSpeed)
        {
            carAudio.pitch = minPitch + pitchFromCar;
        }

        if(currentSpeed > maxSpeed)
        {
            carAudio.pitch = maxPitch;
        }
    }
}
