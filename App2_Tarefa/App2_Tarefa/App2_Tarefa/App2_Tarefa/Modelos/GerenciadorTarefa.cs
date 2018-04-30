using System;
using System.Collections.Generic;
using System.Text;

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
        public void Deletar(Tarefa tarefa)
        {
            Lista = Listar();
            Lista.Remove(tarefa);
            SalvarNoProperties(Lista);
        }
        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listar();
            Lista.RemoveAt(index);
            Lista.Add(tarefa);
            SalvarNoProperties(Lista);
        }
        public List<Tarefa> Listar()
        {
            return ListarNoProperties();
        }
        private List<Tarefa> ListarNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
                return (List<Tarefa>)App.Current.Properties["Tarefas"];
            else
                return new List<Tarefa>();
        }
        private void SalvarNoProperties(List<Tarefa> Lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
                App.Current.Properties.Remove("Tarefas");

            App.Current.Properties.Add("Tarefas", Lista);
        }
    }
}