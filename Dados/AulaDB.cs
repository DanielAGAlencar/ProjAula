using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class AulaDB
    {
        private static SQLiteConnection sqliteConnection;

        public AulaDB()
        {
            sqliteConnection = ConnectionSQLite.DbConnection();
        }

        public bool Save(Aula aula)
        {
            try
            {
                string sql = "INSERT INTO aula (nomedisciplina, qtd_alunos, nomeprofessor, nomefaculdade) values (@NomeDisciplina, @Qtd_Alunos, @NomeProfessor, @NomeFaculdade)";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NomeDisciplina", aula.NomeDisciplina);
                    cmd.Parameters.AddWithValue("@Qtd_Alunos", aula.Qtd_Alunos);
                    cmd.Parameters.AddWithValue("@NomeProfessor", aula.NomeProfessor);
                    cmd.Parameters.AddWithValue("@NomeFaculdade", aula.NomeFaculdade);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Update(Aula aula)
        {
            try
            {
                string sql = "UPDATE aula set nomedisciplina = @NomeDisciplina, " +
                                                      "qtd_alunos = @Qtd_Alunos, " +
                                                      "nomeprofessor = @NomeProfessor, " +
                                                      "nomefaculdade = @NomeFaculdade " +
                                                      "WHERE id = @Id ";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", aula.Id);
                    cmd.Parameters.AddWithValue("@NomeDisciplina", aula.NomeDisciplina);
                    cmd.Parameters.AddWithValue("@Qtd_Alunos", aula.Qtd_Alunos);
                    cmd.Parameters.AddWithValue("@NomeProfessor", aula.NomeProfessor);
                    cmd.Parameters.AddWithValue("@NomeFaculdade", aula.NomeFaculdade);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM aula WHERE id = @Id";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public DataTable FindAll()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id, nomedisciplina, qtd_alunos, nomeprofessor, nomefaculdade");
            sb.Append("   FROM aula");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public Aula FindById(int id)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id, nomedisciplina, qtd_alunos, nomeprofessor, nomefaculdade");
            sb.Append("   FROM aula");
            sb.Append("   WHERE id = " + id);

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return ConvertDataTableToList(dt)[0];
        }

        private List<Aula> ConvertDataTableToList(DataTable dt)
        {
            var data = (from d in dt.AsEnumerable()
                        select new Aula()
                        {
                            Id = Convert.ToInt32(d["id"]),
                            NomeDisciplina = Convert.ToString(d["nomedisciplina"]),
                            Qtd_Alunos = Convert.ToInt32(d["qtd_alunos"]),
                            NomeProfessor = Convert.ToString(d["nomeprofessor"]),
                            NomeFaculdade = Convert.ToString(d["nomefaculdade"])
                        }).ToList();
            return data;
        }
    }
}
