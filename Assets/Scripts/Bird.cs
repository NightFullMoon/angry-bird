using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public Transform rightPos;
    public float maxDistance = 1.5f;

    private SpringJoint2D sj2d;
    private void Awake()
    {
        sj2d = GetComponent<SpringJoint2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

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

            DrawLine();
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
        sj2d.enabled = false;
    }


    public LineRenderer leftLineRenderer;

    public LineRenderer rightLineRenderer;

    public Transform leftPos;

    //绘制拖拽时候的橡皮筋
    void DrawLine()
    {

        leftLineRenderer.SetPosition(0, leftPos.position);
        leftLineRenderer.SetPosition(1, transform.position);

        rightLineRenderer.SetPosition(0, rightPos.position);
        rightLineRenderer.SetPosition(1, transform.position);

    }
}
