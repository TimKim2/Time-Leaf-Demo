#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(SaveReaction))]
public class SaveReactionEditor : ReactionEditor
{
	protected override string GetFoldoutLabel()
	{
		return "Save Reaction";
	}
}
	
