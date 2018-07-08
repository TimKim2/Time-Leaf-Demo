using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(ItemSaveData))]
public class ItemSaveDataEditor : Editor
{
    public enum EditorType
    {
        ItemSaveDataAsset, AllItemSaveDataAsset, ItemSaveDataCollection
    }


    public EditorType editorType;
    public SerializedProperty itemSaveDatasProperty;


    private SerializedProperty descriptionProperty;
    private SerializedProperty satisfiedProperty;
    private SerializedProperty hashProperty;
    private ItemSaveData itemSaveData;


    private const float itemSaveDataButtonWidth = 30f;
    private const float toggleOffset = 30f;
    private const string itemSaveDataPropDescriptionName = "description";
    private const string itemSaveDataPropSatisfiedName = "satisfied";
    private const string itemSaveDataPropHashName = "hash";
    private const string blankDescription = "No itemSaveDatas set.";


    private void OnEnable()
    {
        itemSaveData = (ItemSaveData)target;

        if (target == null)
        {
            DestroyImmediate(this);
            return;
        }

        descriptionProperty = serializedObject.FindProperty(itemSaveDataPropDescriptionName);
        satisfiedProperty = serializedObject.FindProperty(itemSaveDataPropSatisfiedName);
        hashProperty = serializedObject.FindProperty(itemSaveDataPropHashName);
    }


    public override void OnInspectorGUI()
    {
        switch (editorType)
        {
            case EditorType.AllItemSaveDataAsset:
                AllItemSaveDatasAssetGUI();
                break;
            case EditorType.ItemSaveDataAsset:
                ItemSaveDataAssetGUI();
                break;
            case EditorType.ItemSaveDataCollection:
                InteractableGUI();
                break;
            default:
                throw new UnityException("Unknown ItemSaveDataEditor.EditorType.");
        }
    }


    private void AllItemSaveDatasAssetGUI()
    {
        EditorGUILayout.BeginHorizontal(GUI.skin.box);
        EditorGUI.indentLevel++;

        EditorGUILayout.LabelField(itemSaveData.description);

        if (GUILayout.Button("-", GUILayout.Width(itemSaveDataButtonWidth)))
            AllItemSaveDatasEditor.RemoveItemSaveData(itemSaveData);

        EditorGUI.indentLevel--;
        EditorGUILayout.EndHorizontal();
    }


    private void ItemSaveDataAssetGUI()
    {
        EditorGUILayout.BeginHorizontal(GUI.skin.box);
        EditorGUI.indentLevel++;

        EditorGUILayout.LabelField(itemSaveData.description);

        EditorGUI.indentLevel--;
        EditorGUILayout.EndHorizontal();
    }


    private void InteractableGUI()
    {
        serializedObject.Update();

        float width = EditorGUIUtility.currentViewWidth / 3f;

        EditorGUILayout.BeginHorizontal();

        int itemSaveDataIndex = AllItemSaveDatasEditor.TryGetItemSaveDataIndex(itemSaveData);

        if (itemSaveDataIndex == -1)
            itemSaveDataIndex = 0;

        itemSaveDataIndex = EditorGUILayout.Popup(itemSaveDataIndex, AllItemSaveDatasEditor.AllItemSaveDataDescriptions,
            GUILayout.Width(width));
        ItemSaveData globalItemSaveData = AllItemSaveDatasEditor.TryGetItemSaveDataAt(itemSaveDataIndex);
        descriptionProperty.stringValue = globalItemSaveData != null ? globalItemSaveData.description : blankDescription;

        hashProperty.intValue = Animator.StringToHash(descriptionProperty.stringValue);

        EditorGUILayout.PropertyField(satisfiedProperty, GUIContent.none, GUILayout.Width(width + toggleOffset));

        if (GUILayout.Button("-", GUILayout.Width(itemSaveDataButtonWidth)))
        {
            itemSaveDatasProperty.RemoveFromObjectArray(itemSaveData);
        }

        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }


    public static ItemSaveData CreateItemSaveData()
    {
        ItemSaveData newItemSaveData = CreateInstance<ItemSaveData>();
        string blankDescription = "No itemSaveDatas set.";
        ItemSaveData globalItemSaveData = AllItemSaveDatasEditor.TryGetItemSaveDataAt(0);
        newItemSaveData.description = globalItemSaveData != null ? globalItemSaveData.description : blankDescription;
        SetHash(newItemSaveData);
        return newItemSaveData;
    }


    public static ItemSaveData CreateItemSaveData(string description)
    {
        ItemSaveData newItemSaveData = CreateInstance<ItemSaveData>();
        newItemSaveData.description = description;
        SetHash(newItemSaveData);
        return newItemSaveData;
    }


    private static void SetHash(ItemSaveData itemSaveData)
    {
        itemSaveData.hash = Animator.StringToHash(itemSaveData.description);
    }
}
