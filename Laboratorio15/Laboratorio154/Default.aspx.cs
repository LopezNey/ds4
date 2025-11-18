using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio154
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSumar_Click(object sender, EventArgs e)
        {
            int n1 = int.Parse(txtNum1.Text);
            int n2 = int.Parse(txtNum2.Text);
            int suma = n1 + n2;

            lblResultado.Text = "La suma es: " + suma;
        }
    }

}