using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float posX;
    public float posZ;
    public GameObject player;
    Vector3 posStart, posFinish;

    void FixedUpdate()
    {
        posX = transform.position.x;
        posZ = transform.position.z;

        posStart = new Vector3(posX, 20, posZ);
        posFinish = new Vector3(player.transform.position.x, 20, player.transform.position.z);

        transform.position = Vector3.Lerp(posStart, posFinish, 5f * Time.deltaTime);
    }
}
