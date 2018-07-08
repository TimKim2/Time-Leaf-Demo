using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public GameObject s;
    public GameObject m;
    public GameObject h;
  
    private float time;

    private int scount = 0;
    private int mcount = 0;

    private void Start()
    {
        FSLocator.fadeDisplayer.FadeIn(Color.black, 2f);
    }

    void Update ()
    {
        time += Time.deltaTime;

        if (time >= 1f)
        {
            time = 0.0f;
            s.transform.Rotate(new Vector3(0, 0, 6));
            scount++;
        }

        if (scount >= 60)
        {
            scount = 0;
            m.transform.Rotate(new Vector3(0, 0, 6));
            mcount++;
        }

        if (mcount >= 60)
        {
            mcount = 0;
            m.transform.Rotate(new Vector3(0, 0, 6));
        }
    }
}
