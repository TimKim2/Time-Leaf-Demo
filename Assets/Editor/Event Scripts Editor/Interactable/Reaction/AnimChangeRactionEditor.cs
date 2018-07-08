#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(AnimChangeReaction))]
public class AnimChangeRactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Anim Change Reaction";
    }
}

