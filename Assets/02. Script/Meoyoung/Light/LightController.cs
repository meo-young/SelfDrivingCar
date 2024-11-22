using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject frontLight;
    [SerializeField] GameObject backLight;

    private void Awake()
    {
        OffBackLight();
        OffFrontLight();
    }

    public void ControlFrontLight()
    {
        frontLight.SetActive(!frontLight.activeSelf);
    }

    public void OffFrontLight()
    {
        if (frontLight.activeSelf)
            frontLight.SetActive(false);
    }

    public void OnFrontLight()
    {
        if (!frontLight.activeSelf)
            frontLight.SetActive(true);
    }

    public void OffBackLight()
    {
        if (backLight.activeSelf)
            backLight.SetActive(false);
    }

    public void OnBackLight()
    {
        if (!backLight.activeSelf)
            backLight.SetActive(true);
    }
}
