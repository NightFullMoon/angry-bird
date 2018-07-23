using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{

    public float maxSpeed = 10;
    public float minSpeed = 5;

    private SpriteRenderer render;

    public Sprite hurt;

    private Animator animator;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);

        if (maxSpeed < collision.relativeVelocity.magnitude)
        {

            //直接死亡
            //Destroy(gameObject);
            animator.SetTrigger("die");
        }
        else if (minSpeed < collision.relativeVelocity.magnitude)
        {

            animator.SetTrigger("hurt");
            //受伤
            //render.sprite = hurt;
            //Debug.Log("受伤");
            //Debug.Log()
        }
    }

    // 死亡动画结束时候调用的函数
    public void onDie()
    {
        Destroy(gameObject);
    }

}
