using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public double Preco { get; set; }

        public string Capa { get; set; }

        [DataType(DataType.MultilineText, ErrorMessage = "Email inválido")]
        public string Descricao { get; set; }

        public virtual ICollection<Categorias> ListaDeCategorias { get; set; }

        public virtual ICollection<Media> ListaDeMedia { get; set; }

        public virtual ICollection<Compra> ListaDeCompras { get; set; }
    }
}