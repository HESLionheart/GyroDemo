using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Utils {

    public static float GetScreenWidth()
    {
        float screen_ratio = (float)Screen.width / (float)Screen.height;
        return Camera.main.orthographicSize * screen_ratio;
    }
}
