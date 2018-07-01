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
    public class JogosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Jogos
        public IHttpActionResult GetJogos()
        {
            var resultado = db.Jogos.Select(jogos => new
            {
                jogos.ID,
                jogos.Nome,
                jogos.Capa,
                jogos.Descricao
            }).ToList();

            return Ok(resultado);
        }

        // GET: api/Jogos/5
        [ResponseType(typeof(Jogos))]
        public IHttpActionResult GetJogos(int id)
        {
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return NotFound();
            }
            var resultado = new
            {
                jogos.ID,
                jogos.Nome,
                jogos.Capa,
                jogos.Descricao
            };
            return Ok(resultado);
        }

        // PUT: api/Jogos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJogos(int id, Jogos jogos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jogos.ID)
            {
                return BadRequest();
            }

            db.Entry(jogos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogosExists(id))
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

        // POST: api/Jogos
        [ResponseType(typeof(Jogos))]
        public IHttpActionResult PostJogos(Jogos jogos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jogos.Add(jogos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jogos.ID }, jogos);
        }

        // DELETE: api/Jogos/5
        [ResponseType(typeof(Jogos))]
        public IHttpActionResult DeleteJogos(int id)
        {
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return NotFound();
            }

            db.Jogos.Remove(jogos);
            db.SaveChanges();

            return Ok(jogos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JogosExists(int id)
        {
            return db.Jogos.Count(e => e.ID == id) > 0;
        }
    }
}