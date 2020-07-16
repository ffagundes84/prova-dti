using System;
using System.Configuration;
using System.Data;
using DataBase.Entities;

namespace DataBase
{
    public class DataBasePagina
    {
        private DataTable _dataTablePaginas;

        public DataBasePagina()
        {
            _dataTablePaginas = new DataTable();
            _dataTablePaginas.Columns.Add("Id", typeof(Guid));
            _dataTablePaginas.Columns.Add("Nome", typeof(string));
            _dataTablePaginas.Columns.Add("Conteudo", typeof(string));
            _dataTablePaginas.Columns.Add("Data", typeof(DateTime));
            _dataTablePaginas.Columns.Add("Status", typeof(string));
            _dataTablePaginas.Columns.Add("Diretorio", typeof(string));

            GetDataBaseValues();
        }

        private DataRow NewRow()
        {
            return _dataTablePaginas.NewRow();
        }

        private void AddRow(DataRow row)
        {
            _dataTablePaginas.Rows.Add(row);
        }

        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        private void GetDataBaseValues()
        {
            DataBaseCliente cliente = new DataBaseCliente();
            cliente.ReadFromFile();

            foreach (Cliente dadosCliente in cliente.Clientes())
            {
                DataRow row = NewRow();
                row["Id"] = dadosCliente.Id;
                row["Nome"] = dadosCliente.Nome;
                row["Conteudo"] = dadosCliente.Conteudo;
                row["Data"] = dadosCliente.Data;
                row["Status"] = dadosCliente.Status;
                row["Diretorio"] = dadosCliente.Diretorio;

                AddRow(row);
            }
        }

        public DataTable ListaPaginas()
        {   
            return _dataTablePaginas;
        }

        public DataRow[] BuscarPorId(Guid id)
        {
            return _dataTablePaginas.Select("Id = '" + id.ToString() + "'");
        }

        public void Criar(Guid id, string nome, string conteudo, DateTime data, string status, string diretorio)
        {
            new DataBaseCliente().Criar(id, nome, conteudo, data, status, diretorio);
        }

        public void Alterar(Guid id, string nome, string conteudo, DateTime data, string status, string diretorio)
        {
            new DataBaseCliente().Alterar(id, nome, conteudo, data, status, diretorio);
        }

        public void Excluir(Guid id)
        {
            new DataBaseCliente().Excluir(id);
        }
    }
}