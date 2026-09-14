// Decompiled with JetBrains decompiler
// Type: MackinawCPS.SQLHelper
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

#nullable disable
namespace MackinawCPS;

public class SQLHelper
{
  public static void RunSQLScript(string server, string user, string password, string scriptfile)
  {
    ProcessStartInfo processStartInfo = new ProcessStartInfo("sqlcmd", $"-S {server} -U {user} -P {password} -i \"{scriptfile}\"");
    processStartInfo.UseShellExecute = false;
    processStartInfo.CreateNoWindow = true;
    Process process = new Process();
    process.StartInfo = processStartInfo;
    process.Start();
    process.WaitForExit();
    process.Close();
  }

  public static void CleanLocalDB()
  {
    string commandText = string.Format("--drop all the connections to a database immediately\r\n                                            ALTER DATABASE [RMServer]\r\n                                            SET OFFLINE WITH ROLLBACK IMMEDIATE\r\n                                            ALTER DATABASE [RMServer]\r\n                                            SET ONLINE                                            \r\n\r\n                                            use RMServer\t\t\t\t\t\t\t\t\t\t\t\r\n\r\n                                            EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'\r\n                                            EXEC sp_MSForEachTable 'ALTER TABLE ? DISABLE TRIGGER ALL'\r\n                                            declare @trun_name varchar(50)\r\n                                            declare name_cursor cursor for\r\n                                            -- If there are many table need to keep the data，you can change this script \r\n                                            -- For example select 'delete from [' + Name+ ']' from sysobjects where xtype='U' and [name] not in ('Server','Group')\r\n                                            select 'delete from [' + Name+ ']' from sysobjects where xtype='U' and [name] not in ('Server')\r\n                                            open name_cursor\r\n                                            fetch next from name_cursor into @trun_name\r\n                                            while @@FETCH_STATUS = 0\r\n                                            begin\r\n                                                exec (@trun_name)\r\n                                                print 'delete from ' + @trun_name\r\n                                                fetch next from name_cursor into @trun_name\r\n                                            end\r\n                                            close name_cursor\r\n                                            deallocate name_cursor\r\n                                            EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'\r\n                                            EXEC sp_MSForEachTable 'ALTER TABLE ? ENABLE TRIGGER ALL'");
    string connectionString = "Data Source=.\\MOTOROLARMSERVER;Initial Catalog=RMServer;User Id=RMUser;Password=Plan.tation12345;";
    try
    {
      SQLHelper.ExecuteNonQuery(new SqlConnection(connectionString), CommandType.Text, commandText, (SqlParameter[]) null);
    }
    catch (Exception ex)
    {
      using (StreamWriter streamWriter = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CleanDB.log"), true))
      {
        streamWriter.WriteLine(ex.Message);
        streamWriter.WriteLine(ex.StackTrace);
        if (ex.InnerException != null)
        {
          streamWriter.WriteLine("InnerException:" + ex.InnerException.Message);
          streamWriter.WriteLine(ex.InnerException.StackTrace);
        }
        streamWriter.Flush();
        streamWriter.Close();
      }
    }
  }

  public static void InitSerialNumberTable()
  {
    SQLHelper.ExecuteNonQuery(new SqlConnection("Data Source=.\\MOTOROLARMSERVER;Initial Catalog=RMServer;User Id=RMUser;Password=Plan.tation12345;"), CommandType.Text, "\r\n                if not exists( select * from SerialNumber where SerialName='SerialNumberHolder' ) \r\n                begin\r\n                insert into  SerialNumber (uuid,SerialName,Counter) values(newid(),'SerialNumberHolder',0)\r\n                end\r\n            ", (SqlParameter[]) null);
  }

  private static int ExecuteNonQuery(
    SqlConnection connection,
    CommandType commandType,
    string commandText,
    params SqlParameter[] commandParameters)
  {
    if (connection == null)
      throw new ArgumentNullException(nameof (connection));
    SqlCommand command = new SqlCommand();
    bool mustCloseConnection = false;
    SQLHelper.PrepareCommand(command, connection, (SqlTransaction) null, commandType, commandText, commandParameters, out mustCloseConnection);
    int num = command.ExecuteNonQuery();
    command.Parameters.Clear();
    if (mustCloseConnection)
      connection.Close();
    return num;
  }

  [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
  private static void PrepareCommand(
    SqlCommand command,
    SqlConnection connection,
    SqlTransaction transaction,
    CommandType commandType,
    string commandText,
    SqlParameter[] commandParameters,
    out bool mustCloseConnection)
  {
    if (command == null)
      throw new ArgumentNullException(nameof (command));
    if (commandText == null || commandText.Length == 0)
      throw new ArgumentNullException(nameof (commandText));
    if (connection.State != ConnectionState.Open)
    {
      mustCloseConnection = true;
      connection.Open();
    }
    else
      mustCloseConnection = false;
    command.Connection = connection;
    command.CommandText = commandText;
    if (transaction != null)
      command.Transaction = transaction.Connection != null ? transaction : throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", nameof (transaction));
    command.CommandType = commandType;
    if (commandParameters == null)
      return;
    SQLHelper.AttachParameters(command, commandParameters);
  }

  private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
  {
    if (command == null)
      throw new ArgumentNullException(nameof (command));
    if (commandParameters == null)
      return;
    foreach (SqlParameter commandParameter in commandParameters)
    {
      if (commandParameter != null)
      {
        if ((commandParameter.Direction == ParameterDirection.InputOutput || commandParameter.Direction == ParameterDirection.Input) && commandParameter.Value == null)
          commandParameter.Value = (object) DBNull.Value;
        command.Parameters.Add(commandParameter);
      }
    }
  }
}
