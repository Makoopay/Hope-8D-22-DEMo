using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        //Sets camera to player position
        transform.position = player.transform.position;
    }
}