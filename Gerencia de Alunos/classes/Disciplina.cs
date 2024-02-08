using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.classes
{
    public class Disciplina : Identity
    {
        public string name { get; set; }

        public int id { get; }

        public int carg_hr;

        public Disciplina(string name, int id, int carg_hr)
        {
            this.name = name;
            this.id = id;
            this.carg_hr = carg_hr;
        }

        public void update(string name, int? carg_hr)
        {
            this.name = name;
            this.carg_hr = carg_hr ?? this.carg_hr;
        }

        public void show() => Console.WriteLine("Nome: {0}\nCarga horaria: {1}", name, carg_hr);
        
    }
}
