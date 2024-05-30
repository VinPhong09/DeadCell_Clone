using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform playerTransform;
    public Transform npcTransform;
    public CinemachineConfiner confiner;
    public float zoomSpeed = 2.0f;
    public float minZoom = 2.0f;
    public float maxZoom = 8.0f;
    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;

    private float initialOrthoSize;
    private float targetOrthoSize;
    private float zoomVelocity = 0.0f;

    void Start()
    {
        initialOrthoSize = virtualCamera.m_Lens.OrthographicSize;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, npcTransform.position);

        if (distance < maxDistance && distance > minDistance)
        {
            float zoom = Mathf.SmoothDamp(virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, ref zoomVelocity, zoomSpeed);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(zoom, minZoom, maxZoom);
        }
        else
        {
            float zoomOut = Mathf.SmoothDamp(virtualCamera.m_Lens.OrthographicSize, initialOrthoSize, ref zoomVelocity, zoomSpeed);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(zoomOut, minZoom, maxZoom);
        }
    }

    private void LateUpdate()
    {
        if (confiner != null)
        {
            confiner.InvalidatePathCache();
        }
    }
}
