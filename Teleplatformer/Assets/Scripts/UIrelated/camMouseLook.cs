﻿using UnityEngine;
using System.Collections;

public class camMouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public bool fpsControls = false;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            fpsControls = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            fpsControls = false;
        }
        if (fpsControls == true)
        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
        }
    }
}
