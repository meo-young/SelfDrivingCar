using System.Collections.Generic;
using UnityEngine;

public class NavigationSystem : MonoBehaviour
{
    [SerializeField] List<Transform> destinationList;

    private Transform destinationInfo = null;

    public void SetDestination(int index)
    {
        destinationInfo = destinationList[index];
    }

    public Transform GetDestinationInfo()
    {
        if (destinationInfo == null)
            return null;

        return destinationInfo;
    }

    public float GetDistance()
    {
        if (destinationInfo == null)
            return 0f;

        return Vector3.Distance(transform.position, destinationInfo.position);
    }
}
