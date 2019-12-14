using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    enum State
    {
        None,
        LoadSystem,
        LoadGame,
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
        state = State.LoadSystem;
    }

    private void Update()
    {
        switch (state)
        {
            case State.LoadSystem:
                UpdateLoadSystem();
                break;
            case State.LoadGame:
                UpdateLoadGame();
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

    void UpdateLoadSystem()
    {
        if (MasterDataManager.IsLoaded())
        {
            IconManager.StartLoad();
            state = State.LoadGame;
        }
    }

    void UpdateLoadGame()
    {
        if (IconManager.IsLoaded())
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
            instance.gachaTop.Open(gachaTopData.dataArray);
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
                if (itemData.Topid == data.ID)
                {
                    itemDataList.Add(itemData);
                }
            }

            var dataArray = itemDataList.ToArray();
            instance.gachaItem.Open(dataArray);
        }
    }

    public static MasterData.CharacterData GetCharacterData(int id)
    {
        var characterData = MasterDataManager.GetMasterData<MasterData.Character>(MasterDataManager.MASTER_DATE_ID.CHARACTER);
        foreach (var character in characterData.dataArray)
        {
            if (character.ID == id)
            {
                return character;
            }
        }

        return null;
    }

    public static MasterData.GachaRareWeightData GetGachaRareWeightData(int topId, int groupId)
    {
        var gachaRareWeightData = MasterDataManager.GetMasterData<MasterData.GachaRareWeight>(MasterDataManager.MASTER_DATE_ID.GACHA_RATE_WEIGHT);
        foreach (var gachaRareWeight in gachaRareWeightData.dataArray)
        {
            if (gachaRareWeight.Topid == topId)
            {
                if (gachaRareWeight.Groupid == groupId)
                {
                    return gachaRareWeight;
                }
            }
        }

        return null;
    }

    public static void OpenGachaResult(ref MasterData.GachaItemData[] items)
    {
        List<float> weightList = new List<float>();
        foreach (var item in items)
        {
            var weightData = GetGachaRareWeightData(item.Topid, item.Groupid);
            weightList.Add(weightData.Weight);
        }

        int index = GetRandomIndex(weightList.ToArray());
        var character = GetCharacterData(items[index].Characterid);
        instance.gachaResult.Open(character);
    }

    static int GetRandomIndex(float[] weightTable)
    {
        var totalWeight = weightTable.Sum();
        var value = Random.Range(1.0f, totalWeight + 1.0f);
        var retIndex = -1;
        for (var i = 0; i < weightTable.Length; ++i)
        {
            if (weightTable[i] >= value)
            {
                retIndex = i;
                break;
            }
            value -= weightTable[i];
        }
        return retIndex;
    }
}
