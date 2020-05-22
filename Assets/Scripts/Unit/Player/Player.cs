using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class Player : AUnit
{
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    public VectorValue startingPostion;
    public PlayerState currentState;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        transform.position = startingPostion.runtimeValue;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveX", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackGo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
        
    }

    private IEnumerator AttackGo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null; // wait for one frame
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();// not too fast on diangular
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public override void Knock(float knockTime, float damage)
    {
        if (TakeDamage(damage))
        {
            currentState = PlayerState.stagger;
            StartCoroutine(knockBack.KnockCo(this, knockTime));
        }
    }

    
}

