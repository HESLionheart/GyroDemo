using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementHandler : MonoBehaviour {

    Text debug;
    [SerializeField]
    float speed;
    [SerializeField]
    float radius;

    void Update ()
    {
        Move();
	}


    private void Move()
    {
        float x = Input.acceleration.x * speed * Time.deltaTime;
        float y = Input.acceleration.y * speed * Time.deltaTime;
        transform.Translate(x,y,0);
        RestrictMove(transform.position);
    }
    void RestrictMove(Vector3 pos)
    {
        if (pos.y + radius > Camera.main.orthographicSize)
            pos.y = Camera.main.orthographicSize - radius;
        else if (pos.y - radius < -Camera.main.orthographicSize)
            pos.y = -Camera.main.orthographicSize + radius;
        float width = Utils.GetScreenWidth();
        if (pos.x + radius > width)
            pos.x = width - radius;
        else if (pos.x - radius < -width)
            pos.x = -width + radius;
        transform.position = pos;
    }
}
