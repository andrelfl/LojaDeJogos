using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaJogos.Models {
    public class Media {

        [Key]
        public int ID { get; set; }

        public string Fotografia { get; set; }

        public string tipo { get; set; }

        [ForeignKey("Jogos")]
        public int JogosFK { get; set; }

        public virtual Jogos Jogos { get; set; }
    }
}