using UnityEngine;

public class AISight : MonoBehaviour
{
    public AIAgent agent;
    public Transform eyes;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hostile")
        {
            RaycastHit hit;
            if(Physics.Linecast(eyes.position, other.transform.position, out hit))
            {
                Debug.DrawLine(eyes.position, hit.point, Color.blue, 1.0f);
                if(hit.transform.tag == "Hostile")
                {
                    Debug.DrawLine(eyes.position, other.transform.position, Color.red, 1.0f);
                    agent.HostileSpotted(other.transform);
                }
            }
            else
            {
                
            }
        }
    }
}
