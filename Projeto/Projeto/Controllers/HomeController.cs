using Projeto.App;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        private AppMotorista app { get; set; }

        public HomeController()
        {
            app = new AppMotorista();
        }

        public ActionResult Index()
        {
            return RedirectToAction("ListaMotoristas");
        }

        public ActionResult CadastrarMotorista()
        {

            ViewBag.Sexo = new SelectList(app.sexo, "descricao", "descricao");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarMotorista(Motorista motorista)
        {

            app.Salvar(motorista);
            return RedirectToAction("Index");
        }

        public ActionResult ListaMotoristas()
        {
            var motoristas = app.RetornarTodos();
            return View(motoristas);
        }

        
        public ActionResult EditarMotorista(int id)
        {
            var motorista = app.Retornar(new Motorista() { id = id });
            motorista[0].listaSexo = app.sexo.Where(a => a.Descricao == motorista[0].sexo).FirstOrDefault();
            ViewBag.Sexo = new SelectList(app.sexo, "descricao", "descricao", motorista[0].listaSexo);
            return View(motorista[0]);
        }

        [HttpPost]
        public ActionResult EditarMotorista(Motorista motorista)
        {
            motorista.sexo = motorista.listaSexo.Descricao;
            app.Atualizar(motorista);
            return RedirectToAction("Index");
        }

        public ActionResult DeletarMotorista(int id)
        {
            var motorista = app.Retornar(new Motorista() { id = id });
            app.Deletar(motorista[0]);
            return RedirectToAction("Index");
        }
    }
}