using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MySql.Data.MySqlClient;

namespace SERVER
{
    public class MySQL : SQL
    {
        readonly string server = "Server=localhost;";
        readonly string port = "Port=3306;";
        readonly string db = "Database=db;";
        readonly string id = "Uid=root;";
        readonly string pw = "Pwd=Rnfqjf2671!@#;";

        MySqlConnection connection;

        public override SQL CreateRoom()
        {
            return this;
        }

        public override SQL EnterRoom()
        {
            return this;
        }

        public override SQL Initilize()
        {
            connection = new MySqlConnection($"{server}{port}{db}{id}{pw}");
            connection.Open();
            return this;
        }

        public override SQL Login(string id, string pw)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(new Query().Select(Query.OPTION.ALL, "id", "user", ""), connection);
                if (cmd.ExecuteNonQuery() == 1) onLoginSuccess();
                else onLoginFail();
            }
            catch
            {
                onLoginFail();
            }
            return this;
        }

        public override SQL Logout()
        {
            return this;
        }

        public override SQL QuitRoom()
        {
            return this;
        }

        public override SQL Sign(string id, string pw, string pw2)
        {
            try
            {
                if (pw != pw2)
                {
                    onSignFail();
                    return this;
                }
                MySqlCommand cmd = new MySqlCommand(new Query().Insert("userinfo", $"'{id}', md5('{pw}')"), connection);
                if (cmd.ExecuteNonQuery() == 1) onSignSuccess();
                else onSignFail();
            }
            catch
            {
                onSignFail();
            }
            return this;
        }

        public struct Query
        {
            public enum OPTION
            {
                ALL,
                DISTINCT,
            }

            public string query { get; private set; }

            static readonly string selectQuery = "SELECT [OPTION] <COLUMNS> FROM <TABLES> [WHERE];";
            static readonly string deleteQuery = "DELETE FROM <TABLES> [WHERE];";
            static readonly string updateQuery = "UPDATE <TABLES> SET [CHANGE] [WHERE];";
            static readonly string insertQuery = "INSERT INTO <TABLES> [COLUMNS] [VALUES];";

            public string Select(OPTION option, string columns, string tables, string where = "")
            {
                query = selectQuery;
                query = query.Replace("[OPTION]", option.ToString());
                query = query.Replace("<COLUMNS>", columns);
                query = query.Replace("<TABLES>", tables);
                query = query.Replace("[WHERE]", $"WHERE {where}");
                return query;
            }

            public string Delete(string tables, string where = "")
            {
                query = deleteQuery;
                query = query.Replace("<TABLES>", tables);
                query = query.Replace("[WHERE]", $"WHERE {where}");
                return query;
            }

            public string Update(string tables, string change, string where = "")
            {
                query = updateQuery;
                query = query.Replace("<TABLES>", tables);
                query = query.Replace("[CHANGE]", change);
                query = query.Replace("[WHERE]", $"WHERE {where}");
                return query;
            }

            public string Insert(string tables, string values)
            {
                query = insertQuery;
                query = query.Replace("<TABLES>", tables);
                query = query.Replace("[COLUMNS]", "");
                query = query.Replace("[VALUES]", $"VALUES({values})");
                return query;
            }
            public string Insert(string tables, string columns, string values)
            {
                query = insertQuery;
                query = query.Replace("<TABLES>", tables);
                query = query.Replace("[COLUMNS]", $"({columns})");
                query = query.Replace("[VALUES]", $"VALUES({values})");
                return query;
            }
        }
    }
}
