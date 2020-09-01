using EntidadesDTO;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Models
{
    [DataContract]
    public class EstadoDTO
    {
        public EstadoDTO(int id, string nome, string sigla)
        {
            this.Id = id;
            this.NomeEstado = nome;
            this.Sigla = sigla;
        }
        /// <summary>
        /// identificador do estado
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int Id { get; set; }
        /// <summary>
        /// Cidades do estado
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public IList<CidadeDTO> Cidades { get; set; }
        /// <summary>
        /// Nome do estado
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string NomeEstado { get; set; }
        /// <summary>
        /// Sigla do estado
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Sigla { get; set; }
    }
}
