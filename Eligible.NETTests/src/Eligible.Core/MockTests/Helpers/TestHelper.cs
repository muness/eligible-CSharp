using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace EligibleService.Core.Tests
{
    public class TestHelper
    {
        public static void PropertyValuesAreEquals(object actual, object expected)
        {
            PropertyInfo[] properties = expected.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object expectedValue = property.GetValue(expected, null);
                object actualValue = property.GetValue(actual, null);

                if (actualValue is IList)
                    AssertListsAreEquals(property, (IList)actualValue, (IList)expectedValue);
                else if (actualValue != null)
                {
                    if ((!Equals(expectedValue.GetType(), actualValue.GetType())))
                    {
                        if (actualValue is object)
                            PropertyValuesAreEquals(actualValue, expectedValue);
                        else
                            Assert.Fail("Property {0}.{1} does not match. Expected: {2} but was: {3}", property.DeclaringType.Name, property.Name, expectedValue, actualValue);
                    }
                }
            }
        }

        private static void AssertListsAreEquals(PropertyInfo property, IList actualList, IList expectedList)
        {
            if(actualList.Count > 0)
            {
                if (!Equals(actualList[0].GetType(), expectedList[0].GetType()))
                {
                    if (actualList[0] is object)
                        PropertyValuesAreEquals(actualList[0], expectedList[0]);
                    else
                        Assert.Fail("Property {0}.{1} does not match. Expected IList with element {1} equals to {2} but was IList with element {1} equals to {3}", property.PropertyType.Name, property.Name, expectedList[0], actualList[0]);

                }
            }
        }

        public static string GetJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                return r.ReadToEnd();
            }
        }
        public static void CompareProperties(string expectedObj, string actualObj)
        {
            if (actualObj.ToString().StartsWith("["))
            {
                Collection<dynamic> expected = JsonConvert.DeserializeObject<Collection<dynamic>>(expectedObj);
                Collection<dynamic> actual = JsonConvert.DeserializeObject<Collection<dynamic>>(actualObj);
                CheckKeys(expected[0].ToString(), actual[0].ToString());
            }
            else
                CheckKeys(expectedObj, actualObj);
        }

        public static void PropertiesAreEqual(object expectedObj, string actualObj)
        {
            if (actualObj.ToString().StartsWith("["))
            {
                Collection<dynamic> expected = JsonConvert.DeserializeObject<Collection<dynamic>>(JsonConvert.SerializeObject(expectedObj));
                Collection<dynamic> actual = JsonConvert.DeserializeObject<Collection<dynamic>>(actualObj);

                if (expected.Count != actual.Count)
                    Assert.Fail("Mismatch in json properties. Expeced {0} properties but got {1}", expected.Count, actual.Count);
                else
                    for (int i = 0; i < actual.Count; i++)
                    {
                        CheckKeys(expected[i].ToString(), actual[i].ToString());
                    }
            }
            else
                CheckKeys(JsonConvert.SerializeObject(expectedObj), actualObj.ToString());         
        }

        public static void CheckKeys(string expectedJson, string actualJson)
        {
            Hashtable actual = JsonConvert.DeserializeObject<Hashtable>(actualJson);
            Hashtable expected = JsonConvert.DeserializeObject<Hashtable>(expectedJson);

            Assert.AreEqual(expected.GetType(), actual.GetType(), expected.ToString() + " has invalid type" );

            if(expected.Count != actual.Count)
                Assert.Fail("Mismatch in json properties. Expeced {0} properties but got {1}", expected.Count, actual.Count);
            else
            foreach(string key in actual.Keys)
            {
                Assert.IsTrue(expected.ContainsKey(key), "Miss match in property  " + key);
                
                if (actual[key] != null && actual[key].ToString().StartsWith("{"))
                {
                    if (actual[key].ToString().StartsWith("["))
                    {
                        IList listActual = (IList)actual[key];
                        IList listExpected = (IList)expected[key];
                        for (int i = 0; i < listActual.Count; i++)
                        {
                            CheckKeys(listExpected[i].ToString(), listActual[i].ToString());
                        }
                    }
                    else
                        CheckKeys(JsonConvert.SerializeObject(expected[key]), JsonConvert.SerializeObject(actual[key]));
                }

                if (actual[key] != null)
                {
                    var actualValu = actual[key];
                    if(expected[key].GetType() == typeof(double))
                    { 
                        double actValue;
                        bool actResult = double.TryParse(actualValu.ToString(), out actValue);
                        if (!actResult)
                            Assert.Fail("Actual json has some invalid type. Expected Doubel for " + key);

                        actualValu = actValue;
                    }
                    else if (expected[key].GetType() == typeof(bool))
                    {
                        bool actValue;
                        bool actResult = bool.TryParse(actualValu.ToString(), out actValue);
                        if (!actResult)
                            Assert.Fail("Actual json has some invalid type. Expected boolean for " + key);

                        actualValu = actValue;
                    }
                    else
                        Assert.AreEqual(expected[key].GetType(), actualValu.GetType(), key + " has invalid type");
                }
            }
        }
    }
}
