using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    public float maxSpeed = 10;
    public float minSpeed = 5;

    private SpriteRenderer render;

    public Sprite hurt;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);

        if (maxSpeed < collision.relativeVelocity.magnitude)
        {
            //直接死亡
            Destroy(gameObject);
        }
        else if (minSpeed < collision.relativeVelocity.magnitude) {
            //受伤
            render.sprite = hurt;
        }
    }
}
