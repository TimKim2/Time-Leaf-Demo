#if UNITY_EDITOR 
using UnityEditor;
#endif 
using UnityEngine;

[CustomEditor(typeof(MoveAroundReaction))]
public class MoveAroundReactionEditor : ReactionEditor
{

	protected override string GetFoldoutLabel()
	{
		return "MoveAround Reaction";
	}
}
