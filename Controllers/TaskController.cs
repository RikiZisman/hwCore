using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private List<Task> arr;
    public PizzaController()  
    {
        arr = new List<Task>
        {
            new Task { Id = 1, Name = "Regualr", IsOk = false},
            new Task { Id = 2, Name = "Special", IsOk = false},
            new Task { Id = 3, Name = "Vegan", IsOk = true},
        };
    }


    [HttpGet]
    public IEnumerable<Pizza> Get()
    {
        return arr;
    }
    
    [HttpGet("{id}")]
    public Pizza Get(int id)
    {
        return arr.FirstOrDefault(p => p.Id == id);
    }

        
    [HttpPost]
    public void Post(Pizza newPizza)
    {
        int max = arr.Max(p => p.Id);
        newPizza.Id = max + 1;
        arr.Add(newPizza);        
    }

}
