using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App2_Tarefa.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }

        public void Salvar(Tarefa tarefa)
        {
            Lista = Listar();
            Lista.Add(tarefa);
            SalvarNoProperties(Lista);
        }
        public void Deletar(int index)
        {
            Lista = Listar();
            Lista.RemoveAt(index);

            SalvarNoProperties(Lista);
        }
        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listar();
            Lista.RemoveAt(index);

            tarefa.DataFinalizacao = DateTime.Now;
            Lista.Add(tarefa);
            SalvarNoProperties(Lista);
        }
        public List<Tarefa> Listar()
        {
            return ListarNoProperties();
        }
        private void SalvarNoProperties(List<Tarefa> Lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
                App.Current.Properties.Remove("Tarefas");

            string JsonValue = JsonConvert.SerializeObject(Lista);
            App.Current.Properties.Add("Tarefas", JsonValue);
        }
        private List<Tarefa> ListarNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string JsonValue = (String)App.Current.Properties["Tarefas"];
                return JsonConvert.DeserializeObject<List<Tarefa>>(JsonValue);
                //return (List<Tarefa>)App.Current.Properties["Tarefas"];
            }
            else
                return new List<Tarefa>();
        }
    }
}