using Projeto.DbContext;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto.App
{
    public class AppMotorista
    {
        private Context Db { get; set; }
        public List<Sexo> sexo { get; set; }

        public AppMotorista()
        {
            Db = new Context();
            sexo = new List<Sexo>();
            sexo.Add(new Sexo() { id = 1, Descricao = "Masculino" });
            sexo.Add(new Sexo() { id = 2, Descricao = "Feminino" });
        }

        public void Salvar(Motorista motorista)
        {
            string com;
            com = "insert into tblMotorista(Nome, Sexo, DataNascimento, Ativo, Cpf) ";
            com += "values(@nome, @sexo, @dataNac, @ativo, @cpf)";
            
            SqlCommand command = new SqlCommand();
            command.CommandText = com;
            command.Parameters.AddWithValue("@nome", Db.IsNull(motorista.nome));
            command.Parameters.AddWithValue("@sexo", Db.IsNull(motorista.sexo));
            command.Parameters.AddWithValue("@dataNac", Db.IsNull(motorista.dataNascimento));
            command.Parameters.AddWithValue("@cpf", Db.IsNull(motorista.cpf));
            command.Parameters.AddWithValue("@ativo", 1);
            Db.Add(command);
        }

        public List<Motorista> Retornar(Motorista motorista)
        {
            List<Motorista> motoristas = new List<Motorista>();
            string com = "select * from tblMotorista where ";
            var par = 0;
            SqlCommand command = new SqlCommand();
            
            if (motorista.id > 0)
            {
                com += "id = " + motorista.id;
                par++;
            }

            if (motorista.nome != null)
            {
                if (command.Parameters.Count > 0)
                {
                    com += " or ";
                }
                com += "cpf = '" + motorista.cpf + "'";
                par++;
            }

            if (motorista.nome != null)
            {
                if (command.Parameters.Count > 0)
                {
                    com += " or ";
                }
                com += "nome like '%" + motorista.nome + "%'";
                par++;
            }

            if (motorista.sexo != null)
            {
                if (command.Parameters.Count > 0)
                {
                    com += " or ";
                }
                com += "sexo = " + motorista.sexo;
                par++;
            }

            if (par > 0)
            {
                com += " or ";
            }

            short at;
            if (motorista.ativo)
            {
                at = 1;
            }
            else
            {
                at = 0;
            }
            com += "ativo = " + at;
            command.CommandText = com;
            var tblMotoristas = Db.Get(command);
            if (tblMotoristas != null)
            {
                motoristas = PreencherLista(tblMotoristas);
            }
            return motoristas;
        }

        public List<Motorista> RetornarTodos()
        {
            List<Motorista> motoristas = new List<Motorista>();
            string com;
            com = "select * from tblMotorista";
            SqlCommand command = new SqlCommand();
            
            command.CommandText = com;
            var tblMotoristas = Db.Get(command);
            if (tblMotoristas != null)
            {
                motoristas = PreencherLista(tblMotoristas);
            }
            return motoristas;
        
}

        public void Atualizar(Motorista motorista)
        {
            string com;
            com = "update tblMotorista set " +
                "nome = @nome, " +
                "DataNascimento = @dataNascimento, " +
                "Sexo = @sexo, " +
                "Ativo = @ativo, " +
                "cpf = @cpf " +
                "where id = @id";

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@nome", Db.IsNull(motorista.nome));
            command.Parameters.AddWithValue("@sexo", Db.IsNull(motorista.sexo));
            command.Parameters.AddWithValue("@dataNascimento", Db.IsNull(motorista.dataNascimento));
            command.Parameters.AddWithValue("@id", Db.IsNull(motorista.id));
            command.Parameters.AddWithValue("@cpf", Db.IsNull(motorista.cpf));
            command.Parameters.AddWithValue("@ativo", motorista.ativo);
            
command.CommandText = com;
            Db.Update(command);
        }

        public void Deletar(Motorista motorista)
        {
            string com = "delete tblMotorista where id = @id";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", motorista.id);
            command.CommandText = com;
            Db.Delete(command);
        }

        private List<Motorista> PreencherLista(DataTable tblMotoristas)
        {
            List<Motorista> motoristas = new List<Motorista>();
            DateTime? dataNula = null;
            foreach (DataRow item in tblMotoristas.Rows)
            {
                var itemData = item["dataNascimento"].ToString();
                var itemAtivo = item["Ativo"].ToString();
                if (itemData != "")
                {
                    dataNula = Convert.ToDateTime(itemData);
                }

                motoristas.Add(new Motorista()
                {
                    id = Int32.Parse(item["id"].ToString()),
                    nome = item["nome"].ToString(),
                    sexo = item["sexo"].ToString(),
                    dataNascimento = dataNula,
                    cpf = item["cpf"].ToString(),
                    ativo = (bool)item["ativo"]
                });
            }
            return motoristas;
        }
    }
}