using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLDemoxOy
/// </summary>
public class BLDemoxOy
{
    public static bool TestConnectionToDatabase(String connectionString)
    {
        return DBDemoxOy.TestConnection(connectionString);
    }

    public static int GetCourseCount(String connectionString)
    {
        return DBDemoxOy.GetCourseCount(connectionString);
    }

    public static int GetStudentCount(String connectionString)
    {
        return DBDemoxOy.GetStudentCount(connectionString);
    }

    public static DataTable GetAllStudents(String connectionString)
    {
        return DBDemoxOy.GetAllStudents(connectionString);
    }

    public static DataTable GetStudentsInAlphabeticalOrder(String connectionString)
    {
        return DBDemoxOy.GetStudentsInAlphabeticalOrder(connectionString);
    }

    public static DataTable GetStudentsByCourse(String connectionString, String course)
    {
        return DBDemoxOy.GetStudentsByCourse(connectionString, course);
    }
}