using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    Vector3 distance;
    Vector3 camera;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camera = new Vector3(player.position.x + distance.x, 5.0f, player.position.z + distance.z);
        transform.position = camera;
    }
}
