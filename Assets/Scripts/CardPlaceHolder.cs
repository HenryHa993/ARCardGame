using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

namespace CardDataStorage
{
    //Creates card data in Unity
    [CreateAssetMenu (fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public CardType cardType;

        public int health;
        public int attack;

        public enum CardType
        {
            Rock,

            Paper,

            Sissor
        }
    }
}
