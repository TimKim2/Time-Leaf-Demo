using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(AllItemSaveDatas))]
public class AllItemSaveDatasEditor : Editor
{
    public static string[] AllItemSaveDataDescriptions
    {
        get
        {
            if (allItemSaveDataDescriptions == null)
            {
                SetAllItemSaveDataDescriptions();
            }
            return allItemSaveDataDescriptions;
        }
        private set { allItemSaveDataDescriptions = value; }
    }


    private static string[] allItemSaveDataDescriptions;


    private ItemSaveDataEditor[] itemSaveDataEditors;
    private AllItemSaveDatas allItemSaveDatas;
    private string newItemSaveDataDescription = "New ItemSaveData";


    private const string creationPath = "Assets/Resources/AllItemSaveDatas.asset";
    private const float buttonWidth = 30f;


    private void OnEnable()
    {
        allItemSaveDatas = (AllItemSaveDatas)target;

        if (allItemSaveDatas.itemSaveDatas == null)
            allItemSaveDatas.itemSaveDatas = new ItemSaveData[0];

        if (itemSaveDataEditors == null)
        {
            CreateEditors();
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < itemSaveDataEditors.Length; i++)
        {
            DestroyImmediate(itemSaveDataEditors[i]);
        }

        itemSaveDataEditors = null;
    }


    private static void SetAllItemSaveDataDescriptions()
    {
        AllItemSaveDataDescriptions = new string[TryGetItemSaveDatasLength()];

        for (int i = 0; i < AllItemSaveDataDescriptions.Length; i++)
        {
            AllItemSaveDataDescriptions[i] = TryGetItemSaveDataAt(i).description;
        }
    }


    public override void OnInspectorGUI()
    {
        if (itemSaveDataEditors.Length != TryGetItemSaveDatasLength())
        {
            for (int i = 0; i < itemSaveDataEditors.Length; i++)
            {
                DestroyImmediate(itemSaveDataEditors[i]);
            }

            CreateEditors();
        }

        for (int i = 0; i < itemSaveDataEditors.Length; i++)
        {
            itemSaveDataEditors[i].OnInspectorGUI();
        }

        if (TryGetItemSaveDatasLength() > 0)
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }

        EditorGUILayout.BeginHorizontal();
        newItemSaveDataDescription = EditorGUILayout.TextField(GUIContent.none, newItemSaveDataDescription);
        if (GUILayout.Button("+", GUILayout.Width(buttonWidth)))
        {
            AddItemSaveData(newItemSaveDataDescription);
            newItemSaveDataDescription = "New ItemSaveData";
        }
        EditorGUILayout.EndHorizontal();
    }


    private void CreateEditors()
    {
        itemSaveDataEditors = new ItemSaveDataEditor[allItemSaveDatas.itemSaveDatas.Length];

        for (int i = 0; i < itemSaveDataEditors.Length; i++)
        {
            itemSaveDataEditors[i] = CreateEditor(TryGetItemSaveDataAt(i)) as ItemSaveDataEditor;
            itemSaveDataEditors[i].editorType = ItemSaveDataEditor.EditorType.AllItemSaveDataAsset;
        }
    }


    [MenuItem("Assets/Create/AllItemSaveDatas")]
    private static void CreateAllItemSaveDatasAsset()
    {
        if (AllItemSaveDatas.Instance)
            return;

        AllItemSaveDatas instance = CreateInstance<AllItemSaveDatas>();
        AssetDatabase.CreateAsset(instance, creationPath);

        AllItemSaveDatas.Instance = instance;

        instance.itemSaveDatas = new ItemSaveData[0];
    }


    private void AddItemSaveData(string description)
    {
        if (!AllItemSaveDatas.Instance)
        {
            Debug.LogError("AllItemSaveDatas has not been created yet.");
            return;
        }

        ItemSaveData newItemSaveData = ItemSaveDataEditor.CreateItemSaveData(description);
        newItemSaveData.name = description;

        Undo.RecordObject(newItemSaveData, "Created new ItemSaveData");

        AssetDatabase.AddObjectToAsset(newItemSaveData, AllItemSaveDatas.Instance);
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newItemSaveData));

        ArrayUtility.Add(ref AllItemSaveDatas.Instance.itemSaveDatas, newItemSaveData);

        EditorUtility.SetDirty(AllItemSaveDatas.Instance);

        SetAllItemSaveDataDescriptions();
    }


    public static void RemoveItemSaveData(ItemSaveData itemSaveData)
    {
        if (!AllItemSaveDatas.Instance)
        {
            Debug.LogError("AllItemSaveDatas has not been created yet.");
            return;
        }

        Undo.RecordObject(AllItemSaveDatas.Instance, "Removing itemSaveData");

        ArrayUtility.Remove(ref AllItemSaveDatas.Instance.itemSaveDatas, itemSaveData);

        DestroyImmediate(itemSaveData, true);
        AssetDatabase.SaveAssets();

        EditorUtility.SetDirty(AllItemSaveDatas.Instance);

        SetAllItemSaveDataDescriptions();
    }


    public static int TryGetItemSaveDataIndex(ItemSaveData itemSaveData)
    {
        for (int i = 0; i < TryGetItemSaveDatasLength(); i++)
        {
            if (TryGetItemSaveDataAt(i).hash == itemSaveData.hash)
                return i;
        }

        return -1;
    }


    public static ItemSaveData TryGetItemSaveDataAt(int index)
    {
        ItemSaveData[] allItemSaveDatas = AllItemSaveDatas.Instance.itemSaveDatas;

        if (allItemSaveDatas == null || allItemSaveDatas[0] == null)
            return null;

        if (index >= allItemSaveDatas.Length)
            return allItemSaveDatas[0];

        return allItemSaveDatas[index];
    }


    public static int TryGetItemSaveDatasLength()
    {
        if (AllItemSaveDatas.Instance.itemSaveDatas == null)
            return 0;

        return AllItemSaveDatas.Instance.itemSaveDatas.Length;
    }
}
