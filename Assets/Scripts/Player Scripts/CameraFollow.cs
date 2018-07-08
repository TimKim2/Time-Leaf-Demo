using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public bool isLockedCamera = false;
    //test
    public GameObject FollowTargetOBJ;
    public float FollowSpeed;

    private float maxAxisX = -10;
    private float minAxisX = -10;
    private float maxAxisY = 10;
    private float minAxisY = 10;


    [HideInInspector]
    public bool isAccel = true;

    public void LockCamera()
    {
        isLockedCamera = true;
    }

    public void UnlockCamera()
    {
        isLockedCamera = false;
    }

    public bool IsLocked()
    {
        return isLockedCamera;
    }

    public void SetRestrictedArea(float maxX, float minX, float maxY, float minY)
    {
        maxAxisX = maxX;
        minAxisX = minX;
        maxAxisY = maxY;
        minAxisY = minY;
    }



    void FixedUpdate()
    {
        if (isLockedCamera)
        {
            var pos = FollowTargetOBJ.transform.position;
            this.transform.position = new Vector3(
                Mathf.Clamp(pos.x, minAxisX, maxAxisX),
                Mathf.Clamp(pos.y, minAxisY, maxAxisY),
                -10
            );

        }
        else
        {
            if (isAccel)
            {
                Vector3 NewPosition = Vector3.Lerp(this.transform.position, FollowTargetOBJ.transform.position, FollowSpeed * Time.deltaTime);
                this.transform.position = new Vector3(NewPosition.x, NewPosition.y, this.transform.position.z);
            }

            else
            {
                Vector3 NewPos = FollowTargetOBJ.transform.position;
                NewPos.z = -10;
                transform.position = Vector3.MoveTowards(this.transform.position, NewPos, FollowSpeed * Time.deltaTime);
            }
        }
    }
}
