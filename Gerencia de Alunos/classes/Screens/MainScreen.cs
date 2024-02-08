using System;

namespace Gerencia_de_Alunos.classes.Screens
{
    public class MainScreen:Screen
    {
        public MainScreen() {
            this.addAction(() => { Console.WriteLine("Hello World"); }, "Ola mundo");
        }
    }
}
