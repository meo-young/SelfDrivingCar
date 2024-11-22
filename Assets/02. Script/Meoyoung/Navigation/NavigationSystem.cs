using System.Collections.Generic;
using UnityEngine;

public class NavigationSystem : MonoBehaviour
{
    public static NavigationSystem instance;

    [SerializeField] List<Transform> destinationList;
    [SerializeField] GameObject navigationUI;

    private Transform destinationInfo = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void OnClickHandler(int index)
    {
        destinationInfo = destinationList[index];

        if (navigationUI.activeSelf)
            navigationUI.SetActive(false);
    }

    public Transform GetDestinationInfo()
    {
        if (destinationInfo == null)
            return null;

        return destinationInfo;
    }
}
