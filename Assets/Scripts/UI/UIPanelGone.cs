using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 111,309
public class UIPanelGone : MonoBehaviour {
    public GameObject ui_Button; // 껏다 킬놈 작은 ui 버튼
    public Transform ui_Panel;  // 움직여야할 녀석
    public Vector3 location; // 시작위치
    Vector3 destination; // 도착위치
    float x;

    private void Start()
    {
        destination = ui_Panel.localPosition;
    }


    public void GoneUIPanel()
    {
        StartCoroutine(GoneUI());
    }

    IEnumerator GoneUI()
    {
        Debug.Log("goneui");
        float delta = 0.0f;
        while(delta <= 0.3f)
        {
            delta += Time.deltaTime;
            x = Mathf.Lerp(location.x, destination.x, delta / 0.3f);
            ui_Panel.localPosition = new Vector3(x, location.y, 0);
            yield return new WaitForEndOfFrame();
        }
        ui_Button.SetActive(true);
        ui_Panel.gameObject.SetActive(false);
    }
}
