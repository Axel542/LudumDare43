using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpiral : MonoBehaviour {

    public float RotationSpeed = 500;
    public float MovementSpeed = 5;
    public float AttackDamage = 10;

    private Transform _EnemyTransform;
    private Summoner _Summoner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
        if(_Summoner == null && _EnemyTransform != null)
        {
           _Summoner = _EnemyTransform.GetComponent<Summoner>();
        }
        else if(_Summoner != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _Summoner.GetTarget().position, MovementSpeed * Time.deltaTime);

        }
	}

    public void SetTransform(Transform a_transform) { _EnemyTransform = a_transform; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
