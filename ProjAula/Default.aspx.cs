using Dados;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjAula
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            GDVAula.DataSource = new AulaDB().FindAll();
            GDVAula.DataBind();
        }

        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroAula.aspx");
        }

        protected void GDVAula_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int line = int.Parse(e.CommandArgument.ToString());
            int id = int.Parse(GDVAula.Rows[line].Cells[0].Text);

            Aula bilheteria = new AulaDB().FindById(id);

            if (e.CommandName == "A")
            {
                Response.Redirect("CadastroAula.aspx?idItem=" + id);
            }
            else if (e.CommandName == "E")
            {
                lblExcluir.Text = id.ToString();
                lblMsg.Text = "Tem certeza que deseja excluir este registro?";
                DisplayModal(this);
            }
        }

        private void DisplayModal(Page page)
        {
            ClientScript.RegisterStartupScript(typeof(Page),
                                               Guid.NewGuid().ToString(),
                                               "MostrarModal();",
                                               true);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblExcluir.Text);
            new AulaDB().Delete(id);
            LoadTable();
        }
    }
}