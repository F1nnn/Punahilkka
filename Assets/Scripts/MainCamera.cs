using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform target;
    private float topLeftX;
    private float topLeftY;
    private float bottomRightX;
    private float bottomRightY;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        //kamera seuraa, eik‰ mene kartan yli
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, topLeftX, bottomRightX),
            Mathf.Clamp(target.position.y, bottomRightY, topLeftY),
            transform.position.z
            );
    }

    //asetetaan kartan rajat mit‰ kamera ei voi ylitt‰‰
    public void SetBound(GameObject map)
    {
        SuperTiled2Unity.SuperMap config = map.GetComponent<SuperTiled2Unity.SuperMap>();
        float cameraSize = Camera.main.orthographicSize;
        float aspectRatio = Camera.main.aspect * cameraSize;
        topLeftX = map.transform.position.x + aspectRatio;
        topLeftY = map.transform.position.y - cameraSize;
        bottomRightX = map.transform.position.x + config.m_Width - aspectRatio;
        bottomRightY = map.transform.position.y - config.m_Height + cameraSize;
    }

}
