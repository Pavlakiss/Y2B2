using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsRotation:MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
    }
}
