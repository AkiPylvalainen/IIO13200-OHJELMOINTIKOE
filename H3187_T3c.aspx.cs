using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class H3187_T3c : System.Web.UI.Page
{
    protected String connStr = ConfigurationManager.ConnectionStrings["Demox"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (BLDemoxOy.TestConnectionToDatabase(connStr))
            {
                int courseCount = BLDemoxOy.GetCourseCount(connStr);
                int studentCount = BLDemoxOy.GetStudentCount(connStr);

                MessageBox.Show("Tietokantayhteys toimii.\n\nKursseja:\t" + courseCount +"\nOppilaita:\t" + studentCount);

                FillControls();
            }
            else
            {
                MessageBox.Show("Tietokantayhteys ei toimi.");
            }
        }
    }

    protected void FillControls()
    {
        ddlCourses.DataSourceID = srcCourses.ID;
        ddlCourses.DataTextField = "course";
        ddlCourses.DataValueField = "course";
        ddlCourses.DataBind();
    }


    protected void btnGetAllStudents_Click(object sender, EventArgs e)
    {
        gvStudents.DataSource = BLDemoxOy.GetAllStudents(connStr);
        gvStudents.DataBind();
    }

    protected void btnGetStudentsByABC_Click(object sender, EventArgs e)
    {
        gvStudents.DataSource = BLDemoxOy.GetStudentsInAlphabeticalOrder(connStr);
        gvStudents.DataBind();
    }

    protected void btnGetStudentsByCourse_Click(object sender, EventArgs e)
    {
        if (!IsSelected(ddlCourses))
        {
            return;
        }

        String course = ddlCourses.SelectedValue.ToString();

        gvStudents.DataSource = BLDemoxOy.GetStudentsByCourse(connStr, course);
        gvStudents.DataBind();
    }

    protected Boolean IsSelected(DropDownList sender)
    {
        if (sender == null)
        {
            return false;
        }

        if (sender.SelectedIndex >= 0 && sender.SelectedIndex < sender.Items.Count)
        {
            return true;
        }
        else
        {
            sender.Focus();
            return false;
        }
    }

    
}