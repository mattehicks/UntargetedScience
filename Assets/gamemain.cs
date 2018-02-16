using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

using MySql.Data;
using MySql.Data.MySqlClient;

public class gamemain : MonoBehaviour {

	public string host, database, user, password;
	private string connectionString;
	private MySqlConnection con = null;
	private MySqlCommand cmd = null;
	private MySqlDataReader rdr = null;

	public bool pooling = true;

	// Updates once per frame
	void Update() {
		//Debug.Log("Main update...");

	}

	void Start() {

		Debug.Log("Start Main.");


		SetupSQLConnection(); 
		Debug.Log("testing connection...");

		//TestDB(); 
		//Debug.Log("testing 2...");

		CloseSQLConnection(); 
		Debug.Log("testing 3...");

	}


	void SelectDataType(){
		//return either CSV or SQL data source type

	}

	void SelectDatabase(){
		//return Database connection

	}


	void SelectTable(){
		//Dropdown returns the name of a table from the dropdown list
		//begin column name parsing into 'table_select' child dropdown
	}
		


	void CreateDataArray(){ 
		// query table.column name
		// limit results to 50 - 100 -1000
		// store integers in the grid array Y values
		// 
	}

	private void SetupSQLConnection() { 
		if (con == null) { 
			host = "34.217.182.230";
			database = "coins";
			user = "unity";
			password = "unity";

			Debug.Log("testing connection...");
//			connectionString = "Server="+host+";Database="+database+";Uid="+user+";Pwd="+password+";Pooling="; 
//			if (pooling) {
//				connectionString += "true;";
//			} else {
//				connectionString += "false";
//			}
				
			//connectionString = "Server=34.217.182.230;" + "Database=coins;" + "Uid=unity;" + "pwd=unity;";
			connectionString= "Database=coins;Data Source=34.217.182.230;User Id=unity;Password=unity";

			try { 
				con = new MySqlConnection(connectionString); 
				//con.Open();
				Debug.Log("MySQL State:" + con.State);

				string myquery = "select DISTINCT(coin) from coins limit 100";
				string myquery2 = "INSERT into test (testcol) Values('hello')";

				MySqlCommand command = new MySqlCommand(myquery);
				command.Connection = con;
				con.Open();
				command.ExecuteNonQuery();
				//command.CommandText = "select DISTINCT(coin) from coins limit 100";

				MySqlDataReader datareader = command.ExecuteReader();

				//command.Connection = con;
				//command.ExecuteNonQuery();

				List<int> list = new List<int>();
				while(datareader.Read())
				{
					Debug.Log("Coin: " + datareader["coin"].ToString());

					//int item = (int)datareader["coin"];
					//list.Add(item);
				}

				list.ForEach(i => Debug.Log(i.ToString()));

				command.Connection.Close();

			} catch (MySqlException ex) { 
				Debug.Log("MySQL Error: " + ex.ToString()); 
			} 




		} 
	} 



	private void CloseSQLConnection() { 
		if (con != null) { 
			con.Close(); 
		} 
	} 

	public void TestDB() { 
		//string commandText = string.Format("INSERT INTO scores (playername, playerscore) VALUES ({0}, {1})", "'megaplayer'", 10); 
		string commandText = string.Format("select DISTINCT(coin) from coins limit 100");
		if (con != null) { 
			MySqlCommand command = new MySqlCommand("select DISTINCT(coin) from coins limit 100", con);
			Debug.Log ("TestDB Connection...");
			//MySqlCommand command = connection.CreateCommand(); 
			//command.CommandText = commandText; 
			try { 
				command.ExecuteReader(); 
			} catch (System.Exception ex) { 
				Debug.LogError("MySQL error: " + ex.ToString()); 
			} 
		} 
	} 
		
}
