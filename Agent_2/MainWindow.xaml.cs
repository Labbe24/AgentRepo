using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agent = AgentAssignment.Agent;

namespace Agent_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<AgentAssignment.Agent> listData = new ObservableCollection<AgentAssignment.Agent>();
        public MainWindow()
        {
            InitializeComponent();
            listData.Add(new AgentAssignment.Agent("007","James Bond","Assassination","UpperVolta"));
            listData.Add(new AgentAssignment.Agent("010", "Thomas Gammelby", "Blowjob", "Jens"));
            listData.Add(new AgentAssignment.Agent("005", "Andreas Støve", "Ganks", "Nexus"));
            this.DataContext = listData;
        }
    }
}
