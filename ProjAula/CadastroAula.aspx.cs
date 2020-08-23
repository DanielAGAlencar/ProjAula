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
    public partial class CadastroAula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataPage();
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {

            string idItem = Request.QueryString["idItem"];

            Aula aula = new Aula()
            {
                NomeDisciplina = TxtNomeDisciplina.Text,
                Qtd_Alunos = int.Parse(TxtQtd_Alunos.Text),
                NomeProfessor = TxtNomeProfessor.Text,
                NomeFaculdade = TxtNomeFaculdade.Text
            };

            if (String.IsNullOrEmpty(idItem))
            {
                new AulaDB().Save(aula);
                lblMSG.Text = "Registro Inserido!";
            }
            else
            {
                aula.Id = int.Parse(idItem);
                new AulaDB().Update(aula);
                lblMSG.Text = "Registro Atualizado!";
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void LoadDataPage()
        {
            string idItem = Request.QueryString["idItem"];

            if (!String.IsNullOrEmpty(idItem))
            {
                Aula aula = new AulaDB().FindById(int.Parse(idItem));

                lblId.Visible = true;
                TxtId.Visible = true;

                TxtQtd_Alunos.Text = aula.Qtd_Alunos.ToString();
                TxtNomeDisciplina.Text = aula.NomeDisciplina;
                TxtId.Text = aula.Id.ToString();
                TxtNomeProfessor.Text = aula.NomeProfessor;
                TxtNomeFaculdade.Text = aula.NomeFaculdade;
            }
        }
    }
}