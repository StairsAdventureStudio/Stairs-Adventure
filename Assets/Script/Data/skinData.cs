using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class skinData : ScriptableObject {


    public skins[] skin;

    [System.Serializable]
    public class skins
    {
        public Color colors;
        public Sprite sprites;
        public string opis;
        public int testIndex;
        public int testValue;

    }

}

