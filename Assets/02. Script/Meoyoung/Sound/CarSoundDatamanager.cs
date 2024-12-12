using UnityEngine;

public class CarSoundDatamanager : MonoBehaviour
{
    [Header("# Engine Sound")]
    [SerializeField] AudioClip engineSound;


    public AudioClip GetEngineSound()
    {
        return engineSound;
    }
}
