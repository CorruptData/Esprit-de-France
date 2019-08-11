using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class AltCameraFollow: MonoBehaviour
{
    private int pixelsPerUnit = 100;
    private Camera _camera;
    public Player p;

    protected new Camera camera { get { if (_camera == null) { _camera = GetComponent<Camera>(); } return _camera; } }

    protected virtual void Awake()
    {
        Calculate();
    }

    protected virtual void Update()
    {
        Calculate();
        if (p != null)
        {
            camera.transform.localPosition = new Vector3(p.transform.localPosition.x, p.transform.localPosition.y, -10);
        }
    }

    protected virtual void LateUpdate()
    {
        Calculate();
    }

    private void Calculate()
    {
        int zoom = (int)Mathf.Max(1f, (Screen.height / 240f));
        camera.orthographicSize = ((Screen.height / 2f) / (float)pixelsPerUnit) / (float)zoom;
    }
}