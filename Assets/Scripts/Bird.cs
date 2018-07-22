using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public Transform rightPos;
    public float maxDistance = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            //鼠标一直按下，进行位置的跟随
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = transform.position.z;

            //进行长度限定
            if (maxDistance < Vector3.Distance(newPosition, rightPos.position))
            {
                Vector3 direction = (newPosition - rightPos.position).normalized;
                newPosition = direction * maxDistance + rightPos.position;
            }

            transform.position = newPosition;

        }
    }


    bool isClick = false;


    private void OnMouseDown()
    {
        isClick = true;
    }

    private void OnMouseUp()
    {
        isClick = false;
    }
}
