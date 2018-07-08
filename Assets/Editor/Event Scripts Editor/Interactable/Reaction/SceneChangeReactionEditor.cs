#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(SceneChangeReaction))]
public class SceneChangeReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Scene Change";
    }
}
