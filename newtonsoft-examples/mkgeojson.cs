using System;
using System.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
//using System.Text.Json;
//using System.Text.Json.Serialization;

class Mkgeojson
{
    public class Rootobject
    {
        public string type { get; set; }
        public Feature[] features { get; set; }
    }
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
    }
    public class Geometry
    {
        public string type { get; set; }
        public double[][] coordinates { get; set; }
    }
}

class Program
{

    static void Main()
    {
        Mkgeojson.Geometry sample = new Mkgeojson.Geometry
        {
            type = "LineString",
            coordinates = new double[][] {
                new double[] {1.1, 1.2},
                new double[] {2.2, 10.2}
            }
        };
        // string json = JsonConvert.SerializeObject(sample, Formatting.Indented);
        // Console.WriteLine(json);

        Mkgeojson.Rootobject samples = new Mkgeojson.Rootobject
        {
            type = "FeatureCollection",
            // featuresはMkgeojson.Featureの配列
            features = new Mkgeojson.Feature[] {
                // １つ目のFeatureインスタンス
                new Mkgeojson.Feature{
                    type = "Feature",
                    geometry = new Mkgeojson.Geometry {
                        type = "LineString",
                        coordinates = new double[][] {
                            new double[] {111, 10.1},
                            new double[] {141.063, 42.845}
                        }
                    }
                },
                // ２つ目のFeatureインスタンス
                new Mkgeojson.Feature{
                    type = "Feature",
                    geometry = new Mkgeojson.Geometry {
                        type = "LineString",
                        coordinates = new double[][] {
                            new double[] {222.2, 20.2},
                            new double[] {141.063, 42.845}
                        }
                    }
                },
                // ３つ目のFeatureインスタンス
                new Mkgeojson.Feature{
                    type = "Feature",
                    geometry = sample  //上で定義した Geometoryクラスのsampleインスタンスを使ってみる
                }
            }
        };
        
        string json = JsonConvert.SerializeObject(samples, Formatting.Indented);
        Console.WriteLine(json);
    }
}