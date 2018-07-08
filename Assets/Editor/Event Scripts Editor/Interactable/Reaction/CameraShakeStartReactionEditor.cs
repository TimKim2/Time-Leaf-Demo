using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(CameraShakeStartReaction))]
public class CameraShakeStartReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Camera Shake Start Reaction";
    }
}
