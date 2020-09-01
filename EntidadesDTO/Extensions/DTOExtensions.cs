using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EntidadesDTO.Extensions
{
    public static class DTOExtensions
    {
        /// <summary>
        /// Função para fazer o parse entre o model e o dto
        /// </summary>
        /// <param name="model"></param>
        /// <returns>CidadeDTO</returns>
        public static CidadeDTO ParseToCidadeDTO(this Cidade model)
        {
            if (model == null)
                return null;

            return new CidadeDTO(model.Id, model.NomeCidade, model.Sigla);
        }
        /// <summary>
        /// Função para fazer o parse entre o uma lista do model e uma lista do dto
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IEnumerable<CidadeDTO></returns>
        public static IEnumerable<CidadeDTO> ParseToCidadesDTO(this IEnumerable<Cidade> model)
        {
            var cidades = new List<CidadeDTO>();
            if (model != null)
            {
                foreach (var cidade in model)
                    cidades.Add(cidade.ParseToCidadeDTO());
            }

            return cidades;
        }
        /// <summary>
        /// Função para fazer o parse entre o model e o dto
        /// </summary>
        /// <param name="model"></param>
        /// <returns>EstadoDTO</returns>
        public static EstadoDTO ParseToEstadoDTO(this Estado model)
        {
            if (model == null)
                return null;

            return new EstadoDTO(model.Id, model.NomeEstado, model.Sigla);
        }
        /// <summary>
        /// Função para fazer o parse entre o uma lista do model e uma lista do dto
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IEnumerable<EstadoDTO></returns>
        public static IEnumerable<EstadoDTO> ParseToEstadosDTO(this IEnumerable<Estado> model)
        {
            var estados = new List<EstadoDTO>();
            if (model != null)
            {
                foreach (var estado in model)
                    estados.Add(estado.ParseToEstadoDTO());
            }

            return estados;
        }
    }
}
