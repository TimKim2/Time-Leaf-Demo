using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif 
[CustomEditor(typeof(CameraShakeStopReaction))]
public class CameraShakeStopReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Camera Shake Stop Reaction";
    }
}
