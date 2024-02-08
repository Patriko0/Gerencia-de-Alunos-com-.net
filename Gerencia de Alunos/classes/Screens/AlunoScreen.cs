using System;
using Gerencia_de_Alunos.services;

namespace Gerencia_de_Alunos.classes.Screens
{
    public class AlunoScreen:Screen
    {
        public AlunoScreen() {
            this.addAction(new Action(() => { Console.WriteLine("Alunos..."); Enter.pressEnter(); }), "Mostrar alunos");
            this.addAction(new Action(() => { Console.WriteLine("Criando alunos..."); Enter.pressEnter(); }), "Criar alunos");
            this.addAction(new Action(() => { Console.WriteLine("Editando aluno..."); Enter.pressEnter(); }), "Editar alunos");
            this.addAction(new Action(() => { Console.WriteLine("Deletando aluno..."); Enter.pressEnter(); }), "Deletar alunos");
        }
    }
}
