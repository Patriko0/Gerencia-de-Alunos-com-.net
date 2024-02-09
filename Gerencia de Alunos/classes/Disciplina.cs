using System;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.classes
{
    public class Disciplina : Identity
    {
        public string name { get; set; }
        public int id { get; }

        private static int newId = 0;
        public int carg_hr;

        public Disciplina(string name, int carg_hr)
        {
            this.name = name;
            this.carg_hr = carg_hr;

            this.id = Disciplina.newId++;
        }

        public void update(string name, int? carg_hr)
        {
            this.name = name;
            this.carg_hr = carg_hr ?? this.carg_hr;
        }

        public void show() => Console.WriteLine("\nNome: {0}\nId: {1}\nCarga horaria: {2}\n", name, id, carg_hr);
        
    }
}
