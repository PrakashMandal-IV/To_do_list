namespace To_do_list.Data.Model
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string WhatToDo { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int? UserId { get; set; }

    }
}
