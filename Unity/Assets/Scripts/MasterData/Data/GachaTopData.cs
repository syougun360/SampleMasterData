using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class GachaTopData
    {
        [SerializeField]
        int id;
        public int Id { get {return id; } set { id = value;} }
        
        [SerializeField]
        string name;
        public string Name { get {return name; } set { name = value;} }
        
        [SerializeField]
        long opend_at;
        public long Opend_At { get {return opend_at; } set { opend_at = value;} }
        
        [SerializeField]
        long closed_at;
        public long Closed_At { get {return closed_at; } set { closed_at = value;} }
        
    }
}