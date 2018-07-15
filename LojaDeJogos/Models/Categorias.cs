using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lojaJogos.Models {
    public class Categorias {

        public Categorias()
        {
            ListaDeJogos = new HashSet<Jogos>();
        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Jogos> ListaDeJogos { get; set; }

    }
}