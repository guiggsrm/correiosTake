using Entidades.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EntidadesDTO
{
    [DataContract]
    public class CidadeDTO
    {
        public CidadeDTO(int id, string nome, string sigla, EstadoDTO estado = null)
        {
            this.Id = id;
            this.NomeCidade = nome;
            this.Sigla = sigla;
            this.Estado = estado;
        }
        /// <summary>
        /// Identificador da cidade
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int Id { get; set; }
        /// <summary>
        /// Nome da cidade
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string NomeCidade { get; set; }
        /// <summary>
        /// Sigla da cidade
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Sigla { get; set; }
        /// <summary>
        /// Estado onde fica a cidade
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public virtual EstadoDTO Estado { get; set; }
        /// <summary>
        /// Trexos em que a cidade é a partida
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public virtual IList<TrexoDTO> TrexosDePartida { get; set; }
        /// <summary>
        /// Trexos em que a cidade é o destino
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public virtual IList<TrexoDTO> TrexosDeDestino { get; set; }
    }
}
