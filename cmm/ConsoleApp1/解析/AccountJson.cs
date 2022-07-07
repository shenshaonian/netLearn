using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.解析
{
    /// <summary>
    /// using Newtonsoft.Json;
    /// </summary>

    class AccountJson
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }

        static void Main(string[] args)
        {
            // demoAccountJson();
            //CollectionJson();
            //DictionaryJson();
            //SJson2File();
            //SJsonwithsonConverters();
            //SDataSetJson();
            //SRawJson();
            //SUnindentedJson();

            // DObjectJson();
            //DCollectionJson();
            //DDictionaryJson();
            //DAnAnonymousTypeJson();
            DDataSetJson();
        }

        #region object2json-demoAccountJson()
        public static void demoAccountJson()
        {
            AccountJson account = new AccountJson
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                    "User",
                    "Admin"
                }
            };

            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            // {
            //   "Email": "james@example.com",
            //   "Active": true,
            //   "CreatedDate": "2013-01-20T00:00:00Z",
            //   "Roles": [
            //     "User",
            //     "Admin"
            //   ]
            // }

            Console.WriteLine(json);
        }

        #endregion
        #region Serialize a Collection
        public static void CollectionJson()
        {
            List<string> videogames = new List<string>
            {
                 "Starcraft",
                 "Halo",
                 "Legend of Zelda"
            };
            string json = JsonConvert.SerializeObject(videogames);
            string json1 = JsonConvert.SerializeObject(videogames, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine(json1);
        }
        #endregion
        #region  Serialize a Dictionary

        public static void DictionaryJson()
        {
            Dictionary<string, int> points = new Dictionary<string, int>
            {
                 { "James", 9001 },
                 { "Jo", 3474 },
                 { "Jess", 11926 }
             };
            string json = JsonConvert.SerializeObject(points, Formatting.Indented);
            Console.WriteLine(json);
        }


        #endregion
        #region Serialize JSON to a file Serialize JSON to a file
        // jsonSerializer.Serialize(file, movie); 反序列化 得时候, 权限问题报错,目前么有从王珊刚找到和
        public static void SJson2File()
        {
            Movie movie = new Movie
            {
                Name = "fzq",
                Year = 26
            };
            File.WriteAllText(@"C:\Users\HB\Desktop\Fzq\test\movie.json", JsonConvert.SerializeObject(movie));
            try
            {
                using StreamWriter file = File.CreateText(@"C:\Users\HB\Desktop\Fzq\test\movie.json");
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, movie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace+"  --" + e.Message);
            }
            Console.WriteLine(movie.Year);
        }

        class Movie
        {
            public string Name { get; set; }
            public int Year { get; set; }
        }
        #endregion
        #region  Serialize with JsonConverters-SJsonwithsonConverters()
        public static void SJsonwithsonConverters()
        {
            List<StringComparison> stringComparisons = new List<StringComparison>
            {
                StringComparison.CurrentCulture,
                StringComparison.Ordinal
            };

            string jsonWithoutConverter = JsonConvert.SerializeObject(stringComparisons);

            Console.WriteLine(jsonWithoutConverter);
            // [0,4]

            string jsonWithConverter = JsonConvert.SerializeObject(stringComparisons, new StringEnumConverter());

            Console.WriteLine(jsonWithConverter);
            // ["CurrentCulture","Ordinal"]

            List<StringComparison> newStringComparsions = JsonConvert.DeserializeObject<List<StringComparison>>(
                jsonWithConverter,
                new StringEnumConverter());

            Console.WriteLine(string.Join(", ", newStringComparsions.Select(c => c.ToString()).ToArray()));
            // CurrentCulture, Ordinal
        }

        #endregion
        #region Serialize a DataSet-SDataSetJson()
        public static void SDataSetJson()
        {
            DataSet dataSet = new DataSet("dataSet");
            dataSet.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;

            DataColumn itemColumn = new DataColumn("item");
            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            dataSet.Tables.Add(table);

            for (int i = 0; i < 2; i++)
            {
                DataRow newRow = table.NewRow();
                newRow["item"] = "item " + i;
                table.Rows.Add(newRow);
            }

            dataSet.AcceptChanges();

            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            Console.WriteLine(json);
            // {
            //   "Table1": [
            //     {
            //       "id": 0,
            //       "item": "item 0"
            //     },
            //     {
            //       "id": 1,
            //       "item": "item 1"
            //     }
            //   ]
            // }
        }


        #endregion
        #region Serialize Raw JSON value JRaw-SRawJson()


        public static void SRawJson()
        {
            JavaScriptSettings settings = new JavaScriptSettings
            {
                OnLoadFunction = new JRaw("OnLoad"),
                OnUnloadFunction = new JRaw("function(e) { alert(e); }")
            };

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            Console.WriteLine(json);
            // {
            //   "OnLoadFunction": OnLoad,
            //   "OnUnloadFunction": function(e) { alert(e); }
            // }

        }

        public class JavaScriptSettings
        {
            public JRaw OnLoadFunction { get; set; }
            public JRaw OnUnloadFunction { get; set; }
        }
        #endregion
        #region Serialize Unindented JSON--SUnindentedJson()

        public static void SUnindentedJson()
        {
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
    {
        "User",
        "Admin"
    }
            };

            string json = JsonConvert.SerializeObject(account);
            string json1 = JsonConvert.SerializeObject(account,Formatting.Indented);
            // {"Email":"james@example.com","Active":true,"CreatedDate":"2013-01-20T00:00:00Z","Roles":["User","Admin"]}

            Console.WriteLine(json);
            Console.WriteLine(json1);

        }
        public class Account
        {
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public IList<string> Roles { get; set; }
        }
        #endregion
        #region Serialize Conditional Property--SConditionalPropertyJson()

        public static void SConditionalPropertyJson()
        {
            Employee joe = new Employee();
            joe.Name = "Joe Employee";
            Employee mike = new Employee();
            mike.Name = "Mike Manager";

            joe.Manager = mike;

            // mike is his own manager
            // ShouldSerialize will skip this property
            mike.Manager = mike;

            string json = JsonConvert.SerializeObject(new[] { joe, mike }, Formatting.Indented);

            Console.WriteLine(json);
            // [
            //   {
            //     "Name": "Joe Employee",
            //     "Manager": {
            //       "Name": "Mike Manager"
            //     }
            //   },
            //   {
            //     "Name": "Mike Manager"
            //   }
            // ]
        }
        public class Employee
        {
            public string Name { get; set; }
            public Employee Manager { get; set; }

            /// <summary>
            /// ShouldSerializeManager---> ShouldSerialize+Manager,ShouldSerialize+属性,如果返回true的时候则可以序列化.
            /// 条件性序列化
            /// </summary>
            /// <returns></returns>
            public bool ShouldSerializeManager()
            {
                // don't serialize the Manager property if an employee is their own manager
                return (Manager != this);
            }
        }

        #endregion
        /// <summary>
        /// 反序列化
        /// </summary>
        #region Deserialize an Object--DObjectJson()

        public static void DObjectJson()
        {
            string json = @"{
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User',
    'Admin'
  ]
}";

            AccountJson account = JsonConvert.DeserializeObject<AccountJson>(json);

            Console.WriteLine(account.Email);
            // james@example.com
        }

        #endregion
        #region Deserialize a Collection--DCollectionJson()

        public static void DCollectionJson()
        {
            string json = @"['Starcraft','Halo','Legend of Zelda']";

            List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);

            Console.WriteLine(string.Join(", ", videogames.ToArray()));
        }

        #endregion
        #region Deserialize a Dictionary-DDictionaryJson()

        public static void DDictionaryJson()
        {
            string json = @"{
  'href': '/account/login.aspx',
  'target': '_blank'
}";
            Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            Console.WriteLine(dictionary["href"]);
            Console.WriteLine(dictionary["target"]);


        }

        #endregion
        #region Deserialize an Anonymous Type---DAnAnonymousTypeJson--Anonymous 匿名的

        public static void DAnAnonymousTypeJson()
        {
            var definition = new { Name = "" };
            string json1 = @"{ 'Name':'James'}";
            var customer1 = JsonConvert.DeserializeAnonymousType(json1, definition);
            Console.WriteLine(customer1.Name);
        }

        #endregion

        #region Deserialize a DataSet--DDataSetJson()
        public static void DDataSetJson()
        {
            string json = @"{
             'Table1': [
                 {
                    'id': 0,
                      'item': 'item 0'
                 },
                {
                     'id': 1,
                     'item': 'item 1'
                 }
                    ]
                        }";

            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            DataTable dataTable = dataSet.Tables["Table1"];
            Console.WriteLine(dataTable.Rows.Count);

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["id"]+ " - " + row["item"]);
            }
        }
        #endregion

        #region Deserialize with CustomCreationConverter--
        public static void DCustomCreationConverterJson()
        {

        }
        #endregion

        #region 
        public static void demoJson()
        {

        }
        #endregion


    }



}
