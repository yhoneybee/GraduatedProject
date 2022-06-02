using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MySql.Data.MySqlClient;

namespace SERVER
{
    public class MySQL : SQL, IDisposable
    {
        readonly string server = "Server=119.196.245.41;";
        readonly string port = "Port=3306;";
        readonly string db = "Database=db;";
        readonly string id = "Uid=yhoney;";
        readonly string pw = "Pwd=gjslb22;";

        MySqlConnection connection;

        public override SQL GetAllRoom(out List<RoomData> roomData)
        {
            roomData = null;

            try
            {
                using MySqlCommand selectRoomInfo = new MySqlCommand(new Query().Select("*", "roominfo"), connection);
                using MySqlDataReader roomInfoTable = selectRoomInfo.ExecuteReader();

                if (roomInfoTable == null)
                {
                    Call(CallbackType.GetAllRoomFail);
                    return this;
                }

                roomData = new List<RoomData>();

                while (roomInfoTable.Read())
                {
                    roomData.Add(new RoomData { name = roomInfoTable["name"].ToString(), player1 = roomInfoTable["player1"].ToString(), player2 = roomInfoTable["player2"].ToString() });
                }

                roomInfoTable.Close();

                Call(CallbackType.GetAllRoomSuccess);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Call(CallbackType.GetAllRoomFail);
            }

            return this;
        }

        public override SQL CreateRoom(string roomName = "")
        {
            try
            {
                if (roomName == "")
                {
                    using MySqlCommand selectRoomInfo = new MySqlCommand(new Query().Select("COUNT(*)", "roominfo"), connection);
                    roomName = $"{Convert.ToInt32(selectRoomInfo.ExecuteScalar()) + 1} Room by {K.loginedId}";
                }
                else
                {
                    using MySqlCommand selectRoomInfo = new MySqlCommand(new Query().Select("name, player1, player2", "roominfo", $"name = '{roomName}'"), connection);
                    using MySqlDataReader roomInfoTable = selectRoomInfo.ExecuteReader();
                    if (roomInfoTable.HasRows)
                    {
                        roomInfoTable.Close();
                        Call(CallbackType.CreateRoomFail);
                        return this;
                    }
                    roomInfoTable.Close();
                }

                using MySqlCommand insertRoomInfo = new MySqlCommand(new Query().Insert("roominfo", "name, player1", $"'{roomName}', '{K.loginedId}'"), connection);
                if (insertRoomInfo.ExecuteNonQuery() != 1)
                {
                    Call(CallbackType.CreateRoomFail);
                    return this;
                }

                Call(CallbackType.CreateRoomSuccess);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Call(CallbackType.CreateRoomFail);
            }

            return this;
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
            GC.SuppressFinalize(this);
        }

        public override SQL EnterRoom(string roomName)
        {
            try
            {
                using MySqlCommand selectRoomInfo = new MySqlCommand(new Query().Select("name, player1, player2", "roominfo", $"name = '{roomName}'"), connection);
                using MySqlDataReader roomInfoTable = selectRoomInfo.ExecuteReader();
                if (!roomInfoTable.HasRows)
                {
                    roomInfoTable.Close();
                    Call(CallbackType.EnterRoomFail);
                    return this;
                }

                roomInfoTable.Read();
                string player1 = roomInfoTable["player1"].ToString();
                string player2 = roomInfoTable["player2"].ToString();

                roomInfoTable.Close();

                string updatePlayerColumnsName = string.Empty;

                if (player1 == string.Empty)
                {
                    updatePlayerColumnsName = "player1";
                }
                else if (player2 == string.Empty)
                {
                    updatePlayerColumnsName = "player2";
                }
                else
                {
                    Call(CallbackType.EnterRoomFail);
                    return this;
                }

                using MySqlCommand updateRoomInfo = new MySqlCommand(new Query().Update("roominfo", $"{updatePlayerColumnsName} = {K.loginedId}", $"name = '{roomName}'"), connection);
                if (updateRoomInfo.ExecuteNonQuery() != 1)
                {
                    Call(CallbackType.EnterRoomFail);
                    return this;
                }

                Call(CallbackType.EnterRoomSuccess);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Call(CallbackType.EnterRoomFail);
            }

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
                using MySqlCommand selectUserAccount = new MySqlCommand(new Query().Select("id", "useraccount", $"id = '{id}' AND pw = sha2('{pw}', 256)"), connection);
                using MySqlDataReader userAccoutTable = selectUserAccount.ExecuteReader();
                if (!userAccoutTable.HasRows)
                {
                    userAccoutTable.Close();
                    Call(CallbackType.LoginFail);
                    return this;
                }
                userAccoutTable.Close();

                Call(CallbackType.LoginSuccess);
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

        public override SQL QuitRoom(string roomName)
        {
            try
            {
                using MySqlCommand selectRoomInfo = new MySqlCommand(new Query().Select("name, player1, player2", "roominfo", $"name = '{roomName}'"), connection);
                using MySqlDataReader roomInfoTable = selectRoomInfo.ExecuteReader();
                if (!roomInfoTable.HasRows)
                {
                    roomInfoTable.Close();
                    Call(CallbackType.EnterRoomFail);
                    return this;
                }

                roomInfoTable.Read();
                string player1 = roomInfoTable["player1"].ToString();
                string player2 = roomInfoTable["player2"].ToString();
                roomInfoTable.Close();

                string updatePlayerColumnsName = string.Empty;

                if (player1 == K.loginedId)
                {
                    updatePlayerColumnsName = "player1";
                    player1 = string.Empty;
                }
                else if (player2 == K.loginedId)
                {
                    updatePlayerColumnsName = "player2";
                    player2 = string.Empty;
                }
                else
                {
                    Call(CallbackType.QuitRoomFail);
                    return this;
                }

                using MySqlCommand updateRoomInfo = new MySqlCommand(new Query().Update("roominfo", $"{updatePlayerColumnsName} = NULL", $"name = '{roomName}'"), connection);
                if (updateRoomInfo.ExecuteNonQuery() != 1)
                {
                    Call(CallbackType.QuitRoomFail);
                    return this;
                }

                if (player1 == player2 && player1 == string.Empty)
                {
                    using MySqlCommand deleteRoomInfo = new MySqlCommand(new Query().Delete("roominfo", $"name = '{roomName}'"), connection);
                    if (deleteRoomInfo.ExecuteNonQuery() != 1)
                    {
                        Call(CallbackType.QuitRoomFail);
                        return this;
                    }
                }

                Call(CallbackType.QuitRoomSuccess);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Call(CallbackType.QuitRoomFail);
            }

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
                using MySqlCommand insertUserAccount = new MySqlCommand(new Query().Insert("useraccount", $"'{id}', sha2('{pw}', 256)"), connection);
                if (insertUserAccount.ExecuteNonQuery() != 1) Call(CallbackType.SignFail);

                using MySqlCommand selectUserInfo = new MySqlCommand(new Query().Select("id", "userinfo", $"id = '{id}'"), connection);
                using MySqlDataReader userInfoTable = selectUserInfo.ExecuteReader();
                if (!userInfoTable.HasRows)
                {
                    userInfoTable.Close();
                    using MySqlCommand insertUserInfo = new MySqlCommand(new Query().Insert("userinfo", $"'{id}', 0, 0, 0"), connection);
                    insertUserInfo.ExecuteNonQuery();
                }
                userInfoTable.Close();

                Call(CallbackType.SignSuccess);
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
