using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ToDoList.Core
{
    public class WorkTasksPageViewModel : BaseViewModel
    {
        public ObservableCollection<WorkTaskViewModel> WorkTaskList { get; set; } = new ObservableCollection<WorkTaskViewModel>();

        public string NewWorkTaskTitle { get; set; }

        public string NewWorkTaskDescription { get; set; }

        public ICommand AddNewTaskCommand { get; set; }

        public ICommand DeleteSelectedTaskCommand { get; set; }

        public WorkTasksPageViewModel()
        {
            AddNewTaskCommand = new RelayCommand(AddNewTask);
            DeleteSelectedTaskCommand = new RelayCommand(DeleteSelectedTasks);
        }

        private void AddNewTask()
        {
            var newTask = new WorkTaskViewModel
            {
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreatedDate = DateTime.Now,
            };

            WorkTaskList.Add(newTask);

            NewWorkTaskTitle = string.Empty;
            NewWorkTaskDescription = string.Empty;

            OnPropertyChanged(nameof(NewWorkTaskTitle));
            OnPropertyChanged(nameof(NewWorkTaskDescription));
        }


        void DeleteSelectedTasks()
        {
            var selectedTasks = WorkTaskList.Where(x => x.IsSelected).ToList();

            foreach (var task in selectedTasks)
            {
                WorkTaskList.Remove(task);
            }
        }
    }
}
