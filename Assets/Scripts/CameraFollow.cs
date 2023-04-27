using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour

{
    public Transform target; // Hvad vi vil følge med kamera
    
    public float smoothTime = 0.15f; // Tid kamera må bruge på at følge target (indhente)

    private Vector3 velocity = Vector3.zero;


    // Minimum X enable og værdi
    public bool XMinEnable = false;
    public float XMinValue = 0;
    //  Maksimum X værdi enable og enable
    public bool XMaxEnable = false;
    public float XMaxValue = 0;

    public bool YMinEnable = false;
    public float YMinValue = 0;

    public bool YMaxEnable = false;
    public float YMaxValue = 0;

    void FixedUpdate()
    {

        Vector3 targetPos = target.position;
        // target og kamera sættes til samme z indeks..

        if (XMaxEnable && XMinEnable)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);
        }
        else if (XMaxEnable) 
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);
        }
        else if (XMinEnable) {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);
        }

        // 
        if (YMaxEnable && YMinEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);
        }
        else if (YMaxEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);
        }
        else if (YMinEnable)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);
        }


        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        //Vector3 desiredPosition = target.position + locationOffset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
/*
        Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;
*/
    }
}
