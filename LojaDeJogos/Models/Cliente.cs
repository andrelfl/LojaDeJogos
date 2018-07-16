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

        [RegularExpression("[A-Z��][a-z�����������������������.]+(( | de | da | dos | d'|-)[A-Z��][a-z�����������������������.]+){1,3}",ErrorMessage = "O nome apenas aceita letras. Cada palavra come�a por uma mai�scula, seguida de min�sculas...")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email inv�lido")]
        public string Email { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data inv�lida")]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Compra> ListaDeCompras { get; set; }

    }
}