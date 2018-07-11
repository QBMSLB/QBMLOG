using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBM_LOGConsole
{
    class reviseClass
    {
        private int i = 0;
        private int j = 0;
        //private string 
        Hashtable x = new Hashtable();
        public reviseClass(DataSet dataset,string[] input) 
        {
            foreach (DataColumn item in dataset.Tables[0].Columns)
            {
                if (i<input.Length)
                {
                    x.Add(item.ColumnName, input[i++]);
                }
                
                                
            }            
        }
        public Hashtable getHashtable()
        {
            return x;
        }

        public string[] getKeys()
        {
            string[] keys = new string[x.Count];
            foreach (string key in x.Keys)
            {
                keys[j++] = key;
            }
            return keys;
        }
        public string[] getValues()
        {
            string[] values = new string[x.Count];
            foreach (string value  in x.Values)
            {
                values[i++] = x.Values.ToString();
            }
            return values;
        }
    }
}
