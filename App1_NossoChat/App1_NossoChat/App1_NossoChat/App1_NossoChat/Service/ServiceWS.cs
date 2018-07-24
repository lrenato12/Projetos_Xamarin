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

        public static bool InsertChat(Chat chat)
        {
            var url = $"{EnderecoBase}/chat";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage reposta = requisicao.PostAsync(url, param).GetAwaiter().GetResult();

            if (reposta.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        public static bool RenomearChat(Chat chat)
        {
            var url = $"{EnderecoBase}/chat/{chat.id}";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage reposta = requisicao.PutAsync(url, param).GetAwaiter().GetResult();

            if (reposta.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        public static bool DeleteChat(Chat chat)
        {
            var url = $"{EnderecoBase}/chat/delete/{chat.id}";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage reposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if (reposta.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        public static List<Mensagem> GetMensagensChat(Chat chat)
        {
            var url = $"{EnderecoBase}/chat/{chat.id}/msg";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage reposta = requisicao.GetAsync(url).GetAwaiter().GetResult();

            if (reposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = reposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (conteudo.Length > 2)
                {
                    var Lista = JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
                    return Lista;
                }

                return null;
            }

            return null;
        }

        public static bool InsertMensagem(Mensagem mensagem)
        {
            var url = $"{EnderecoBase}/chat/{mensagem.id_chat}/msg";
            
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("mensagem", mensagem.mensagem),
                new KeyValuePair<string, string>("id_usuario", mensagem.id_usuario.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage reposta = requisicao.PostAsync(url, param).GetAwaiter().GetResult();

            if (reposta.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        public static bool DeleteMensagem(Mensagem mensagem)
        {
            var url = $"{EnderecoBase}/chat/{mensagem.id_chat}/delete/{mensagem.id}";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage reposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if (reposta.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}