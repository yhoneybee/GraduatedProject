using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MySql.Data.MySqlClient;

namespace SERVER
{
    public class MySQL : SQL, IDisposable
    {
        readonly string server = "Server=127.0.0.1;";
        readonly string port = "Port=3306;";
        readonly string db = "Database=db;";
        readonly string id = "Uid=yhoney;";
        readonly string pw = "Pwd=gjslb22;";

        MySqlConnection connection;

        public override SQL CreateRoom()
        {
            return this;
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
            GC.SuppressFinalize(this);
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
                using MySqlCommand cmd1 = new MySqlCommand(new Query().Select("id", "useraccount", $"id = '{id}' AND pw = sha2('{pw}', 256)"), connection);
                using MySqlDataReader table = cmd1.ExecuteReader();
                if (table.HasRows) Call(CallbackType.LoginSuccess);
                else Call(CallbackType.LoginFail);
                table.Close();

                using MySqlCommand cmd2 = new MySqlCommand(new Query().Insert("userinfo", $"'{id}'"), connection);
                cmd2.ExecuteNonQuery();

                K.loginedId = id;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Call(CallbackType.LoginFail);
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
                    Call(CallbackType.SignFail);
                    return this;
                }
                MySqlCommand cmd = new MySqlCommand(new Query().Insert("useraccount", $"'{id}', sha2('{pw}', 256)"), connection);
                if (cmd.ExecuteNonQuery() == 1) Call(CallbackType.SignSuccess);
                else Call(CallbackType.SignFail);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Call(CallbackType.SignFail);
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

            static readonly string selectQuery = "SELECT <COLUMNS> FROM <TABLES> [WHERE];";
            static readonly string deleteQuery = "DELETE FROM <TABLES> [WHERE];";
            static readonly string updateQuery = "UPDATE <TABLES> SET [CHANGE] [WHERE];";
            static readonly string insertQuery = "INSERT INTO <TABLES> [COLUMNS] [VALUES];";

            public string Select(string columns, string tables, string where = "")
            {
                query = selectQuery;
                query = query.Replace("<COLUMNS>", columns);
                query = query.Replace("<TABLES>", tables);

                if (where == "") query = query.Replace("[WHERE]", $"");
                else query = query.Replace("[WHERE]", $"WHERE {where}");

                return query;
            }

            public string Delete(string tables, string where = "")
            {
                query = deleteQuery;
                query = query.Replace("<TABLES>", tables);

                if (where == "") query = query.Replace("[WHERE]", $"");
                else query = query.Replace("[WHERE]", $"WHERE {where}");

                return query;
            }

            public string Update(string tables, string change, string where = "")
            {
                query = updateQuery;
                query = query.Replace("<TABLES>", tables);
                query = query.Replace("[CHANGE]", change);

                if (where == "") query = query.Replace("[WHERE]", $"");
                else query = query.Replace("[WHERE]", $"WHERE {where}");

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
