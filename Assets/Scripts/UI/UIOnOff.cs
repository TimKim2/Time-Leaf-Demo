using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnOff : MonoBehaviour
{
    public GameObject ui_Panel;
    public GameObject ui;
    float x;
    public Transform location;
    Vector3 source;
    public Vector3 destination = new Vector3(643, 466, 0);

    private void Start()
    {
        ui_Panel.SetActive(false);
    }

    public void OnUI()
    {
        source = location.localPosition;
        ui_Panel.SetActive(true);
        StartCoroutine(MoveToDestination());
    }

    IEnumerator MoveToDestination()
    {
        ui.SetActive(false);
        float delta = 0.0f;
        while ( delta <= 0.3f)
        {
            delta += Time.deltaTime;
            x = Mathf.Lerp( source.x, destination.x, delta / 0.3f );
            location.localPosition = new Vector3(x, destination.y, 0);
            yield return new WaitForEndOfFrame();
        }
        //gameObject.SetActive(false);
    }
}
