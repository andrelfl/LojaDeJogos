using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LojaDeJogos.Models;
using lojaJogos.Models;

namespace LojaDeJogos.Frontend.API
{
    public class CategoriasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Categorias
        public IHttpActionResult GetCategoria()
        {
            var resultado = db.Categoria.Select(Categorias => new
            {
                Categorias.Nome,
                Categorias.ListaDeJogos
            }).ToList();

            return Ok(resultado);
        }

        // GET: api/Categorias/5
        [ResponseType(typeof(Categorias))]
        public IHttpActionResult GetCategorias(int id)
        {
            Categorias categorias = db.Categoria.Find(id);
            if (categorias == null)
            {
                return NotFound();
            }

            var resultado = new
            {
                categorias.Nome,
                categorias.ListaDeJogos
            };
            return Ok(resultado);
        }

        // PUT: api/Categorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategorias(int id, Categorias categorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorias.ID)
            {
                return BadRequest();
            }

            db.Entry(categorias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categorias
        [ResponseType(typeof(Categorias))]
        public IHttpActionResult PostCategorias(Categorias categorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categoria.Add(categorias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categorias.ID }, categorias);
        }

        // DELETE: api/Categorias/5
        [ResponseType(typeof(Categorias))]
        public IHttpActionResult DeleteCategorias(int id)
        {
            Categorias categorias = db.Categoria.Find(id);
            if (categorias == null)
            {
                return NotFound();
            }

            db.Categoria.Remove(categorias);
            db.SaveChanges();

            return Ok(categorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriasExists(int id)
        {
            return db.Categoria.Count(e => e.ID == id) > 0;
        }
    }
}