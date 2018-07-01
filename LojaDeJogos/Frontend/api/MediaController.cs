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
    public class MediaController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Media
        public IHttpActionResult GetMedia()
        {
            var resultado = db.Media.Select(media => new
            {
                media.ID,
                media.Fotografia
            }).ToList();

            return Ok(resultado);
        }

        // GET: api/Media/5
        [ResponseType(typeof(Media))]
        public IHttpActionResult GetMedia(int id)
        {
            Media media = db.Media.Find(id);
            if (media == null)
            {
                return NotFound();
            }
            var resultado = new
            {
                media.ID,
                media.Fotografia
            };
            return Ok(resultado);
        }

        // PUT: api/Media/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedia(int id, Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != media.ID)
            {
                return BadRequest();
            }

            db.Entry(media).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(id))
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

        // POST: api/Media
        [ResponseType(typeof(Media))]
        public IHttpActionResult PostMedia(Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Media.Add(media);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = media.ID }, media);
        }

        // DELETE: api/Media/5
        [ResponseType(typeof(Media))]
        public IHttpActionResult DeleteMedia(int id)
        {
            Media media = db.Media.Find(id);
            if (media == null)
            {
                return NotFound();
            }

            db.Media.Remove(media);
            db.SaveChanges();

            return Ok(media);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MediaExists(int id)
        {
            return db.Media.Count(e => e.ID == id) > 0;
        }
    }
}