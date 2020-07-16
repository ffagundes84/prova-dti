using System;

namespace DataBase.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public string Diretorio { get; set; }
    }
}
