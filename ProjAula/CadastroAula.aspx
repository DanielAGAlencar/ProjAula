<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroAula.aspx.cs" Inherits="ProjAula.CadastroAula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro de Aulas</title>
</head>
<body>
    <div style="padding-top: 2%"></div>
    <div class="col-sm-8">
        <h2>Cadastro de Aulas</h2>
    </div>
    <div style="padding-top: 2%"></div>
    <form id="form1" runat="server">
        <div>
            <div class="col-sm-2">
                <asp:Label ID="lblMSG" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                <br />
                <br />
                <div class="form-group">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="TxtId" CssClass="form-control" runat="server" Width="206px" Enabled="False" Visible="False"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TxtNomeDisciplina">Nome Disciplina</label>
                    <asp:TextBox ID="TxtNomeDisciplina" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>
                <label for="TxtQtd_Alunos">Quantidade de Alunos</label>
                <asp:TextBox ID="TxtQtd_Alunos" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                <div class="form-group">
                    <label for="TxtNomeProfessor">Nome Professor</label>
                    <asp:TextBox ID="TxtNomeProfessor" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TxtNomeFaculdade">Nome da Faculdade</label>
                    <asp:TextBox ID="TxtNomeFaculdade" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <asp:Button ID="BtnSalvar" runat="server" CssClass="btn btn-primary" OnClick="BtnSalvar_Click" Text="Salvar" />
                    &nbsp;
                    <asp:Button ID="BtnVoltar" runat="server" CssClass="btn btn-default" Text="Voltar" OnClick="BtnVoltar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

