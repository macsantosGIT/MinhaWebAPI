using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhaWebAPI.Util;
using System.Data;

namespace MinhaWebAPI.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_cadastro { get; set; }
        public string Cpf_cnpj { get; set; }
        public string Data_nascimento { get; set; }
        public string Tipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public void RegistrarCliente()
        {
            DAL objDAL = new DAL();

            string sql = "insert into cliente (nome, data_cadastro, cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf) " +
                        $" values('{Nome}','{DateTime.Parse(Data_cadastro).ToString("yyyy/MM/dd")}','{Cpf_cnpj}','{DateTime.Parse(Data_nascimento).ToString("yyyy/MM/dd")}' " + 
                        $" ,'{Tipo}','{Telefone}','{Email}','{Cep}','{Logradouro}','{Numero}','{Bairro}','{Complemento}','{Cidade}','{Uf}' )";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void AtualizarCliente()
        {
            DAL objDAL = new DAL();

            string sql = "update cliente " +
                        $" set nome = '{Nome}', data_cadastro = '{DateTime.Parse(Data_cadastro).ToString("yyyy/MM/dd")}', " + 
                        $" cpf_cnpj = '{Cpf_cnpj}', data_nascimento = '{DateTime.Parse(Data_nascimento).ToString("yyyy/MM/dd")}', " +
                        $" tipo = '{Tipo}', telefone = '{Telefone}', email = '{Email}', cep = '{Cep}', logradouro = '{Logradouro}', "+
                        $" numero = '{Numero}', bairro = '{Bairro}', complemento = '{Complemento}', cidade = '{Cidade}', uf = '{Uf}' " +
                        $" where id = {Id}";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"delete from cliente where id = {id}";

            objDAL.ExecutarComandoSQL(sql);
        }

        public List<ClienteModel> Listagem()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;

            DAL objDAL = new DAL();

            string sql = "select * from cliente order by nome";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new ClienteModel()
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Nome = dados.Rows[i]["Nome"].ToString(),
                    Data_cadastro = DateTime.Parse(dados.Rows[i]["Data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                    Cpf_cnpj = dados.Rows[i]["Cpf_cnpj"].ToString(),
                    Data_nascimento = DateTime.Parse(dados.Rows[i]["Data_nascimento"].ToString()).ToString("dd/MM/yyyy"),
                    Tipo = dados.Rows[i]["Tipo"].ToString(),
                    Telefone = dados.Rows[i]["Telefone"].ToString(),
                    Email = dados.Rows[i]["Email"].ToString(),
                    Cep = dados.Rows[i]["Cep"].ToString(),
                    Logradouro = dados.Rows[i]["Logradouro"].ToString(),
                    Numero = dados.Rows[i]["Numero"].ToString(),
                    Bairro = dados.Rows[i]["Bairro"].ToString(),
                    Complemento = dados.Rows[i]["Complemento"].ToString(),
                    Cidade = dados.Rows[i]["Cidade"].ToString(),
                    Uf = dados.Rows[i]["Uf"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public ClienteModel RetornarCliente(int id)
        {
            ClienteModel item;

            DAL objDAL = new DAL();

            string sql = $"select * from cliente where id = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);

            item = new ClienteModel()
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Nome = dados.Rows[0]["Nome"].ToString(),
                Data_cadastro = DateTime.Parse(dados.Rows[0]["Data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                Cpf_cnpj = dados.Rows[0]["Cpf_cnpj"].ToString(),
                Data_nascimento = DateTime.Parse(dados.Rows[0]["Data_nascimento"].ToString()).ToString("dd/MM/yyyy"),
                Tipo = dados.Rows[0]["Tipo"].ToString(),
                Telefone = dados.Rows[0]["Telefone"].ToString(),
                Email = dados.Rows[0]["Email"].ToString(),
                Cep = dados.Rows[0]["Cep"].ToString(),
                Logradouro = dados.Rows[0]["Logradouro"].ToString(),
                Numero = dados.Rows[0]["Numero"].ToString(),
                Bairro = dados.Rows[0]["Bairro"].ToString(),
                Complemento = dados.Rows[0]["Complemento"].ToString(),
                Cidade = dados.Rows[0]["Cidade"].ToString(),
                Uf = dados.Rows[0]["Uf"].ToString()
            };

           return item;

        }

    }
}
