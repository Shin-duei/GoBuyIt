﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoBuyIt.ViewModel
{
          public class RelayCommand : ICommand
          {
                    Action<object> _executemethod;
                    Func<object, bool> _canexecutemethod;

                    public RelayCommand(Action<object> executemethod, Func<object, bool> canexecutemethod)
                    {
                              _executemethod = executemethod;
                              _canexecutemethod = canexecutemethod;
                    }

                    public bool CanExecute(object parameter)
                    {
                              if (_executemethod != null)
                              {
                                        return _canexecutemethod(parameter);
                              }
                              else
                              {
                                        return false;
                              }
                    }

                    public event EventHandler CanExecuteChanged
                    {
                              add { CommandManager.RequerySuggested += value; }
                              remove { CommandManager.RequerySuggested -= value; }
                    }

                    public void Execute(object parameter)
                    {
                              _executemethod(parameter);
                    }

                    public static bool CanExecuteMethod(object parameter)
                    {
                              return true;
                    }
          }
}
