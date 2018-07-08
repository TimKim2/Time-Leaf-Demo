using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(ChallengeReaction))]
public class ChallengeReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Challenge Reaction";
    }
}

