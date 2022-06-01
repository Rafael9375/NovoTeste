using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto.App;
using Projeto.Models;

namespace TesteUnitario
{
    [TestClass]
    public class AppMotorista
    {
        [TestMethod]
        public void SalvandoMotorista()
        {
            Motorista motorista = new Motorista() { nome = "Lucas" };
            Projeto.App.AppMotorista app = new Projeto.App.AppMotorista();
            app.Salvar(motorista);
        }

        [TestMethod]
        public void RetornarTodos()
        {
            Projeto.App.AppMotorista app = new Projeto.App.AppMotorista();
            List<Motorista> teste = app.RetornarTodos();
        }

        [TestMethod]
        public void Retornar()
        {
            Projeto.App.AppMotorista app = new Projeto.App.AppMotorista();
            Motorista motorista = new Motorista() { nome = "Lucas" };
            var teste = app.Retornar(motorista);
            motorista = new Motorista() { id = 1 };
            var teste2 = app.Retornar(motorista);
            motorista = new Motorista() { ativo = true };
            var teste3 = app.Retornar(motorista);
        }

        [TestMethod]
        public void Deletar()
        {
            Projeto.App.AppMotorista app = new Projeto.App.AppMotorista();
            app.Deletar(new Motorista() { id = 1 });
        }

        [TestMethod]
        public void AtualizarM()
        {
            Projeto.App.AppMotorista app = new Projeto.App.AppMotorista();
            Motorista motorista = new Motorista()
            {
                id = 1,
                nome = "Daniel",
                dataNascimento = new DateTime(1993, 5, 1),
                ativo = false
            };
            app.Atualizar(motorista);
        }
    }
}
