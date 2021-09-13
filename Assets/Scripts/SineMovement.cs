using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    Vector2 movePos;
    Vector2 startPos;

    public float moveFreq;
    public float moveDis;

    public bool moveHori;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveHori)
        {
            movePos.x = startPos.x + Mathf.Sin(Time.time * moveFreq) * moveDis;
            transform.position = new Vector2(movePos.x, transform.position.y);
        }
        else
        {
            movePos.y = startPos.y + Mathf.Sin(Time.time * moveFreq) * moveDis;
            transform.position = new Vector2(transform.position.x, movePos.y);
        }
    }
}
