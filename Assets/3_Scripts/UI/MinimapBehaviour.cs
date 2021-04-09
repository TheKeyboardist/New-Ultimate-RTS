using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapBehaviour : MonoBehaviour
{

    public Transform player;

    void LateUpdate()
    {
        Vector3 nPosition = player.position;
        nPosition.y = transform.position.y;
        transform.position = nPosition;
        transform.rotation = Quaternion.Euler(0f, player.eulerAngles.y, 0f);
    }
}
