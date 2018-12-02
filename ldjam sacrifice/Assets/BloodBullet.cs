using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBullet : MonoBehaviour {

    public float BulletSpeed = 10;
    public float BulletDamage;

    private Vector2 _BulletDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(_BulletDirection * BulletSpeed * Time.deltaTime);
	}

    public void SetDirection(Vector2 a_direction) { _BulletDirection = a_direction; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Health -= BulletDamage;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Health -= BulletDamage;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider other)
    {
       
    }

    private void OnCollisionEnter2D(Collision collision)
    {
      
    }
}
