using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    class IconLoadData
    {
        public int id;
        public bool isLoaded = false;
        public ResourceRequest resourceRequest;
        public Sprite sprite;
    }

    static IconManager instance;
    static bool isInstance;

    List<IconLoadData> iconLoadData = new List<IconLoadData>();
    bool isLoaded = false;
    bool isLoading = false;

    private void Awake()
    {
        instance = this;
        isInstance = instance != null;
    }

    public static void StartLoad()
    {
        if (!isInstance)
        {
            return;
        }

        var iconData = MasterDataManager.GetMasterData<MasterData.icon>(MasterDataManager.MASTER_DATE_ID.ICON);
        foreach (var data in iconData.dataArray)
        {
            IconLoadData loadData = new IconLoadData();
            string path = data.Folder + data.Name;
            loadData.resourceRequest = Resources.LoadAsync<Sprite>(path);
            loadData.id = data.ID;
            instance.iconLoadData.Add(loadData);
        }

        instance.isLoading = true;
    }

    private void Update()
    {
        if (isLoaded)
        {
            return;
        }

        if (!isLoading)
        {
            return;
        }

        int loadedCount = 0;
        foreach (var data in iconLoadData)
        {
            if (data.isLoaded)
            {
                continue;
            }

            if (data.resourceRequest.isDone)
            {
                var asset = data.resourceRequest.asset;
                if (asset != null)
                {
                    data.sprite = asset as Sprite;
                }
                else
                {
                    Debug.LogError("[Icon] 読み込み失敗：" + data.id);
                }

                data.isLoaded = true;
                loadedCount++;
            }
        }

        if (loadedCount >= iconLoadData.Count)
        {
            isLoading = false;
            isLoaded = true;
        }
    }

    public static bool IsLoaded()
    {
        if (isInstance)
        {
            return instance.isLoaded;
        }

        return false;
    }

    public static Sprite GetIconSprite(int id)
    {
        if (!isInstance)
        {
            return null;
        }

        foreach (var data in instance.iconLoadData)
        {
            if (data.id == id)
            {
                if (!data.isLoaded)
                {
                    return instance.iconLoadData[0].sprite;
                }

                return data.sprite;
            }
        }

        return instance.iconLoadData[0].sprite;
    }
}
