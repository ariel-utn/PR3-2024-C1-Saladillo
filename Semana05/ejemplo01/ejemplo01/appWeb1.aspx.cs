using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ejemplo01
{
    public partial class appWeb1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnAgregarNombre_Click(object sender, EventArgs e)
        {
            if (validarNombre(txtNombre.Text))
            {
                ddlNombre.Items.Add(txtNombre.Text);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" +  "Nombre Repetido" +   "');", true );
            }
            limpiarTextBox(txtNombre);

            ordenarDropDownList(ddlNombre);
        }

        private void ordenarDropDownList(DropDownList ddlNombre)
        {
            string[] arreglo = new string[ddlNombre.Items.Count];

            int i = 0;
            foreach (ListItem item in ddlNombre.Items)
            {
                arreglo[i] = item.ToString();
                i++;
            }
            Array.Sort(arreglo);
            ddlNombre.DataSource = arreglo;
            ddlNombre.DataBind();
        }

        private bool validarNombre(string nombre)
        {
            for(int i= 0; i < ddlNombre.Items.Count; i++)
                if(nombre.ToUpper().Equals(ddlNombre.Items[i].ToString().ToUpper()))            
                    return false;
            return true;
        }

        private void limpiarTextBox(TextBox textBox)
        {
            textBox.Text = string.Empty;
        }


    }
}