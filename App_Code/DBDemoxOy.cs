using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBDemoxOy
/// </summary>
public class DBDemoxOy
{
    public DBDemoxOy()
    {

    }

    public static bool TestConnection(String connectionString)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Close();

                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static int GetCourseCount(String connectionString)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select count(distinct course) from lasnaolot";

                conn.Open();

                int count = 0;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        count = Int32.Parse(row.ItemArray[0].ToString());
                    }
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();

                return count;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Tapahtui virhe.");
            return -1;
        }
    }

    public static int GetStudentCount(String connectionString)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select count(distinct asioid) from lasnaolot";

                conn.Open();

                int count = 0;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        count = Int32.Parse(row.ItemArray[0].ToString());
                    }
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();

                return count;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Tapahtui virhe.");
            return -1;
        }
    }

    public static DataTable GetAllStudents(String connectionString)
    {
        String query = "select asioid, max(lastname), max(firstname), max(date), max(course), max(dateAdded) from lasnaolot group by asioid";

        try
        {
            DataTable dt = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                conn.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }

            return dt;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Tapahtui virhe.");
            return null;
        }
    }

    public static DataTable GetStudentsInAlphabeticalOrder(String connectionString)
    {
        String query = "select distinct asioid, lastname, firstname, date, course, dateAdded from lasnaolot where dateAdded is not null order by lastname asc";

        try
        {
            DataTable dt = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                conn.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }

            return dt;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Tapahtui virhe.");
            return null;
        }
    }

    public static DataTable GetStudentsByCourse(String connectionString, String course)
    {
        String query = "select distinct asioid, lastname, firstname, date, course, dateAdded from lasnaolot where course = @1 order by lastname asc";

        try
        {
            DataTable dt = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cmd.Parameters.AddWithValue("@1", course);

                conn.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }

            return dt;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Tapahtui virhe.");
            return null;
        }
    }

}