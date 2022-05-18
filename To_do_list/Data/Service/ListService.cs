using To_do_list.Data.Model;
using To_do_list.Data.ViewModel;

namespace To_do_list.Data.Service
{
    public class ListService
    {
        private readonly AppDbContext _context;
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
            if (_user != null)
            {
                var _task = _context.TodoList.Where(n => n.Id == id && n.UserId == _user.Id).FirstOrDefault();
                if (_task == null)
                {

                }
                else if (!_task.IsCompleted)
                {
                    _task.IsCompleted = true;
                }
                else _task.IsCompleted = false;


                _context.SaveChanges();
            }
            

        }

        //get task of today
        public List<TodoList>? GetTodayTask(string username)
        {
                var _user = _context.Users.FirstOrDefault(n => n.UserName == username);
            if (_user != null)
            {
                var _task = _context.TodoList.Where(n => n.UserId == _user.Id && n.CreatedAt == DateTime.Today).ToList();
                if (_task != null)
                {
                    return _task;
                }
                else return null;
            }
            else return null;
            
                   
            
        }

        //delete task
        public string DeleteTask(int id,string username)
        {
            var _user = _context.Users.FirstOrDefault(n => n.UserName == username);
            if (_user != null)
            {
                var _task = _context.TodoList.Where(n => n.Id == id && n.UserId == _user.Id).FirstOrDefault();
                if (_task != null)
                {
                    _context.TodoList.Remove(_task);
                    _context.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "task not found";
                }
            }
            return "user not found";

        }
    }
}
