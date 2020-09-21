using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Agent = AgentAssignment.Agent;

namespace Agent_2.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        ObservableCollection<AgentAssignment.Agent> agents;

        public MainWindowViewModel()
        {
            agents = new ObservableCollection<AgentAssignment.Agent>
            {
                new AgentAssignment.Agent("001", "Nina", "Assassination", "UpperVolta"),
                new AgentAssignment.Agent("007", "James Bond", "Martinis", "North Korea")
            };
            CurrentAgent = agents[0];
        }

        #region Properties

        public ObservableCollection<AgentAssignment.Agent> Agents
        {
            get
            {
                return agents;
            }
        }

        AgentAssignment.Agent currentAgent = null;

        public AgentAssignment.Agent CurrentAgent
        {
            get { return currentAgent; }
            set
            {
                SetProperty(ref currentAgent, value);
            }
        }

        int currentIndex = -1;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                SetProperty(ref currentIndex, value);
            }
        }

        #endregion

        #region Commands
        ICommand _PreviusCommand;
        public ICommand PreviusCommand
        {
            get
            {
                return _PreviusCommand ??
                (_PreviusCommand = new DelegateCommand(
                 PreviusCommandExecute, PreviusCommandCanExecute)
                 .ObservesProperty(() => CurrentIndex));
            }
        }

        private void PreviusCommandExecute()
        {
            --CurrentIndex;
        }

        private bool PreviusCommandCanExecute()
        {
            return CurrentIndex > 0;
        }

        ICommand _nextCommand;
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new DelegateCommand(
                       () => ++CurrentIndex,
                       () => CurrentIndex < (Agents.Count - 1)).ObservesProperty(() => CurrentIndex));
            }
        }

        ICommand _newCommand;
        public ICommand AddNewAgentCommand
        {
            get
            {
                return _newCommand ?? (_newCommand = new DelegateCommand(() =>
                {
                    Agents.Add(new AgentAssignment.Agent());
                    CurrentIndex = Agents.Count - 1;
                }));
            }
        }

        ICommand _deleteCommand;
        public ICommand DeleteAgentCommand => _deleteCommand ?? (_deleteCommand =
            new DelegateCommand(DeleteAgent, DeleteAgent_CanExecute)
                    .ObservesProperty(() => CurrentIndex));

        private void DeleteAgent()
        {
            Agents.RemoveAt(CurrentIndex);
            RaisePropertyChanged("Count");
        }

        private bool DeleteAgent_CanExecute()
        {
            if (Agents.Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;
        }

        ICommand _closeAppCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                return _closeAppCommand ?? (_closeAppCommand = new DelegateCommand(() =>
                {
                    App.Current.MainWindow.Close();
                }));
            }
        }
        #endregion

    }
}
