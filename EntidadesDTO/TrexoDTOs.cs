using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntidadesDTO
{
    [DataContract]
    public class TrexoDTO
    {
        /// <summary>
        /// Identificador do trexo
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public long Id { get; set; }
        /// <summary>
        /// Identificador da cidade de partida
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int IdCidadePartida { get; set; }
        /// <summary>
        /// Cidade de partida
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public virtual CidadeDTO CidadePartida { get; set; }
        /// <summary>
        /// Cidade de destino
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public virtual CidadeDTO CidadeDestino { get; set; }
        /// <summary>
        /// Número de dias do trexo
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int NumDiasTrexo { get; set; }
        /// <summary>
        /// Informa se o campo não é mais válido
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool IsDeleted { get; set; }
    }
}
