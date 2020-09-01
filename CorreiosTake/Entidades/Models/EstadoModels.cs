using Entidades.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    [Table("Estado")]
    public class Estado
    {
        /// <summary>
        /// identificador do estado
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Cidades do estado
        /// </summary>
        public IList<Cidade> Cidades { get; set; }
        /// <summary>
        /// Nome do estado
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroObrigatorio")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroTamanhoMinimo")]
        public string NomeEstado { get; set; }
        /// <summary>
        /// Sigla do estado
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroObrigatorio")]
        [MaxLength(2, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroTamanhoMaximo")]
        [MinLength(2, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroTamanhoMinimo")]
        public string Sigla { get; set; }
    }
}
