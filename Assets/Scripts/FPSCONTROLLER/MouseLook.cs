/**
* Student ID: 23571144
* Name: Jordan McCann
* File: MouseLook.cs
* Purpose: To Allow Camera Movement around within the scene

NOTE: This Script is UNMODIFIED and is Purely used to Incorperate First Person Camera Movement,
    This Script is Not Mine, please see further comments below on information about the author
    jiankaiwang.
*/

/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations 
 *               of first personal camera look on mouse moving.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;

    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // md is mosue delta
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
