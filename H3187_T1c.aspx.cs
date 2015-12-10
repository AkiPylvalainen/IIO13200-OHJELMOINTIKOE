using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3187_T1c : System.Web.UI.Page
{
    BL_T1 bl = new BL_T1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        String text = txtInput.Text;

        if (text != null)
        {
            bl.Check(text);
        }
    }
}