using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

    public float Speed;
    public float Damage;
    public float Health = 100;
    public GameObject HealthBar;


    private Transform _Target;
    private Rigidbody2D _Rb;
    private Animator _Animator;
    private SpriteRenderer _SpriteRenderer;
    private bool _IsWalking = false;
    private bool _IsAttacking = false;
    private float _AttackCooldown = 2.5f;
    private Slider HealthSlider;
    private GameObject _HealthBar;
    private float _Health;

	// Use this for initialization
	void Start () {
        _Health = Health;
        _Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Rb = GetComponent<Rigidbody2D>();
        _Animator = GetComponent<Animator>();
        _HealthBar = Instantiate(HealthBar, Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.1f, 0)),new Quaternion());
        _HealthBar.transform.parent = GameManager.Instance.CanvasObject.transform;
        HealthSlider = _HealthBar.GetComponent<Slider>();
        HealthSlider.GetComponentInChildren<Text>().text = "Demon";
        HealthSlider.maxValue = Health;
       
    }
	
	// Update is called once per frame
	void Update () {
        if(Health <= _Health / 3)
        {
            _HealthBar.GetComponent<HealthBar>().HealthImage.color = new Color(1, 0, 0, 1);
        }
        else if(Health <= _Health/1.5f)
        {
            _HealthBar.GetComponent<HealthBar>().HealthImage.color = new Color(1, 0.5329f, 0, 1);
        }
        _HealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.1f, 0));
        HealthSlider.value = Health;
        if (Vector2.Distance(transform.position, _Target.position)> 0.1f)
        {
            Vector2 newDirection = (this.transform.position -_Target.position).normalized;
            _Rb.velocity = -newDirection * Speed;
            //transform.position = Vector2.MoveTowards(transform.position, _Target.position, Speed * Time.deltaTime);
            _IsWalking = true;
        }
        else
        {
            _Rb.velocity = Vector2.zero;
            _IsWalking = false;
        }
        Attack();
        Death();
        UpdateAnimator();
        if(_Target.position.x > transform.position.x)
        {
            _SpriteRenderer.flipX = false;
        }
        else if(_Target.position.x < transform.position.x)
        {
            _SpriteRenderer.flipX = true;
        }

	}

    private void Attack()
    {
        if (Vector2.Distance(transform.position, _Target.position) < 0.2f)
        {
            _AttackCooldown -= Time.deltaTime;
            _IsAttacking = true;
            if(_AttackCooldown < 0)
            {
                _AttackCooldown = 2.5f;
                _Target.GetComponent<Player>().Health -= (int)Damage;
            }
        }
        else
        {
            _IsAttacking = false;
        }
    }

    private void Death()
    {
        if(Health < 0)
        {
            Destroy(this.gameObject);
            Destroy(_HealthBar);
        }
    }

    private void UpdateAnimator()
    {
        _Animator.SetBool("IsAttacking", _IsAttacking);
        _Animator.SetBool("IsWalking", _IsWalking);
    }
}
