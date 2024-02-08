using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.classes
{
    public abstract class Screen: screenProtocol
    {
        protected bool active = false;
        protected List<string> actionsName = new List<string>();
        protected Dictionary<int, Action> actions = new Dictionary<int, Action>();

        protected override int qtsActions() => actions.Count;
        protected override void addAction(Action newAction, string name) { this.actions.Add(this.qtsActions(), newAction); actionsName.Add(name); }

        public override void show()
        {
            int option;
            active = true;

            while (active) {
                Console.Clear();
                this.showOptions();
                Console.WriteLine("Digite uma opção: ");

                option = int.Parse(Console.ReadLine());
                if(option >= this.qtsActions()) {
                    active = false;
                    break;
                }

                actions[option]();

            }
        }

        public override void showOptions() {
            foreach(string name in this.actionsName)
            {
                Console.WriteLine(this.actionsName.IndexOf(name).ToString() + ". " + name);
            }
            Console.WriteLine((this.qtsActions()).ToString() + ". Sair\n");
        }


        
    }
}
