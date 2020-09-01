using Entidades.Properties;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        /// <summary>
        /// Identificador da cidade
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome da cidade
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroObrigatorio")]
        [MinLength(2, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroTamanhoMinimo")]
        public string NomeCidade { get; set; }
        /// <summary>
        /// Sigla da cidade
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroObrigatorio")]
        [MaxLength(2, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroTamanhoMaximo")]
        [MinLength(2, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroTamanhoMinimo")]
        public string Sigla { get; set; }
        /// <summary>
        /// Identificador do estado onde fica a cidade
        /// </summary>
        [ForeignKey(nameof(Estado))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroObrigatorio")]
        public int IdEstado { get; set; }
        /// <summary>
        /// Estado onde fica a cidade
        /// </summary>
        public virtual Estado Estado { get; set; }
        /// <summary>
        /// Trexos em que a cidade é a partida
        /// </summary>
        public virtual IList<Trexo> TrexosDePartida { get; set; }
        /// <summary>
        /// Trexos em que a cidade é o destino
        /// </summary>
        public virtual IList<Trexo> TrexosDeDestino { get; set; }
    }
}
