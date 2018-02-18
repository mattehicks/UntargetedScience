using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

using MySql.Data;
using MySql.Data.MySqlClient;

public class gamemain : MonoBehaviour {

	Dropdown db_dropdown;
	Dropdown table_dropdown;
	Dropdown x_dropdown;
	Dropdown y_dropdown;

	public string mydatabase = "coins";
	public string tablename = "coins";
	public string host = "34.217.182.230";

	public string connectionString= "Database=coins;Data Source=34.217.182.230;User Id=unity;Password=unity";

	private MySqlConnection con = null;
	public string myquery = "";

	private List<string> data;


	public bool pooling = true;

	// Updates once per frame
	void Update() {
		//Debug.Log("Main update...");

	}

	void Start() {
		 db_dropdown = GameObject.Find("db_dropdown").GetComponent<Dropdown>();
		 table_dropdown = GameObject.Find("table_dropdown").GetComponent<Dropdown>();
		 x_dropdown = GameObject.Find("x_dropdown").GetComponent<Dropdown>();
		 y_dropdown = GameObject.Find("y_dropdown").GetComponent<Dropdown>();


		Debug.Log("Start Main.");

		StartSQLConnection(mydatabase); 
		Debug.Log("testing connection...");

		//TestDB(); 
		//Debug.Log("testing 2...");

		CloseSQLConnection(); 
		Debug.Log("testing 3...");


		//data = LoadDataFromDBOrJSON(); // Or whatever way you will read your data in

	}


	void SelectDataType(){
		//return either CSV or SQL data source type

	}


	void getDatabases(){


		//return databases & fill dropdown
	}

	void getTables(){
		myquery = "SELECT table_name FROM information_schema.tables where table_schema='coins';";
	
		MySqlCommand command = new MySqlCommand(myquery);
		command.Connection = con;

		try{
			con.Open();
		} 
		catch (MySqlException ex) { 
			Debug.Log("MySQL Error: " + ex.ToString()); 
			return;
		} 

		command.ExecuteNonQuery();

		MySqlDataReader datareader = command.ExecuteReader();

		table_dropdown.options.Clear();
		string item = null;
		while(datareader.Read())
		{
			//Debug.Log("Coin: " + datareader["coin"]);
			Debug.Log("Populating dropdown");
			item = datareader["table_name"].ToString();
			table_dropdown.options.Add(new Dropdown.OptionData(item));
		}

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
		// store list for reference


	}

	private List<string> StartSQLConnection(string mydatabase) { 
		//auto connect and fill table names 

		if (con == null) { 
			Debug.Log("testing connection...");
			List<string> Myresult = new List<string>();

			try { 
				con = new MySqlConnection(connectionString); 
				Debug.Log("MySQL State:" + con.State);

				string myquery = "SELECT table_name FROM information_schema.tables where table_schema='"+mydatabase+"';";
				Debug.Log("query: " + myquery);

				MySqlCommand command = new MySqlCommand(myquery);
				command.Connection = con;
				con.Open();
				command.ExecuteNonQuery();

				MySqlDataReader datareader = command.ExecuteReader();

				table_dropdown.options.Clear();

				string item = null;
				while(datareader.Read())
				{
					Debug.Log("Autofilling table names");
					item = datareader["table_name"].ToString();
					Myresult.Add(item);
				}

				Debug.Log("mysql opened successfully");
				command.Connection.Close();


			} catch (MySqlException ex) { 
				Debug.Log("MySQL Error: " + ex.ToString()); 
			} 

			return Myresult;
		} 
		return null;
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
