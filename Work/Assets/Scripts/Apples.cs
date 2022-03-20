using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apples : MonoBehaviour
{
    public GameObject apple;
    public GameObject Log;
    public int KolvoApple=35;
    public float chance=101f;
    public void Start()
    {


        for (int i = 0; i < 5; i++)
        {
            var range = Random.Range(0f, chance);

            if (25f > range)
            {

                GameObject app = Instantiate(apple, Log.transform.position, Quaternion.identity, Log.transform);
                var direction = (app.transform.position - Log.transform.position).normalized;


                //placing on edge
                float r = 1.7f;    // distance from center
                float angle = Random.Range(0, Mathf.PI * 2);
                Vector2 pos2d = new Vector2(Mathf.Sin(angle) * r, Mathf.Cos(angle) * r);
                app.transform.position = new Vector3(pos2d.x, pos2d.y + Log.transform.position.y, 0);
                //rotation
                Vector2 dir = app.transform.position - Log.transform.position;
                float ang = Vector2.SignedAngle(Vector2.right, dir);
                app.transform.eulerAngles = new Vector3(0, 0, ang - 90);
            }
        }
    }
}
