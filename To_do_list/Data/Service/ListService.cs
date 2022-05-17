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

        public void AddList(ListVM list,string username)
        {
            var _user = _context.Users.FirstOrDefault(n => n.UserName == username);
            var _list = new TodoList()
            {
                Title = list.Title,
                WhatToDo = list.WhatToDo,
            };
            _context.TodoList.Add(_list);
            _list.UserId = _user?.Id;
            _list.CreatedAt = DateTime.Now;
            _list.IsCompleted = false;
            _context.SaveChanges();

        }
    }
}
