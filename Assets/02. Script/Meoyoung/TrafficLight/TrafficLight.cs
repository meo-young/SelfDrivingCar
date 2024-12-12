using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField] GameObject red;
    [SerializeField] GameObject green;
    private float counter = 0f;
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter > 35f)
        {
            this.gameObject.tag = "Untagged";
            red.SetActive(false);
            green.SetActive(true);
        }
    }
}
