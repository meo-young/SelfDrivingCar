using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    private bool bStart = false;
    private float counter = 0;

    public void OnClickHandler()
    {
        bStart = true;
    }

    private void Update()
    {
        if (!bStart)
            return;

        counter += Time.deltaTime;
    }

    public float GetTime()
    {
        return counter;
    }
}
