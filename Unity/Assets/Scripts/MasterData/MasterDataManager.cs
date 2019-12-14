using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterDataManager : MonoBehaviour
{
    public enum MASTER_DATE_ID
    {
        NONE,

        CHARACTER,
        GACHA_TOP,
        GACHA_RATE_WEIGHT,
        GACHA_ITEM,

        MAX,
    }

    class MasterData
    {
        public MASTER_DATE_ID id;
        public bool isLoaded = false;
        public string fileName = "";
        public ScriptableObject dataObject = null;
        public ResourceRequest resourceRequest = null;
    }

    readonly string[] MASTER_DATA_FILE_TABLE = {
        "",
        "character",
        "gacha_top",
        "gacha_rare_weight",
        "gacha_item",
    };

    static MasterDataManager instance;
    static bool isInstance;

    bool isLoaded = false;
    MasterData[] masterDatas = new MasterData[(int)MASTER_DATE_ID.MAX];

    private void Awake()
    {
        instance = this;
        isInstance = instance != null;
    }

    void Start()
    {
        for (int i = 0; i < MASTER_DATA_FILE_TABLE.Length; i++)
        {
            MasterData data = new MasterData();
            string resPath = "master_data/" + MASTER_DATA_FILE_TABLE[i];
            data.fileName = MASTER_DATA_FILE_TABLE[i];
            data.id = (MASTER_DATE_ID)i;

            if (string.IsNullOrEmpty(data.fileName))
            {
                data.isLoaded = true;
            }
            else
            {
                data.resourceRequest = Resources.LoadAsync<ScriptableObject>(resPath);
            }

            masterDatas[i] = data;
        }
    }

    private void Update()
    {
        if (isLoaded)
        {
            return;
        }

        isLoaded = true;
        for (int i = 0; i < masterDatas.Length; i++)
        {
            var data = masterDatas[i];
            if (data.isLoaded)
            {
                continue;
            }

            if (data.resourceRequest.isDone)
            {
                var asset = data.resourceRequest.asset;
                if (asset != null)
                {
                    data.dataObject = data.resourceRequest.asset as ScriptableObject;
                    data.isLoaded = true;
                }
                else
                {
                    data.isLoaded = true;
                }
            }
            else
            {
                isLoaded = false;
            }
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

    /// <summary>
    /// マスターデータ取得
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    public static T GetMasterData<T>(MASTER_DATE_ID id) where T : ScriptableObject
    {
        for (int i = 0; i < instance.masterDatas.Length; i++)
        {
            var data = instance.masterDatas[i];
            if (!data.isLoaded)
            {
                continue;
            }

            if (data.id == id)
            {
                var masterData = data.dataObject as T;
                return masterData;
            }
        }

        return null;
    }



}
