using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomFollow : MonoBehaviour
{
    private new Transform transform;
    private Camera camera;
    [SerializeField, Range(0, 1)] private float zoomPercentage = 0.1f;
    [SerializeField] private float moveSpeed = 4;

    private Vector3 originalPosition;
    private float originalZoom;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        camera = GetComponent<Camera>();
        originalPosition = transform.position;
        originalZoom = camera.orthographicSize;
        camera.orthographicSize -= camera.orthographicSize * zoomPercentage;
    }

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos.x = (mousePos.x / Screen.width) * 2 - 1;
        mousePos.y = (mousePos.y / Screen.height) * 2 - 1;

        Vector3 direction = new Vector3(mousePos.x, mousePos.y, 0);

        Vector3 target = originalPosition + direction * (camera.orthographicSize * zoomPercentage);

        transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
