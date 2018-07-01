using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lojaJogos.Models {
    public class Jogos {

    	public Jogos()
        {
            ListaDeCategorias = new HashSet<Categorias>();
            ListaDeMedia = new HashSet<Media>();
            ListaDeCompras = new HashSet<Compra>();
        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public string Capa { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Categorias> ListaDeCategorias { get; set; }

        public virtual ICollection<Media> ListaDeMedia { get; set; }

        public virtual ICollection<Compra> ListaDeCompras { get; set; }


    }
}