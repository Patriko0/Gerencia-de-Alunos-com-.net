using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerencia_de_Alunos.classes.interfaces
{
    abstract class Screen
    {
        protected bool active = false;
        protected Dictionary<int, Action> actions;
        protected List<string> actionsName;

        protected int qtsActions() { return actions.Count; }
        protected void addAction(Action newAction, string name) { this.actions.Add(this.qtsActions(), newAction); actionsName.Add(name); }

        public void show()
        {
            int option;
            while (active) {
                Console.Clear();
                this.showOptions();
                Console.WriteLine("Digite uma opção: ");

                option = Console.Read();
                if(option >= this.qtsActions() + 1) {
                    active = false;
                    continue;
                }

                actions[option]();

            }
        }

        public void showOptions() {
            foreach(string name in this.actionsName)
            {
                Console.WriteLine(this.actionsName.IndexOf(name).ToString() + ". " + name);
            }
            Console.WriteLine((this.qtsActions() + 1).ToString() + ". Sair");
        }


        
    }
}
