using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] List<Transform> m_tranTarget;
    Vector3 m_v3Offset = new Vector3(0.0f, 35.0f, -35.0f);

    float m_fSmoothTime = 0.15f;
    Vector3 v3Velocity;

    float m_fMinZoom = 20.0f;
    float m_fMaxZoom = 10.0f;
    float m_fZoomLimit = 50.0f;

    [SerializeField] Camera m_mainCamera;

    void Start()
    {
        Init();
    }

    void Init()
    {
        
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        if (m_tranTarget.Count == 0)
            return;

        Move();
        Zoom();
    }

    void Zoom()
    {
        float fNewZoom = Mathf.Lerp(m_fMaxZoom, m_fMinZoom, GetDistance() / m_fZoomLimit);
        m_mainCamera.fieldOfView = Mathf.Lerp(m_mainCamera.fieldOfView, fNewZoom, Time.deltaTime);
    }

    float GetDistance()
    {
        var bounds = new Bounds(m_tranTarget[0].position, Vector3.zero);
        for (int i = 0; i < m_tranTarget.Count; i++)
        {
            bounds.Encapsulate(m_tranTarget[i].position);
        }
        return bounds.size.x;
    }

    void Move()
    {
        Vector3 v3Center = GetCenterPoint();
        Vector3 v3NewCenter = v3Center + m_v3Offset;
        transform.position = Vector3.SmoothDamp(transform.position, v3NewCenter, ref v3Velocity, m_fSmoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if (m_tranTarget.Count == 1)
            return m_tranTarget[0].position;

        var bounds = new Bounds(m_tranTarget[0].position, Vector3.zero);

        for (int i = 0; i < m_tranTarget.Count; i++)
        {
            bounds.Encapsulate(m_tranTarget[i].position);
        }

        return bounds.center;
    }
}