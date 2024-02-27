using System;

namespace WebApiDDD.Domain.Entities
{
    public class Produto : Base
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
        public bool Ativo { get; set; }
    }
}
