using System;
using System.Xml.Serialization;
using Gerencia_de_Alunos.db;
using Gerencia_de_Alunos.services;

namespace Gerencia_de_Alunos.classes.Screens
{
    public class DisciplinaScreen:Screen
    {
        private static DisciplinasDB disciplinas = DisciplinasDB.connect();
        public DisciplinaScreen() {
            this.addAction(new Action(() => { read();    }), "Mostrar disciplinas");
            this.addAction(new Action(() => { create();  }), "Criar disciplina");
            this.addAction(new Action(() => { update();  }), "Editar disciplinas");
            this.addAction(new Action(() => { delete();  }), "Deletar disciplinas");
        }

        private void create()
        {
            Console.WriteLine("\nEscreva o nome da disciplina: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nEscreva a carga horaria da disciplina: ");
            int carg_hr = int.Parse(Console.ReadLine());
            disciplinas.store(new {name, carg_hr});

            Console.WriteLine("\nDisciplina salva!");
            Enter.pressEnter();
        }

        private void read()
        {
            disciplinas.show(); 
            Enter.pressEnter();
        }

        private void update()
        {
            Console.WriteLine("\nDigite o id da disciplina que deseja modificar: ");
            int id = int.Parse(Console.ReadLine());

            if (!this.search(id)) return;

            Console.WriteLine("\nDigite o novo nome da disciplina: ");
            string newName = Console.ReadLine();
            Console.WriteLine("\nDigite a nova carga horaria (Opcional)");

            int newCargHr;

            if (!int.TryParse(Console.ReadLine(), out newCargHr)) disciplinas.update(id, new {newName, newCargHr});
            else disciplinas.update(id, new {newName, newCargHr});

            Console.WriteLine("\nDisciplina modificada!");
            Enter.pressEnter();
        }

        private void delete()
        {
            Console.WriteLine("\nDigite o id da disciplina que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            if (!this.search(id)) return;
            disciplinas.delete(id);

            Console.WriteLine("\nDisciplina deletada!");
            Enter.pressEnter();
        }

        private bool search(int id)
        {
            if (!disciplinas.find(id))
            {
                Enter.pressEnter();
                return false;
            }
            return true;
        }

    }
}
