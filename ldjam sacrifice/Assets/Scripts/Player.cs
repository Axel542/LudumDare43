using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterController Controller;

    public int Health;
    public int Blood;

    public float MovementSpeed;

    public GameObject BloodBulletPrefab;

    private Vector3 moveDirection;

    private float _SacrificeCooldown;
    private float _AttackCooldown;
    private float _SpecialCooldown;
    private SpriteRenderer _SpriteRenderer;
    private Animator _Animator;
    private bool _IsWalking = false;
    private bool _IsCasting = false;
    private float _BulletCooldown = 0.4f;
    private float _SacrificeTimer = 2.5f;
    private float deadzone = 0.2f;
    private List<Enemy> _Enemies;
    private Rigidbody2D _Rb;
    private Vector2 moveVector;


	// Use this for initialization
	void Start () {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Animator = GetComponent<Animator>();
        _Rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!_IsCasting)
        {
            Move();
        }

        UpdateAnimator();
        BloodBullet();
        _BulletCooldown -= Time.deltaTime;
    }

    /// <summary>
    /// Player movement
    /// </summary>
    void Move()
    {
        
            moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetAxisRaw("Horizontal") > deadzone || Input.GetAxisRaw("Horizontal") < (-deadzone)
                || Input.GetAxisRaw("Vertical") > deadzone || Input.GetAxisRaw("Vertical") < (-deadzone))
            {
            _IsWalking = true;
            }
            else
            {
            _IsWalking = false;
            }
        _Rb.velocity = moveVector * MovementSpeed;



        //if (Input.GetKey(KeyCode.W))
        //{
        //    Controller.Move(Vector3.up * MovementSpeed * Time.deltaTime);
        //    _IsWalking = true;
        //}

        // if(Input.GetKey(KeyCode.S))
        //{
        //    Controller.Move(-Vector3.up * MovementSpeed * Time.deltaTime);
        //    _IsWalking = true;
        //}

        if(Input.GetKey(KeyCode.D))
       {
           
           _SpriteRenderer.flipX = false;
           _IsWalking = true;
       }

   if(Input.GetKey(KeyCode.A))
  {
      _SpriteRenderer.flipX = true;
      _IsWalking = true;
  }

        // if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        //{
        //    _IsWalking = false;
        //}
    }

    void Attack()
    {

    }

    void Sacrifice()
    {
 
        if(Input.GetKey(KeyCode.E))
        {
            _SacrificeTimer -= Time.deltaTime;
            if(_SacrificeTimer < 0)
            {
                _SacrificeTimer = 2.5f;

            }
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            _SacrificeTimer = 2.5f;
        }
    }

    void SwitchAbilities()
    {

    }

    void Absorb()
    {

    }

    public void TakeDamage(float damageAmount) { Health -= (int)damageAmount; }

    void BloodBullet()
    {
        if(Input.GetMouseButton(1))
        {
           if(_BulletCooldown < 0)
            {
                _BulletCooldown = 0.4f;
                if(Blood > 0)
                {
                    Blood -= 5;
                }
                if(Blood <= 0)
                {
                    Health -= 5;
                }
               
                Vector2 newDirection = (this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
                GameObject go = Instantiate(BloodBulletPrefab,transform.position, new Quaternion());
                go.GetComponent<BloodBullet>().SetDirection(newDirection);
                Destroy(go, 5);
            }
        }
        else
        {

        }
    }

    /// <summary>
    /// Updates the animator component.
    /// </summary>
    void UpdateAnimator()
    {
        _Animator.SetBool("IsWalking", _IsWalking);
        _Animator.SetBool("IsCasting", _IsCasting);
    }
}
