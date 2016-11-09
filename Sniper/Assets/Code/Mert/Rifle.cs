﻿using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Rifle : MonoBehaviour {
    [SerializeField] private bool _rifleCanFire;

    [SerializeField] private AudioSource _rifleAudioSource;
    [SerializeField] private AudioClip _rifleShot;
    [SerializeField] private AudioClip _rifleChamber;
    [SerializeField] private AudioClip _magazineReload;
    
	[SerializeField] private EnemyManager _enemyManagerScript;
	[SerializeField] private Raycaster _raycaster;

   
    public bool _fired;

	private VibrateController _vibrateController;
	[SerializeField] private ParticleSystem _muzzleFlashPfx;
	private BulletUI _bulletUi;
	[SerializeField] private int _startingQuantityBullets;
	private int _currentQuantityBullets;

    // Use this for initialization
    void Start() {
        _rifleCanFire = true;
		_currentQuantityBullets = _startingQuantityBullets;
		_vibrateController = transform.GetComponent<VibrateController>();
		_bulletUi = transform.GetComponent<BulletUI>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void Fire() {
        if (_rifleCanFire) {
			_rifleCanFire = false;
			_vibrateController.VibrateForFiring ();
            _rifleAudioSource.PlayOneShot(_rifleShot);
			_muzzleFlashPfx.Emit (1);
			_bulletUi.DecreaseBulletIcons();
			_currentQuantityBullets --;
            _raycaster.Raycast();
        }
    }

    public void RoundChambered() {
        _rifleCanFire = true;
    }

    public void MagazineReloaded() {
		_bulletUi.RestoreBulletIcons();
		_currentQuantityBullets = _startingQuantityBullets;
		_rifleCanFire = true;
    }

    public void TriggerUp() {
		if (_currentQuantityBullets <= 0) {
            _rifleAudioSource.PlayOneShot(_magazineReload);
            Invoke("MagazineReloaded", 3.7f);
        }
        else {
            _rifleAudioSource.PlayOneShot(_rifleChamber);
            Invoke("RoundChambered", 1);
        }
    }
}