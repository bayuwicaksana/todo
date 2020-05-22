using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        ToDoContext db = new ToDoContext(); //declaration of to do database context that will be used by all methods under this class
        OutputModel output = new OutputModel(); //declaraion of output model that will be used by all methods under this class

        // GET api/values : to get all todo's
        [HttpGet]
        public OutputModel Get()
        {
            try {
                var items = db.TblToDo.Select(p => p);
                output.status = "success";
                output.data = items;
                output.message = "";
            }
            catch (Exception ex)
            {
                output.status = "error";
                output.message = ex.Message;
                output.data = null;
            }
            return output;
        }

        // GET api/values/5 : to get specific to do
        [HttpGet("{id}")]
        public OutputModel Get(int id)
        {
           try {
            var item = db.TblToDo.SingleOrDefault(p=>p.id.Equals(id));
            output.status = "success";
            output.data = item;
            output.message = "";
            }
            catch (Exception ex)
            {
                output.status = "error";
                output.message = ex.Message;
                output.data = null;
            }
            return output;
        }

        // POST api/values : to create to do
        [HttpPost]
        public OutputModel Post([FromBody]ToDoItem item)
        {
           try {
                if(ModelState.IsValid){
                    db.Add(item);
                    db.SaveChanges();
                    output.status = "success";
                    output.data = item;
                    output.message = "Data Baru Berhasil Disimpan";
                } else {
                    output.status = "error";
                    output.message = "Data Baru Gagal Disimpan";
                    output.data = null;
                }
            }
            catch (Exception ex)
            {
                output.status = "error";
                output.message = ex.Message;
                output.data = null;
            }
            return output;
        }

        // PUT api/values/5 : to update to do 
        [HttpPut("{id}")]
        public OutputModel Put(int id, [FromBody]ToDoItem item)
        {
           try {
                if(ModelState.IsValid){
                    var currItem = db.TblToDo.SingleOrDefault(p=>p.id.Equals(id));
                    currItem.title = item.title;
                    currItem.description = item.description;
                    currItem.expiryDate = item.expiryDate;
                    currItem.percentCompleted = item.percentCompleted;
                    db.Update(currItem);
                    db.SaveChanges();
                    output.status = "success";
                    output.data = currItem;
                    output.message = "Data Berhasil Diubah";
                } else {
                    output.status = "error";
                    output.message = "Data Gagal Diubah";
                    output.data = null;
                }
            }
            catch (Exception ex)
            {
                output.status = "error";
                output.message = ex.Message;
                output.data = null;
            }
            return output;
        }

        // DELETE api/values/5 : to delete to do
        [HttpDelete("{id}")]
        public OutputModel Delete(int id)
        {
           try {
                if(ModelState.IsValid)
                {
                    var item = db.TblToDo.Find(id);
                    db.TblToDo.Remove(item);
                    db.SaveChanges();
                    output.status = "success";
                    output.data = item;
                    output.message = "Data Berhasil Dihapus";
                } else {
                    output.status = "error";
                    output.message = "Data Gagal Dihapus";
                    output.data = null;
                }
            }
            catch (Exception ex)
            {
                output.status = "error";
                output.message = ex.Message;
                output.data = null;
            }
            return output;
    }
    }
}
