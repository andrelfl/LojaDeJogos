using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lojaJogos.Models {
    public class Cliente {

    	public Cliente()
        {
            ListaDeCompras = new HashSet<Compra>();
        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Compra> ListaDeCompras { get; set; }

    }
}