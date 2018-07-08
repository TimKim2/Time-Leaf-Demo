using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item Save Data들을 모아 놓은 .asset이다.
public class AllItemSaveDatas : ResettableScriptableObject
{
    public ItemSaveData[] itemSaveDatas;


    private static AllItemSaveDatas instance;


    private const string loadPath = "AllItemSaveDatas";


    public static AllItemSaveDatas Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<AllItemSaveDatas>();
            if (!instance)
                instance = Resources.Load<AllItemSaveDatas>(loadPath);
            if (!instance)
                Debug.LogError("AllItemSaveDatas has not been created yet.  Go to Assets > Create > AllItemSaveDatas.");
            return instance;
        }
        set { instance = value; }
    }


    public override void Reset()
    {
        if (itemSaveDatas == null)
            return;

        for (int i = 0; i < itemSaveDatas.Length; i++)
        {
            itemSaveDatas[i].satisfied = false;
        }
    }

    public void ResetOnlyItems()
    {
        if (itemSaveDatas == null)
            return;

        for (int i = 0; i < 6; i++)
        {
            itemSaveDatas[i].satisfied = false;
        }
    }

    public static bool CheckItemSaveData(ItemSaveData requiredItemSaveData)
    {
        ItemSaveData[] allItemSaveDatas = Instance.itemSaveDatas;
        ItemSaveData globalItemSaveData = null;

        if (allItemSaveDatas != null && allItemSaveDatas[0] != null)
        {
            for (int i = 0; i < allItemSaveDatas.Length; i++)
            {
                if (allItemSaveDatas[i].hash == requiredItemSaveData.hash)
                    globalItemSaveData = allItemSaveDatas[i];
            }
        }

        if (!globalItemSaveData)
            return false;

        return globalItemSaveData.satisfied == requiredItemSaveData.satisfied;
    }

}
