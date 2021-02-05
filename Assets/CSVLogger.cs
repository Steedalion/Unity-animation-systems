using System;
using System.IO;
using UnityEngine;

public class CSVLogger : MonoBehaviour
{
    public string fileName;
    protected StreamWriter file;
    private const string version = "0.1";

    private static string GETDate()
    {
        string date = System.DateTime.Now.ToString("yyyy:MM:dd,ddd,hh:mm:ss tt");
        return date;
    }

    private void addColumnHeader()
    {
        try
        {
            file.WriteLine("Username," + "Date," + "Day," + "Time of day," + "Version," + "Task");
            file.Flush();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Could not log data:", ex);
        }
    }

    public void writeArrayPositions(string username, string taskName, Vector3[] Positions)
    {
        try
        {
            string date = GETDate();
            file.Write(
                username + "," +
                date + "," +
                "version=" + version + "," +
                taskName + ","
            );
            foreach (Vector3 position in Positions)
            {
                writeVector3(position);
            }

            file.Write("\n");
            file.Flush();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Could not log data:", ex);
        }
    }

    public void recordError(string username, string taskName)
    {
        try
        {
            string date = GETDate();
            file.Write(
                username + "," +
                date + "," +
                "version=" + version + "," +
                taskName + ","
            );
            file.Write("ERROR");
            file.Write("\n");
            file.Flush();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Could not log data:", ex);
        }
    }

    public void recordTLX(string username, string taskName, int[] answers)
    {
        try
        {
            string date = GETDate();
            file.Write(
                username + "," +
                date + "," +
                "version=" + version + "," +
                taskName + "_tlx" + ","
            );
            foreach (int answer in answers)
            {
                file.Write(answer.ToString() + ", ");
            }

            file.Write("\n");
            file.Flush();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Could not log data:", ex);
        }
    }

    public void addRecord(string username, string meanError, string Variance)
    {
        try
        {
            string date = GETDate();
            file.WriteLine(username + "," +
                           date + "," +
                           "Version=" + version + "," +
                           meanError + "," +
                           Variance + ","
            );
            file.Flush();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Could not log data:", ex);
        }
    }

    private void writeVector3(Vector3 position)
    {
        file.Write(position.x + ",");
        file.Write(position.y + ",");
        file.Write(position.z + ",");
    }

    // Start is called before the first frame update
    private void Start()
    {
        file = new StreamWriter("Data/" + fileName, true);
        addColumnHeader();
    }
}