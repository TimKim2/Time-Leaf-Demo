using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(QuestReaction))]
public class QuestReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Quest Text Reaction";
    }
}
