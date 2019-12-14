using System;
using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEngine;
using UnityEngine.UI;

public class GachaTop : MonoBehaviour
{
    class UIGachaTopData
    {
        public RectTransform trans;
        public Text nameText;
        public Button button;
    }

    [SerializeField]
    RectTransform contentsTrans = null;

    [SerializeField]
    GameObject gachaItemBase = null;

    List<UIGachaTopData> uiGachaTopData = new List<UIGachaTopData>();

    private void Start()
    {
        gameObject.SetActive(false);
        gachaItemBase.SetActive(false);
    }

    private void Reset()
    {
        foreach (var data in uiGachaTopData)
        {
            Destroy(data.trans.gameObject);
        }

        uiGachaTopData.Clear();
    }

    public void Open(MasterData.GachaTopData[] datas)
    {
        gameObject.SetActive(true);

        RectTransform baseRectTrans = gachaItemBase.transform as RectTransform;
        float sizeY = baseRectTrans.sizeDelta.y;

        // 降順
        Array.Sort(datas, (a, b) => b.Drawpriority - a.Drawpriority);

        int maxCount = datas.Length;
        for (int i = 0; i < maxCount; i++)
        {
            var gachaData = datas[i];
            var instance = Instantiate(gachaItemBase);
            instance.SetActive(true);

            instance.transform.SetParent(contentsTrans);
            instance.transform.localPosition = gachaItemBase.transform.localPosition + (Vector3.down * sizeY * i);

            UIGachaTopData uiData = new UIGachaTopData();
            uiData.trans = instance.transform as RectTransform;
            uiData.button = uiData.trans.GetComponent<Button>();
            uiData.nameText = uiData.trans.GetComponentInChildren<Text>();

            uiData.nameText.text = gachaData.Name;
            uiData.button.onClick.AddListener(()=> {
                OnClick(gachaData);
            });

            uiGachaTopData.Add(uiData);
        }

        var size = contentsTrans.sizeDelta;
        size.y = maxCount * sizeY;
        contentsTrans.sizeDelta = size;
    }


    void OnClick(MasterData.GachaTopData data)
    {
        Reset();

        gameObject.SetActive(false);
        GachaManager.OpenGachaItemList(data);
    }
}
