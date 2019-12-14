using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class GachaItemData
    {
        [SerializeField]
        int id;
        public int ID { get {return id; } set { id = value;} }
        
        [SerializeField]
        int topid;
        public int Topid { get {return topid; } set { topid = value;} }
        
        [SerializeField]
        int characterid;
        public int Characterid { get {return characterid; } set { characterid = value;} }
        
        [SerializeField]
        int groupid;
        public int Groupid { get {return groupid; } set { groupid = value;} }
        
    }
}