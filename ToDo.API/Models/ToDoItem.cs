using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.API.Models
{
    public class ToDoItem
    {
        //Attribute or Properties of To Do Item
        public int id { get; set; } //unique key of to do item
        public string title { get; set; } //the title of to do item
        public string description { get; set; } //the detail description of the to do item
        public DateTime expiryDate { get; set; } //the expiration date of the to do item
        public float percentCompleted { get; set; } //showing the progress of to do item in %
    }
}