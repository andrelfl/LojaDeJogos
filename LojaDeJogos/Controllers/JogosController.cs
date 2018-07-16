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
            return View(db.Jogos.ToList());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Preco,Descricao")] Jogos jogos, HttpPostedFileBase fileUpload, String precoLong)
        {
            jogos.Preco = Double.Parse(precoLong);

            int novoID = db.Jogos.Max(a => a.ID) + 1;
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

            if (ModelState.IsValid)
            {
                db.Jogos.Add(jogos);
                db.SaveChanges();
                fileUpload.SaveAs(imgPath);
                return RedirectToAction("Index"); 
            }

            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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
                "",string.Format("Não foi possível remover o Jogo '{0}', porque existem {1} categorias associadas a ele.", jogos.Nome, jogos.ListaDeCategorias.Count));
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
