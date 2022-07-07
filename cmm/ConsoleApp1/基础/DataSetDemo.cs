using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleApp1.基础
{
    class DataSetDemo
    {

        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            DataColumn dcId = new DataColumn();
            dcId.AutoIncrement = true;
            dcId.AutoIncrementSeed = 1;
            dcId.AutoIncrementStep = 1;
            dt.Columns.Add(dcId);

            DataColumn cdName = new DataColumn("name", typeof(string));
            dt.Columns.Add(cdName);

            dt.Columns.Add("password", typeof(string));

            DataRow row = dt.NewRow();
            row["name"] = "tian";
            row["password"] = "123456";
            dt.Rows.Add(row);

            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "LS" + i.ToString();
                dr["password"] = "456" + i.ToString();
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow rows in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        Console.Write(rows[i] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
