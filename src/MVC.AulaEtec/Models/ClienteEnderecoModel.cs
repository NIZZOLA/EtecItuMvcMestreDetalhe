using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.AulaEtec.Models
{
    public class ClienteEnderecoModel
    {
        [Key]
        public int ClienteEnderecoId { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public ClienteModel Cliente { get; set; }

        [MaxLength(100)]
        public string Rua { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [MaxLength(10)]
        public string Cep { get; set; }
        [MaxLength(50)]
        public string Referencia { get; set; }

        public bool Ativo { get; set; }

        public bool Padrao { get; set; }
    }
}
