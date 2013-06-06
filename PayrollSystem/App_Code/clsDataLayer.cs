using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Using statements copied from Devry iLab page
using System.Data.OleDb;
using System.Net;
using System.Data;


public class clsDataLayer
{
    
    // This function verifies a user in the tblUser table
    public static dsUser VerifyUser(string Database, string UserName, string UserPassword)
    {
        // Add your comments here
        dsUser DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;

        // Add your comments here
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                                      "Data Source=" + Database);

        // Add your comments here
        sqlDA = new OleDbDataAdapter("Select SecurityLevel from tblUserLogin " +
                                      "where UserName like '" + UserName + "' " +
                                      "and UserPassword like '" + UserPassword + "'", sqlConn);

        // Add your comments here
        DS = new dsUser();

        // Add your comments here
        sqlDA.Fill(DS.tblUserLogin);

        // Add your comments here
        return DS;

    }

    //This function saves the user data
    public static bool SaveUser(string Database, string UserID, string UserPassword, string SecurityLevel)
    {
        bool userSaved;
        OleDbTransaction myTransaction = null;

        try
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Database);

            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;

            myTransaction = conn.BeginTransaction();
            command.Transaction = myTransaction;

            strSQL = "Insert into tblUserLogin " +
                     "(UserName, UserPassword, SecurityLevel) values ('" +
                     UserID + "', '" + UserPassword + "', '" + SecurityLevel + "')";

            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            command.ExecuteNonQuery();

            myTransaction.Commit();
            conn.Close();
            userSaved = true;
        }

        catch (Exception ex)
        {
            userSaved = false;
        }
        return userSaved;
    }
    
    // This function saves the personnel data
    public static bool SavePersonnel(string Database, string FirstName, string LastName,
    string PayRate, string StartDate, string EndDate)
    {
        bool recordSaved;
        OleDbTransaction myTransaction = null;

        try
        {
            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Database);
            
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;

            //create new transaction
            myTransaction = conn.BeginTransaction();
            command.Transaction = myTransaction;
            
            strSQL = "Insert into tblPersonnel " +
                     "(FirstName, LastName) values ('" +
                     FirstName + "', '" + LastName + "')";

            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            command.ExecuteNonQuery();

            strSQL = "Update tblPersonnel " +
                     "Set PayRate=" + PayRate + ", " +
                     "StartDate='" + StartDate + "', " +
                     "EndDate='" + EndDate + "' " +
                     "Where ID=(Select Max(ID) From tblPersonnel)";

            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            command.ExecuteNonQuery();

            //commit the transaction if all insert/update statements execute
            myTransaction.Commit();

            conn.Close();
            recordSaved = true;
        }
        catch (Exception ex)
        {
            //rollback the transaction if the statements fail
            myTransaction.Rollback();
            recordSaved = false;
        }
        return recordSaved;
    }
    
    // This function gets the user activity from the tblUserActivity
    public static dsUserActivity GetUserActivity(string Database)
    {
        dsUserActivity DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;

        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Database);

        sqlDA = new OleDbDataAdapter("select * from tblUserActivity", sqlConn);

        DS = new dsUserActivity();

        sqlDA.Fill(DS.tblUserActivity);

        return DS;
    }

    // This function saves the user activity
    public static void SaveUserActivity(string Database, string FormAccessed)
    {
        OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Database);
        conn.Open();
        OleDbCommand command = conn.CreateCommand();
        string strSQL;

        strSQL = "Insert into tblUserActivity (UserIP, FormAccessed) values ('" +
            GetIP4Address() + "', '" + FormAccessed + "')";

        command.CommandType = CommandType.Text;
        command.CommandText = strSQL;
        command.ExecuteNonQuery();
        conn.Close();
    }

    // This function gets the IP Address
    public static string GetIP4Address()
    {
        string IP4Address = string.Empty;

        foreach (IPAddress IPA in
                    Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        if (IP4Address != string.Empty)
        {
            return IP4Address;
        }

        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        return IP4Address;
    }

    public static dsPersonnel GetPersonnel(string Database)
    {
        dsPersonnel DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;

        // Add your comments here
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Database);

        sqlDA = new OleDbDataAdapter("select * from tblPersonnel", sqlConn);

        DS = new dsPersonnel();
        // fill the dataset with the tblPersonnel data
        sqlDA.Fill(DS.tblPersonnel);
        // return the data filled dsPersonnel
        return DS;
    }

    //public static dsUser GetUser(string Database)
    //{
    //    dsUser DS;
    //    OleDbConnection sqlConn;
    //    OleDbDataAdapter sqlDA;
    //    sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Database);
    //    sqlDA = new OleDbDataAdapter("select * from tblUserLogin", sqlConn);
    //    DS = new dsUser();
    //    sqlDA.Fill(DS.tblUserLogin);
    //    return DS;
    //}

    public static dsPersonnel GetPersonnel(string Database, string searchVal)
    {
        dsPersonnel DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;

        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + Database);

        sqlDA = new OleDbDataAdapter("select * from tblPersonnel WHERE LastName LIKE '%"+searchVal+"%' ", sqlConn);

        DS = new dsPersonnel();

        // fill the dataset with the tblPersonnel data
        sqlDA.Fill(DS.tblPersonnel);

        // return the data filled dsPersonnel
        return DS;
    }

	public clsDataLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}