using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class GachaTopData
    {
        [SerializeField]
        int id;
        public int ID { get {return id; } set { id = value;} }
        
        [SerializeField]
        string name;
        public string Name { get {return name; } set { name = value;} }
        
        [SerializeField]
        int drawpriority;
        public int Drawpriority { get {return drawpriority; } set { drawpriority = value;} }
        
        [SerializeField]
        long opendat;
        public long Opendat { get {return opendat; } set { opendat = value;} }
        
        [SerializeField]
        long closedat;
        public long Closedat { get {return closedat; } set { closedat = value;} }
        
    }
}