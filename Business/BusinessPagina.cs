using System;
using System.Collections.Generic;
using System.Data;
using DataBase;
namespace Business
{
    public class BusinessPagina
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public string Diretorio { get; set; }

        DataBasePagina _dbPaginas;

        public BusinessPagina()
        {
            Id = Guid.NewGuid();
            _dbPaginas = new DataBasePagina();
        }

        public BusinessPagina BuscarPorId(Guid id)
        {   
            DataRow[] row = _dbPaginas.BuscarPorId(id);

            BusinessPagina pb = new BusinessPagina();

            pb.Id = Guid.Parse(row[0][0].ToString());
            pb.Nome = row[0][1].ToString();
            pb.Conteudo = row[0][2].ToString();
            pb.Data = Convert.ToDateTime(row[0][3].ToString());
            pb.Status = row[0][4].ToString();
            return pb;
        }

        public List<BusinessPagina> ListaPaginas()
        {
            List<BusinessPagina> lista = new List<BusinessPagina>();

            foreach (DataRow row in _dbPaginas.ListaPaginas().Rows)
            {
                BusinessPagina pb = new BusinessPagina();
                pb.Id = Guid.Parse(row["Id"].ToString());
                pb.Nome = row["Nome"].ToString();
                pb.Conteudo = row["Conteudo"].ToString();
                pb.Data = Convert.ToDateTime(row["Data"]);
                pb.Status = row["Status"].ToString();

                lista.Add(pb);
            }
            
            return lista;
        }

        public void Criar()
        {
            new DataBasePagina().Criar(this.Id, this.Nome, this.Conteudo, this.Data, this.Status, this.Diretorio);
        }

        public void Alterar()
        {
            new DataBasePagina().Alterar(this.Id, this.Nome, this.Conteudo, this.Data, this.Status, this.Diretorio);
        }

        public void Excluir(Guid id)
        {
            new DataBasePagina().Excluir(id);
        }
    }
}
