using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.classes
{
    public class Curso : Identity
    {
        public string name { get; set; }
        public int id { get; }
        readonly private List<Disciplina> disciplinas = new List<Disciplina>();

        public Curso (string name, int id, Disciplina disciplina)
        {
            this.name = name;
            this.id = id;
            this.disciplinas.Add(disciplina);
        }

        public List<string> getDisciplinas()
        {
            List<string> disciplinas = new List<string>();

            foreach(Disciplina disc in this.disciplinas) {
                disciplinas.Add(disc.name);
            }

            return disciplinas;
        }

        public void addDisciplina(Disciplina disc)
        {
            disciplinas.Add(disc);
        }


        public void removeDisciplina(int id)
        {
            List<Disciplina> disc = this.disciplinas.Where(item => item.id == id).ToList();
            disciplinas.Remove(disc[0]);
        }

        public void show() => Console.WriteLine("Nome: {0}", name);
    }
}
