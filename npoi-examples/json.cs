using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{

    static void Main()
    {
        // Dictionaryを生成します。
        var dic = new Dictionary<string,bool>()
        {
            { "Tokyo"   ,true},
            { "Osaka"   ,false},
            { "Nagoya"  ,true},
            { "Fukuoka" ,false}
        };
 
        // Dictionaryをシリアライズします。
        var jsonstr = JsonSerializer.Serialize(dic);
        System.Diagnostics.Debug.Print("{0}", jsonstr);
        Console.WriteLine("{0}", jsonstr);
    }
    
}