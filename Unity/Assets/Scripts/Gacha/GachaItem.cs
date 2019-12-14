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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        backButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            GachaManager.OpenGachaTop();
        });

        okButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);

        });
    }

    public void Open(ref MasterData.GachaItemData[] datas)
    {
        gameObject.SetActive(true);

        RectTransform baseRectTrans = gachaItemBase.transform as RectTransform;
        float sizeY = baseRectTrans.sizeDelta.y;

        int maxCount = datas.Length;
        for (int i = 0; i < maxCount; i++)
        {
            var gachaData = datas[i];
            var instance = GameObject.Instantiate(gachaItemBase);
            instance.transform.SetParent(contentsTrans);
            instance.transform.localPosition = gachaItemBase.transform.localPosition + (Vector3.down * sizeY * i);

            UIGachaItemData uiData = new UIGachaItemData();
            uiData.trans = instance.transform as RectTransform;
            uiData.nameText = uiData.trans.Find("Text_Name").GetComponent<Text>();
            uiData.rareText = uiData.trans.Find("Text_Rare").GetComponent<Text>();
            uiData.rateText = uiData.trans.Find("Text_Rate").GetComponent<Text>();


            uiGachaItemData.Add(uiData);
        }

        var size = contentsTrans.sizeDelta;
        size.y = maxCount * sizeY;
        contentsTrans.sizeDelta = size;

        gachaItemBase.SetActive(false);
    }


}
