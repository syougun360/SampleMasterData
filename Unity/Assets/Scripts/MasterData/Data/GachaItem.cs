using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MasterData
{
    [System.Serializable]
    public class GachaItem : ScriptableObject 
    {
        [HideInInspector] [SerializeField] 
        public string SheetName = "";
    
        [HideInInspector] [SerializeField] 
        public string WorksheetName = "";
    
        // Note: initialize in OnEnable() not here.
        public GachaItemData[] dataArray;
    
        void OnEnable()
        {
            if (dataArray == null)
                dataArray = new GachaItemData[0];
        }
    }
}