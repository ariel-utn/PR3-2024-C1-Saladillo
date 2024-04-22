using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ejemplo1
{
    public partial class formulario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (validarNombre(txtNombre.Text))
            {
                ddlNombre.Items.Add(txtNombre.Text);
                ordenarDropDownList(ddlNombre);
            }
            else
            {
                ClientScript.RegisterStartupScript(
                                                this.GetType(),
                                                "myalert",
                                                "alert('" + "nombre repetido" + "');",
                                                true);
            }
            limpiarTextBox(txtNombre);
        }

        private void ordenarDropDownList(DropDownList ddlNombre)
        {
            int i = 0;
            string[] nombres = new string[ddlNombre.Items.Count];

            /// COPIO ELEMENTO ELEMENTO EL CONTENIDO DEL DDL AL ARREGLO
            foreach(ListItem item in ddlNombre.Items)
            {
                nombres[i] = item.ToString();
                i++;
            }

            /// ORDENO EL ARREGLO
            Array.Sort(nombres);

            /// COPIAR EL CONTENIDO DEL ARREGLO AL DDL
            ddlNombre.DataSource = nombres;
            ddlNombre.DataBind();
        }

        private bool validarNombre(string nombre)
        {
            for(int i = 0; i < ddlNombre.Items.Count; i++)
            {
                if (nombre.ToUpper().Equals(ddlNombre.Items[i].ToString().ToUpper()))
                {
                    return false; /// ESTA REPETIDO
                }
            }
            return true;  /// NO ESTA REPETIDO
        }

        private void limpiarTextBox(TextBox textBox)
        {
            txtNombre.Text = string.Empty;
        }
    }
}