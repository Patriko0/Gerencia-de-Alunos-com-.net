using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerencia_de_Alunos.classes
{
    public abstract class Screen
    {
        protected bool active = false;
        protected List<string> actionsName = new List<string>();
        private Dictionary<int, Action> actions = new Dictionary<int, Action>();

        protected int qtsActions() { return actions.Count; }
        protected void addAction(Action newAction, string name) { this.actions.Add(this.qtsActions(), newAction); actionsName.Add(name); }

        public void show()
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
                    continue;
                }

                actions[option]();

                Console.Write("\nPressione enter para continuar");
                Console.ReadLine();

            }
        }

        public void showOptions() {
            foreach(string name in this.actionsName)
            {
                Console.WriteLine(this.actionsName.IndexOf(name).ToString() + ". " + name);
            }
            Console.WriteLine((this.qtsActions()).ToString() + ". Sair\n");
        }


        
    }
}
