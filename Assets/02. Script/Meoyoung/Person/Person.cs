using UnityEngine;

public class Person : MonoBehaviour
{
    [HideInInspector] public bool bStart = false;
    void Update()
    {
        if (!bStart)
            return;

       Vector3 pos = transform.position;
        pos.z += Time.deltaTime * 1.5f;
        this.transform.position = pos;
    }
}
