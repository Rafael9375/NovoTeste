using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Motorista
    {
        public int id { get; set; }
        public string nome { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
        public DateTime ? dataNascimento { get; set; }
        public string cpf { get; set; }
        public string sexo { get; set; }
        public Sexo listaSexo { get; set; }
        public bool ativo { get; set; }
    }
}