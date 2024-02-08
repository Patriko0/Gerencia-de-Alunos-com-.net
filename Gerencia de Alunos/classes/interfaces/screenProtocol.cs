using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerencia_de_Alunos.classes.interfaces
{
    public interface screenProtocol
    {
        bool active { get; set; }
        List<string> actionsName { get; set; }
        Dictionary<int, Action> actions { get; set; }
        int qtsActions();
        void addAction(Action newAction, string name);
        void show();
        void showOptions();
    }
}
