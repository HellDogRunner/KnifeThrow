using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knifes : MonoBehaviour
{
    public GameObject stuckknife;
    public GameObject Log;
    private int KolvoKnifes = 0;
    public void Start()
    {
        var range = Random.Range(0f, 101f);

        if (25f > range)
        {
            KolvoKnifes = 1;
        }
        if (50f > range)
        {
            KolvoKnifes = 2;
        }
        if (75f > range)
        {
            KolvoKnifes = 3;
        }
        for (int i = 0; i < KolvoKnifes; i++)
            {

                GameObject kn = Instantiate(stuckknife, Log.transform.position, Quaternion.identity, Log.transform);
                var direction = (kn.transform.position - Log.transform.position).normalized;


                //placing on edge
                float r = 1.6f;    // distance from center
                float angle = Random.Range(0, Mathf.PI * 2);
                Vector2 pos2d = new Vector2(Mathf.Sin(angle) * r, Mathf.Cos(angle) * r);
                kn.transform.position = new Vector3(pos2d.x, pos2d.y + Log.transform.position.y, 0);
                //rotation
                Vector2 dir = kn.transform.position - Log.transform.position;
                float ang = Vector2.SignedAngle(Vector2.right, dir);
                kn.transform.eulerAngles = new Vector3(0, 0, ang);
            }
       
    }
   }
