using Microsoft.AspNetCore.Mvc;

public class DemoController: Controller
{
    [HttpGet, Route("api/hello/{name}")]
    public string SayHello(string name) {
        return $"Hello {name}";
    }
}