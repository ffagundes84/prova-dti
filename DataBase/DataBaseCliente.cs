using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataBase.Entities;

namespace DataBase
{
    public class DataBaseCliente
    {        
        private string _filePath = @"C:\Temp\dadosProcesso.json";

        private List<Cliente> _lstDataBaseClientes = new List<Cliente>();

        public DataBaseCliente() { }

        public void ReadFromFile()
        {
            if (!File.Exists(_filePath))
                WriteInFile();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    Cliente cliente = JsonConvert.DeserializeObject<Cliente>(linha);

                    if (_lstDataBaseClientes.FirstOrDefault(x => x.Id == cliente.Id) == null)
                    {
                        _lstDataBaseClientes.Add(cliente);
                    }
                }
            }
        }

        private void WriteInFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, false))
                {
                    string buffer;
                    foreach (Cliente cliente in _lstDataBaseClientes)
                    {
                        buffer = JsonConvert.SerializeObject(cliente);
                        writer.WriteLine(buffer);
                    }
                    writer.Close();
                }

            }
            catch
            {
                throw new ApplicationException("Favor criar o diretório C:\\Temp\\");
            }
        }

        public List<Cliente> Clientes()
        {
            return _lstDataBaseClientes;
        }

        private Cliente ObterPorId(Guid id)
        {
            return _lstDataBaseClientes.FirstOrDefault(x => x.Id == id);
        }

        internal void Criar(Guid id, string nome, string conteudo, DateTime data, string status, string diretorio)
        {
            Cliente cliente = new Cliente
            {
                Id = id,
                Nome = nome,
                Conteudo = conteudo,
                Data = data,
                Status = status,
                Diretorio = diretorio
            };

            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                string buffer = JsonConvert.SerializeObject(cliente);
                writer.WriteLine(buffer);
                writer.Close();
            }
        }

        internal void Alterar(Guid id, string nome, string conteudo, DateTime data, string status, string diretorio)
        {
            ReadFromFile();
            Cliente alterado = ObterPorId(id);

            if (alterado == null)
                return;

            alterado.Id = id;
            alterado.Nome = nome;
            alterado.Conteudo = conteudo;
            alterado.Data = data;
            alterado.Status = status;
            alterado.Diretorio = diretorio;

            WriteInFile();
        }

        public void Excluir(Guid id)
        {
            ReadFromFile();
            Cliente remover = ObterPorId(id);

            if (remover == null)
                return;

            _lstDataBaseClientes.Remove(remover);
            WriteInFile();
        }
    }
}
