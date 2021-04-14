using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.AulaEtec.ViewModel
{
    public class ClienteFullViewModel
    {
        #region Cliente
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeFantasia { get; set; }

        [Required]
        [MaxLength(100)]
        public string RazaoSocial { get; set; }

        [MaxLength(100)]
        public string Apelido { get; set; }

        [MaxLength(18)]
        public string Cnpj { get; set; }
        [MaxLength(18)]
        public string IE { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Observacoes { get; set; }

        [MaxLength(250)]
        public string LogoAddress { get; set; }

        [MaxLength(20)]
        public string CodigoExterno { get; set; }
        #endregion

        #region Endereco
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
        #endregion 
    }
}
