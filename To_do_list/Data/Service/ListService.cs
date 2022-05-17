using To_do_list.Data.Model;
using To_do_list.Data.ViewModel;

namespace To_do_list.Data.Service
{
    public class ListService
    {
        private AppDbContext _context;
        public ListService(AppDbContext context)
        {
            _context = context;
        }
        //Add task
        public void AddToList(ListVM list, string username)
        {
            var _user = _context.Users.FirstOrDefault(n => n.UserName == username);
            var _list = new TodoList()
            {
                Title = list.Title,
                WhatToDo = list.WhatToDo,
            };
            _context.TodoList.Add(_list);
            _list.UserId = _user?.Id;
            _list.CreatedAt = DateTime.Today;
            _list.IsCompleted = false;
            _context.SaveChanges();
        }

        //Update status
        public void UpdateStatus(int id,string username)
        {
            var _user = _context.Users.FirstOrDefault(n => n.UserName == username);
            var _task = _context.TodoList.FirstOrDefault(n => n.Id == id&& n.Id == _user.Id);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (!_task.IsCompleted)
            {
                _task.IsCompleted = true;

            }
            else _task.IsCompleted = false;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _context.SaveChanges();

        }

        //get task of today
        public List<TodoList> GetTodayTask(string username)
        {
            var _user = _context.Users.FirstOrDefault(n => n.UserName == username);
                var _task = _context.TodoList.Where(n => n.UserId == _user.Id && n.CreatedAt == DateTime.Today).ToList();
                return _task;      
            
        }

        //delete task
        public void DeleteTask(int id,string username)
        {
            var _user = _context.Users.FirstOrDefault(n => n.UserName == username);
            var _task = _context.TodoList.FirstOrDefault(n => n.Id == id && n.UserId == _user.Id);
            if (_task != null)
            {
                _context.TodoList.Remove(_task);
            }
        }
    }
}
