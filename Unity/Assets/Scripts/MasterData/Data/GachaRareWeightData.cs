using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class GachaRareWeightData
    {
        [SerializeField]
        int id;
        public int Id { get {return id; } set { id = value;} }
        
        [SerializeField]
        int top_id;
        public int Top_Id { get {return top_id; } set { top_id = value;} }
        
        [SerializeField]
        int rare;
        public int Rare { get {return rare; } set { rare = value;} }
        
        [SerializeField]
        int weight;
        public int Weight { get {return weight; } set { weight = value;} }
        
    }
}