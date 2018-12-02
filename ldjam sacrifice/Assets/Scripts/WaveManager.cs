using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {



    private static WaveManager _WaveManager;

	// Use this for initialization
	void Start () {
        if (_WaveManager == null)
        {
            _WaveManager = this;
        }
        else if(_WaveManager != this)
        {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static WaveManager Instance() { return _WaveManager; }

    public void AddToEnemyList()
    {

    }
}
