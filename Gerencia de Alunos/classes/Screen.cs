using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.classes
{
    public abstract class Screen : screenProtocol
    {
        public bool active { get; set; } = false;
        public List<string> actionsName { get; set; } = new List<string>();
        public Dictionary<int, Action> actions { get; set; } = new Dictionary<int, Action>();

        public int qtsActions() => actions.Count;
        public void addAction(Action newAction, string name) { this.actions.Add(this.qtsActions(), newAction); actionsName.Add(name); }

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
                    break;
                }

                actions[option]();

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
