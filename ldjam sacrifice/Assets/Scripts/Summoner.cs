using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour {

    public float Speed = 15;
    public float Damage = 10;
    public GameObject BloodSpiral;
    

    private Transform _Target;
    private Animator _Animator;
    private float _SummonCooldown = 40.0f;
    private bool _StartCooldown = true;
    private float _Attackcooldown = 3.2f;
    private bool _IsCasting = false;
    private bool _IsWalking = false;

	// Use this for initialization
	void Start () {
        _Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _Animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Attack();
        SummonDemon();
	}

    void Move()
    {
        if (Vector2.Distance(transform.position, _Target.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, _Target.position, Speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        if(Vector2.Distance(transform.position,_Target.position) <= 3)
        {
            _Attackcooldown -= Time.deltaTime;
            if(_Attackcooldown < 0)
            {
                _Attackcooldown = 3.2f;
                GameObject go = Instantiate(BloodSpiral, transform.position, new Quaternion());
                go.GetComponent<BloodSpiral>().SetTransform(transform);
                Destroy(go, 8);
            }
            
        }
    }

    public Transform GetTarget() { return _Target; }

    void SummonDemon()
    {
        if(Vector2.Distance(transform.position, _Target.position) < 5)
        {
            if (_StartCooldown)
            {
                GameObject GO = Instantiate(MonsterInstance.Instance.DemonPrefab, transform.position, new Quaternion());
                _StartCooldown = false;
            }
            else
            {
                _SummonCooldown -= Time.deltaTime;
                if (_SummonCooldown < 0)
                {
                    _SummonCooldown = 40.0f;
                    GameObject GO = Instantiate(MonsterInstance.Instance.DemonPrefab, transform.position, new Quaternion());
                }
            }
        }
       
    }

    void UpdateAnimator()
    {
        _Animator.SetBool("IsCasting", _IsCasting);
        _Animator.SetBool("IsWalking", _IsWalking);
    }
}
