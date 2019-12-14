using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class GachaItemData
    {
        [SerializeField]
        int id;
        public int Id { get {return id; } set { id = value;} }
        
        [SerializeField]
        int top_id;
        public int Top_Id { get {return top_id; } set { top_id = value;} }
        
        [SerializeField]
        int character_id;
        public int Character_Id { get {return character_id; } set { character_id = value;} }
        
    }
}