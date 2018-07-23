using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App1_NossoChat.Model;
using Newtonsoft.Json;

namespace App1_NossoChat.Service
{
    public class ServiceWS
    {
        private static string EnderecoBase = $"http://ws.spacedu.com.br/xf2018/rest/api";

        public static Usuario GetUsuario(Usuario usuario)
        {
            var url = $"{EnderecoBase}/usuario";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", usuario.nome),
                new KeyValuePair<string, string>("password", usuario.password)
            });
            //StringContent param = new StringContent($"?nome={usuario.nome}&password={usuario.password}");
                

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage reposta = requisicao.PostAsync(url, param).GetAwaiter().GetResult();

            if (reposta.StatusCode == HttpStatusCode.OK)
            {
                //TODO - Deserializar, retornar no metodo e salvar no login
            }

            return null;
        }

        public static List<Chat> GetChats()
        {
            var url = $"{EnderecoBase}/chats";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage reposta = requisicao.GetAsync(url).GetAwaiter().GetResult();

            if (reposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = reposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if(conteudo.Length > 2)
                {
                    var Lista = JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                    return Lista;
                }

                return null;                
            }

            return null;
        }
    }
}