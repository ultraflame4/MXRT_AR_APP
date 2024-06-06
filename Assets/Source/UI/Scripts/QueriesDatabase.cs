using System.Collections.Generic;
using UnityEngine;

public class QueriesDatabase : MonoBehaviour {
    public class Query {
        public string name;
        public string desc;
        public string type;
        
        public Query(string name, string desc, string type) {
            this.name = name;
            this.desc = desc;
            this.type = type;
        }
    }


    public List<Query> queries = new List<Query>();

}