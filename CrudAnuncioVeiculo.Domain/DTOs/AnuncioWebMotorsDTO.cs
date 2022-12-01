using CrudAnuncioVeiculo.Domain.Entities;

namespace CrudAnuncioVeiculo.Domain.DTOs
{
    public class AnuncioWebMotorsDTO
    {

        public int ID { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string? Observacao { get; set; }


        public static implicit operator AnuncioWebMotorsDTO(tb_AnuncioWebmotors entidade)
        {
            return entidade == null ? null : new AnuncioWebMotorsDTO
            {
                ID = entidade.ID,
                Marca = entidade.Marca,
                Modelo = entidade.Modelo,
                Versao = entidade.Versao,
                Ano = entidade.Ano,
                Quilometragem = entidade.Quilometragem,
                Observacao = entidade.Observacao
            };
        }
    }
}
