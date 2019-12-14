using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    enum State
    {
        None,
        Load,
        Init,
        Execute,
        End
    }

    [SerializeField]
    GachaTop gachaTop = null;
    [SerializeField]
    GachaItem gachaItem = null;
    [SerializeField]
    GachaResult gachaResult = null;

    static GachaManager instance = null;
    static bool isInstance = false;

    State state = State.None;

    private void Awake()
    {
        instance = this;
        isInstance = instance != null;
    }

    private void Start()
    {
        state = State.Load;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Load:
                UpdateLoad();
                break;
            case State.Init:
                UpdateInit();
                break;
            case State.Execute:
                UpdateExecute();
                break;
            case State.End:
                UpdateEnd();
                break;
        }
    }

    void UpdateLoad()
    {
        if (MasterDataManager.IsLoaded())
        {
            state = State.Init;
        }
    }

    void UpdateInit()
    {
        OpenGachaTop();
        state = State.Execute;
    }

    void UpdateExecute()
    {

    }

    void UpdateEnd()
    {
        state = State.None;
    }

    public static void OpenGachaTop()
    {
        if (isInstance)
        {
            var gachaTopData = MasterDataManager.GetMasterData<MasterData.GachaTop>(MasterDataManager.MASTER_DATE_ID.GACHA_TOP);
            instance.gachaTop.Open(ref gachaTopData.dataArray);
        }
    }

    public static void OpenGachaItemList(MasterData.GachaTopData data)
    {
        if (isInstance)
        {
            List<MasterData.GachaItemData> itemDataList = new List<MasterData.GachaItemData>();

            var gachaItemData = MasterDataManager.GetMasterData<MasterData.GachaItem>(MasterDataManager.MASTER_DATE_ID.GACHA_ITEM);
            foreach (var itemData in gachaItemData.dataArray)
            {
                if (itemData.Top_Id == data.Id)
                {
                    itemDataList.Add(itemData);
                }
            }

            var dataArray = itemDataList.ToArray();
            instance.gachaItem.Open(ref dataArray);
        }
    }
}
