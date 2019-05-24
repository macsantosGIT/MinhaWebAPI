using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebAPI.Util
{
    public class Autenticacao
    {
        public static string TOKEN = "231sfa493nnajlf90390snj0sf";
        public static string FALHA_AUTENTICACAO = "Falha na Autenticação... O Token informado é inválido!";
        IHttpContextAccessor contextAcessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAcessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string TokenRecebido = contextAcessor.HttpContext.Request.Headers["Token"].ToString();
                if (String.Equals(TOKEN, TokenRecebido) == false)
                {
                    throw new Exception(FALHA_AUTENTICACAO);
                }
            }
            catch
            {
                throw new Exception(FALHA_AUTENTICACAO); 
            }
        }
    }
}
