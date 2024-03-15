using AuthApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult> Create(Student student)
        {
            //var emp = JsonConvert.DeserializeObject<Employee>(JsonConvert.SerializeObject(student));
            object emp =  Converter.ConvertToObjectType(student) as Employee;
            return Ok(emp);
        }
    }
}


public class Converter
{
    public static object ConvertToObjectType<T>(T obj) where T : class
    {
        // If the object is already of type object, just return it
        if (obj is object)
            return obj;

        // Otherwise, create a new instance of object and copy properties
        object newObj = new object();

        // Copy properties from obj to newObj
        var properties = typeof(T).GetProperties();
        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj);
            prop.SetValue(newObj, value);
        }

        return newObj;
    }
}