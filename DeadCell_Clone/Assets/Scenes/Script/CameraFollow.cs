using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset ;
    public float smoot = -0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetP = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetP, ref velocity, smoot);
    }
}
