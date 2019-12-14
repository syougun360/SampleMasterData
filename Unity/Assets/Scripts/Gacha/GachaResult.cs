using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaResult : MonoBehaviour
{
    [SerializeField]
    Text nameText = null;

    [SerializeField]
    Text rareText = null;

    [SerializeField]
    Text hpText = null;

    [SerializeField]
    Text powerText = null;

    [SerializeField]
    Button closeButton = null;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        closeButton.onClick.AddListener(() =>
        {
            GachaManager.OpenGachaTop();
            gameObject.SetActive(false);
        });
    }

    public void Open(MasterData.CharacterData data)
    {
        gameObject.SetActive(true);

        nameText.text = data.Name;
        rareText.text = "★" + data.Rare.ToString();
        hpText.text = data.HP.ToString();
        powerText.text = data.Power.ToString();
    }
}
