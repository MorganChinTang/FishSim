using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    //public static GameController Instance { get { return instance; } }

    public Transform startPoint = null;
    //public Transform checkPointsContainer = null;
    //private int lastCheckPointIndex = -1;

    private void Awake()
    {
        if(instance != null)
        {
            //Destroy(gameObject);
        }
        else
        {
            instance = this;
            //instance.Initialize();
        }
    }

    private void SetPlayerPosition(GameObject player, Vector3 position)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.position = position;
        }
        else
        {
            player.transform.position = position;
        }
    }
}
