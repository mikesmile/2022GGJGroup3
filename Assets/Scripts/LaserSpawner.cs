using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public Transform[] FirePoint;
    public LineRenderer line;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(shoot());
        }
    }

    // Update is called once per frame
    IEnumerator shoot()
    {
        int RanPos = Random.Range(0, FirePoint.Length);
        RaycastHit2D hitinfo = Physics2D.Raycast(FirePoint[RanPos].position, FirePoint[RanPos].right);
        Debug.Log(hitinfo.transform.name);

        //if (hitinfo.transform.name == "Shield")
        //{
        //    Debug.Log("Def");
        //    line.SetPosition(0, FirePoint[RanPos].position);
        //    line.SetPosition(1, hitinfo.point);

        //}
        //else
        //{
        //    Debug.Log("hit");
            line.SetPosition(0, FirePoint[RanPos].position);
            line.SetPosition(1, FirePoint[RanPos].position + FirePoint[RanPos].right * 25);
        //}

        line.enabled = true;

        yield return new WaitForSeconds(3f);

        line.enabled = false;
    }
}
