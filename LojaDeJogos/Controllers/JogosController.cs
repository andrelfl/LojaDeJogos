﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaDeJogos.Models;
using lojaJogos.Models;

namespace LojaDeJogos.Controllers
{
    public class JogosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jogos
        public ActionResult Index()
        {
            //Ordena a lista de jogos por nome
            var listaJogos = db.Jogos.ToList().OrderBy(a => a.Nome);
            
            return View(listaJogos);
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // ou não foi introduzido um ID válido,
                // ou foi introduzido um valor completamente errado
                return RedirectToAction("Index");
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return RedirectToAction("Index");
            }
            return View(jogos);
        }

        // GET: Jogos/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            //Criacao da select list para poder editar a lista de categorias de um jogo, ao ser criado
            ViewBag.LCateg = new SelectList(db.Categoria, "ID", "Nome");
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Preco,Descricao")] Jogos jogos, HttpPostedFileBase fileUpload, String precoLong)
        {
            //Guardar o id de cada categoria para uso posterior
            string idCat = Request.Form["LCateg"].ToString();
            int idCat1 = idCat[0] - '0';
            int idCat2 = idCat[2] - '0';
            int idCat3 = idCat[4] - '0';
            //Buscar as categorias atraves do id
            Categorias categ1 = db.Categoria.Where(a => a.ID == idCat1).Single();
            Categorias categ2 = db.Categoria.Where(a => a.ID == idCat2).Single();
            Categorias categ3 = db.Categoria.Where(a => a.ID == idCat3).Single();

            //Cast da string passado como parametro no metodo para double, para poder ser usado no jogo
            jogos.Preco = Double.Parse(precoLong);

            int novoID = 0;

            // *****************************************
            // proteger a geração de um novo ID
            // *****************************************
            // determinar o nº de Agentes na tabela

            if (db.Jogos.Count() == 0){
                novoID = 1;
            }else{
                novoID = db.Jogos.Max(a => a.ID) + 1;
            }

            jogos.ID = novoID;

            string imgPath = Path.Combine(Server.MapPath("~/media/"), "Jogo_" + novoID + ".jpg");

            jogos.Capa = "Jogo_" + novoID + ".jpg";

            if (fileUpload != null)
            {
                jogos.Capa = "Jogo_" + novoID + ".jpg";
            }else{
                ModelState.AddModelError("", "Não foi fornecida uma imagem..."); // gera MSG de erro
                return View(jogos);
            }

            if (ModelState.IsValid) { 
                try{
                    db.Jogos.Add(jogos);
                    jogos.ListaDeCategorias.Add(categ1);
                    jogos.ListaDeCategorias.Add(categ2);
                    jogos.ListaDeCategorias.Add(categ3);
                    db.SaveChanges();
                    fileUpload.SaveAs(imgPath);
                    return RedirectToAction("Index");
                }catch{
                    // gerar uma mensagem de erro para o utilizador
                    ModelState.AddModelError("", "Ocorreu um erro não determinado na criação de um novo jogo...");
                }
            }

            return View(jogos);
        }

        // GET: Jogos/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return RedirectToAction("Index");
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Preco,Descricao")] Jogos jogos, HttpPostedFileBase fileUpload, String precoLong)
        {
            jogos.Preco = Double.Parse(precoLong);

            string imgPath = Path.Combine(Server.MapPath("~/media/"), "Jogo_" + jogos.ID + ".jpg");

            jogos.Capa = "Jogo_" + jogos.ID + ".jpg";

            if(fileUpload == null)
            {
                ModelState.AddModelError("", "Image not provided");
                return View(jogos);
            }



            if (ModelState.IsValid)
            {
                db.Jogos.Add(jogos);
                db.Entry(jogos).State = EntityState.Modified;
                db.SaveChanges();
                fileUpload.SaveAs(imgPath);
                return RedirectToAction("Index");
            }
            return View(jogos);  
        }



        // GET: Jogos/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return RedirectToAction("Index");
            }
            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){

            Jogos jogos = db.Jogos.Find(id);

            try{
            // remover da memória
            db.Jogos.Remove(jogos);
                // commit na BD
                db.SaveChanges();
                // redirecionar para a página inicial
                return RedirectToAction("Index");
            }catch (Exception){
                // gerar uma mensagem de erro, a ser apresentada ao utilizador
                ModelState.AddModelError(
                "",string.Format("Não foi possível remover o Jogo '{0}', porque existem categorias associadas a ele.", jogos.Nome));
            }
                // reenviar os dados para a View
                return View(jogos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
