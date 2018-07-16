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

        [RegularExpression("[A-ZÂÍ][a-záéíóúãõàèìòùâêîôûäëïöüç.]+(( | de | da | dos | d'|-)[A-ZÂÍ][a-záéíóúãõàèìòùâêîôûäëïöüç.]+){1,3}",ErrorMessage = "O nome apenas aceita letras. Cada palavra começa por uma maiúscula, seguida de minúsculas...")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Compra> ListaDeCompras { get; set; }

    }
}