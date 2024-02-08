using System;
using Gerencia_de_Alunos.services;

namespace Gerencia_de_Alunos.classes.Screens
{
    public class DisciplinaScreen:Screen
    {
        public DisciplinaScreen() {
            this.addAction(new Action(() => { Console.WriteLine("Disciplinas..."); Enter.pressEnter(); }), "Mostrar disciplinas");
            this.addAction(new Action(() => { Console.WriteLine("Criando disciplinas..."); Enter.pressEnter(); }), "Criar disciplinas");
            this.addAction(new Action(() => { Console.WriteLine("Editando disciplina..."); Enter.pressEnter(); }), "Editar disciplinas");
            this.addAction(new Action(() => { Console.WriteLine("Deletando disciplina..."); Enter.pressEnter(); }), "Deletar disciplinas");
        }
    }
}
