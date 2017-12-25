using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementHandler : MonoBehaviour {

    Text debug;
    [SerializeField]
    float speed;
    float x_speed,y_speed;
    [SerializeField]
    float delta;
    [SerializeField]
    float radius;

    void Update ()
    {
        x_speed = speed;
        y_speed = speed;
        //x_speed= speed * (float)Screen.width / (float)Screen.height;
        //y_speed = speed * (float)Screen.height / (float)Screen.width;
        Move();
	}


    private void Move()
    {
        float x = Input.acceleration.x * x_speed * Time.deltaTime;
        float y = Input.acceleration.y * y_speed * Time.deltaTime;
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
