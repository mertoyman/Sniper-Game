﻿using UnityEngine;
using System.Collections;

public class ViveControllerLaptop : MonoBehaviour {
    public Transform _leftController;
    public Transform _rightController;
    public Transform _head;
    public bool _rifleCanFire;
    public Rifle _rifle;
    



    // Use this for initialization
    void Start () {
        
            _leftController.gameObject.SetActive(true);
            _rightController.gameObject.SetActive(true);
            _head.position = new Vector3(_head.position.x + 1, _head.position.y + 1.6f, _head.position.z);
            _leftController.position = new Vector3(_leftController.position.x + 1, _leftController.position.y + 1.5f, _leftController.position.z - 1.5f);
            _rightController.position = new Vector3(_rightController.position.x + 1, _rightController.position.y + 1.5f, _rightController.position.z - 0.1f);
       
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space")) {
            _rifle.ScopeSwitch();
        }

        if (Input.GetKeyDown("f")) {
            _rifle.Fire();
            _rifle.Invoke("TriggerUp", 0.5f);
        }

        if (Input.GetKey("e")) {
            _head.transform.Translate(Vector3.right * 0.1f);
        }

        if (Input.GetKey("q")) {
            _head.transform.Translate(Vector3.right * -0.1f);
        }
    }
}