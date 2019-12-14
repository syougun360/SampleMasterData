using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaItem : MonoBehaviour
{
    class UIGachaItemData
    {
        public RectTransform trans;
        public Text nameText;
        public Text rareText;
        public Text rateText;
        public Image iconImage;
    }

    [SerializeField]
    RectTransform contentsTrans = null;

    [SerializeField]
    GameObject gachaItemBase = null;

    [SerializeField]
    Button backButton = null;
    [SerializeField]
    Button okButton = null;

    List<UIGachaItemData> uiGachaItemData = new List<UIGachaItemData>();

    MasterData.GachaItemData[] gachaItemData = null;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gachaItemBase.SetActive(false);

        backButton.onClick.AddListener(() =>
        {
            Reset();
            gameObject.SetActive(false);
            GachaManager.OpenGachaTop();
        });

        okButton.onClick.AddListener(() =>
        {
            GachaManager.OpenGachaResult(ref gachaItemData);
            Reset();
            gameObject.SetActive(false);
        });
    }

    private void Reset()
    {
        gachaItemData = null;

        foreach (var data in uiGachaItemData)
        {
            Destroy(data.trans.gameObject);
        }

        uiGachaItemData.Clear();
    }

    public void Open(MasterData.GachaItemData[] datas)
    {
        gameObject.SetActive(true);

        RectTransform baseRectTrans = gachaItemBase.transform as RectTransform;
        float sizeY = baseRectTrans.sizeDelta.y;

        // 降順
        Array.Sort(datas, (a, b) => b.Groupid - a.Groupid);

        int maxCount = datas.Length;
        for (int i = 0; i < maxCount; i++)
        {
            var itemData = datas[i];
            var instance = Instantiate(gachaItemBase);
            instance.SetActive(true);

            instance.transform.SetParent(contentsTrans);
            instance.transform.localPosition = gachaItemBase.transform.localPosition + (Vector3.down * sizeY * i);

            UIGachaItemData uiData = new UIGachaItemData();
            uiData.trans = instance.transform as RectTransform;
            uiData.nameText = uiData.trans.Find("Text_Name").GetComponent<Text>();
            uiData.rareText = uiData.trans.Find("Text_Rare").GetComponent<Text>();
            uiData.rateText = uiData.trans.Find("Text_Rate").GetComponent<Text>();
            uiData.iconImage = uiData.trans.Find("Image_Icon").GetComponent<Image>();

            var characterData = GachaManager.GetCharacterData(itemData.Characterid);
            var rareWeightData = GachaManager.GetGachaRareWeightData(itemData.Topid, itemData.Groupid);
            uiData.nameText.text = characterData.Name;
            uiData.rareText.text = "★" + characterData.Rare;
            uiData.rateText.text = "排出率：" + rareWeightData.Weight + "%";
            uiData.iconImage.sprite = IconManager.GetIconSprite(characterData.Iconid);

            uiGachaItemData.Add(uiData);
        }

        var size = contentsTrans.sizeDelta;
        size.y = maxCount * sizeY;
        contentsTrans.sizeDelta = size;

        gachaItemData = datas;
    }


}
