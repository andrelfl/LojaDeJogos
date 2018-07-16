using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaJogos.Models {
    public class Compra {

        public Compra()
        {
            ListaDeJogos = new HashSet<Jogos>();
        }

        [Key]
        public int ID { get; set; }

        public virtual ICollection<Jogos> ListaDeJogos { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteFK { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}