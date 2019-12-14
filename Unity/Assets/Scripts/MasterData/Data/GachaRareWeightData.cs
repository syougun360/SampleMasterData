using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class GachaRareWeightData
    {
        [SerializeField]
        int id;
        public int ID { get {return id; } set { id = value;} }
        
        [SerializeField]
        int topid;
        public int Topid { get {return topid; } set { topid = value;} }
        
        [SerializeField]
        int groupid;
        public int Groupid { get {return groupid; } set { groupid = value;} }
        
        [SerializeField]
        float weight;
        public float Weight { get {return weight; } set { weight = value;} }
        
    }
}