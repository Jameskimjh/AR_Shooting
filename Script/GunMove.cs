using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    RaycastHit enemyhit;

    private void Awake()
    {
        enemyhit = GameManager.instance.hit;
    }

    private void Update()
    {
        transform.LookAt(transform.position + enemyhit.transform.position);
    }
}
