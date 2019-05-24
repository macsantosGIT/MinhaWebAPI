using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoCliente.Util;
using Newtonsoft.Json;

namespace AplicacaoCliente.Models
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

        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> retorno = new List<ClienteModel>();
            string json = WebAPI.RequestGET("listagem", string.Empty);
            retorno = JsonConvert.DeserializeObject<List<ClienteModel>>(json);
            return retorno;
        }

        public ClienteModel Carregar(int? id)
        {
            ClienteModel retorno = new ClienteModel();
            string json = WebAPI.RequestGET("cliente", id.ToString());
            retorno = JsonConvert.DeserializeObject<ClienteModel>(json);
            return retorno;
        }

        public void Inserir()
        {
            string jsonData = JsonConvert.SerializeObject(this);
            string json = string.Empty;

            if(Id == 0)
            {
                WebAPI.RequestPOST("registrarcliente", jsonData);
            }
            else
            {
                WebAPI.RequestPUT("atualizar/" + Id.ToString(), jsonData);
            }
            
        }

        public void Excluir(int id)
        {
            //ClienteModel retorno = new ClienteModel();
            string json = WebAPI.RequestDELETE("excluir", id.ToString());
            //retorno = JsonConvert.DeserializeObject<ClienteModel>(json);
            //return retorno;
        }
    }
}
