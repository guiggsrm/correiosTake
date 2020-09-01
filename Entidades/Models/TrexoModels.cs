using Entidades.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    [Table("Trexo")]
    public class Trexo
    {
        public Trexo() { }
        public Trexo(int IdCidadePartida, int IdCidadeDestino, int NumDiasTrexo)
        {
            this.IdCidadePartida = IdCidadePartida;
            this.IdCidadeDestino = IdCidadeDestino;
            this.NumDiasTrexo = NumDiasTrexo;
        }
        /// <summary>
        /// Identificador do trexo
        /// </summary>
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// Identificador da cidade de partida
        /// </summary>
        [ForeignKey(nameof(CidadePartida))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroObrigatorio")]
        public int IdCidadePartida { get; set; }
        /// <summary>
        /// Cidade de partida
        /// </summary>
        public virtual Cidade CidadePartida { get; set; }
        /// <summary>
        /// Identificador da cidade de destino
        /// </summary>
        [ForeignKey(nameof(CidadeDestino))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroObrigatorio")]
        public int IdCidadeDestino { get; set; }
        /// <summary>
        /// Cidade de destino
        /// </summary>
        public virtual Cidade CidadeDestino { get; set; }
        /// <summary>
        /// Número de dias do trexo
        /// </summary>
        [Range(1, 100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErroValorEntre")]
        public int NumDiasTrexo { get; set; }
        /// <summary>
        /// Informa se o campo não é mais válido
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
