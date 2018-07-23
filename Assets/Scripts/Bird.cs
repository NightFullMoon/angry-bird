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
        Debug.Log("bird awake");
        sj2d = GetComponent<SpringJoint2D>();
        Debug.Log(sj2d == null);
        sj2d.enabled = false;
        Debug.Log(sj2d == null);

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
    bool isReady = false;


    private void OnMouseDown()
    {
        isClick = true;
    }

    private void OnMouseUp()
    {
        isClick = false;
        sj2d.enabled = false;

        GameManager.Instance.OnBirdSent();

        Invoke("Die",5f);

        //GameManager.Instance.OnCurrentBirdDie();
    }

    public LineRenderer leftLineRenderer;

    public LineRenderer rightLineRenderer;

    public Transform leftPos;


    //将当前的小鸟放置在发射台上
    public void BeReady(Vector3 position)
    {
        transform.position = position;

        Debug.Log(sj2d == null);
        sj2d.enabled = true;
        Debug.Log(sj2d == null);
        isReady = true;
        //GetComponent<SpringJoint2D>
    }

    //绘制拖拽时候的橡皮筋
    void DrawLine()
    {

        leftLineRenderer.SetPosition(0, leftPos.position);
        leftLineRenderer.SetPosition(1, transform.position);

        rightLineRenderer.SetPosition(0, rightPos.position);
        rightLineRenderer.SetPosition(1, transform.position);

    }


    void Die()
    {
        GameManager.Instance.OnCurrentBirdDie();
        Destroy(gameObject);
    }
}
