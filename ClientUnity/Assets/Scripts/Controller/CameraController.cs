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

    // Shake
    Vector3 axisShakeMin = new Vector3(1.0f, 1.0f, 1.0f);
    Vector3 axisShakeMax = new Vector3(1.05f, 1.05f, 1.05f);
    float timeOfShake;
    float timeOfShakeStore;
    bool shake;
    Vector3 startPos;

    void Start()
    {
        Init();
    }

    void Init()
    {
        shake = false;
        startPos = transform.position;
        timeOfShakeStore = timeOfShake;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Press Camera / B");
            ShakeCamera(0.5f);
        }
    }

    void FixedUpdate()
    {
        if (shake)
        {
            transform.position = startPos + new Vector3(Random.Range(axisShakeMin.x, axisShakeMax.x), Random.Range(axisShakeMin.y, axisShakeMax.y), Random.Range(axisShakeMin.z, axisShakeMax.z));
            timeOfShake -= Time.deltaTime;
            if (timeOfShake <= 0.0f)
            {
                shake = false;
                transform.position = startPos;
            }
        }
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

    public void ShakeCamera(float shakeTime = -1.0f)
    {
        if (shakeTime > 0.0f)
        {
            timeOfShake = shakeTime;
        }
        else
            timeOfShake = timeOfShakeStore;

        shake = true;

        startPos = transform.position;
    }
}