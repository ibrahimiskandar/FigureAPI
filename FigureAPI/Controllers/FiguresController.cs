using FigureAPI.Data;
using FigureAPI.Models;
using FigureAPI.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FigureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiguresController : ControllerBase
    {
        const string path = @"D:\Figure\figures.json";




        // GET: api/<FiguresController>
        [HttpGet]
        public async Task<IActionResult> GetFigures()
        {
            if (System.IO.File.Exists(path))
            {
                List<Figure> figures = new();
                using (StreamReader sr = new(path))
                {
                    string json = await sr.ReadToEndAsync();
                    figures = await Task.Run(() => JsonConvert.DeserializeObject<List<Figure>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    }));
                }

                return Ok(figures);
            }
            return NotFound();
        }

        // GET api/<FiguresController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFigure(int id)
        {
            try
            {

                List<Figure> figures = new();
                if (System.IO.File.Exists(path))
                {
                    using (StreamReader sr = new(path))
                    {
                        string json = await sr.ReadToEndAsync();
                        figures = JsonConvert.DeserializeObject<List<Figure>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects
                        });
                    }
                }
                Figure figure = figures.Find(x => x.Id == id);
                if(figure == null)
                {
                    return NotFound();
                }
                return Ok(figure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // POST api/<FiguresController>

        [HttpPost("AddFigure")]
        public async Task<IActionResult> AddFigure(FigureRequestModel requestModel)
        {
            try
            {

                List<Figure> figures = new();
                if (System.IO.File.Exists(path))
                {
                    using (StreamReader sr = new(path))
                    {
                        string json = await sr.ReadToEndAsync();
                        figures = JsonConvert.DeserializeObject<List<Figure>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects
                        });
                    }
                }
                
                switch (requestModel.Points.Count)
                {
                    case 2:
                        Circle circle = new(requestModel.Points);
                        figures.Add(circle);
                        path.WriteJson(figures);
                        return Ok($"{circle.GetType().Name} added successfuly");
                    case 4:
                        Rectangle rectangle = new(requestModel.Points);
                        figures.Add(rectangle);
                        path.WriteJson(figures);
                        return Ok($"{rectangle.GetType().Name} added successfuly");
                    default:
                        return BadRequest("The program doesnt contain model for that count of figure");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // PUT api/<FiguresController>/5
        [HttpPut("RotateFigure/{id}")]
        public async Task<IActionResult> RotateFigure(int id, double angle)
        {
            try
            {

                List<Figure> figures = new();
                if (System.IO.File.Exists(path))
                {
                    using (StreamReader sr = new(path))
                    {
                        string json = await sr.ReadToEndAsync();
                        figures = JsonConvert.DeserializeObject<List<Figure>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects
                        });
                    }
                }
                Figure figure = figures.Find(x => x.Id == id);
                if (figure == null)
                {
                    return NotFound();
                }
                figure.RotateFigure(angle);
                path.WriteJson(figures);
                return Ok(figure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("ScaleFigure/{id}")]
        public async Task<IActionResult> ScaleFigure(int id, double scale)
        {
            try
            {

                List<Figure> figures = new();
                if (System.IO.File.Exists(path))
                {
                    using (StreamReader sr = new(path))
                    {
                        string json = await sr.ReadToEndAsync();
                        figures = JsonConvert.DeserializeObject<List<Figure>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects
                        });
                    }
                }
                Figure figure = figures.Find(x => x.Id == id);
                if (figure == null)
                {
                    return NotFound();
                }
                figure.Scale(scale);
                path.WriteJson(figures);
                return Ok(figure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("MoveFigure/{id}")]
        public async Task<IActionResult> MoveFigure(int id, double x, double y)
        {
            try
            {

                List<Figure> figures = new();
                if (System.IO.File.Exists(path))
                {
                    using (StreamReader sr = new(path))
                    {
                        string json = await sr.ReadToEndAsync();
                        figures = JsonConvert.DeserializeObject<List<Figure>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects
                        });
                    }
                }
                Figure figure = figures.Find(x => x.Id == id);
                if (figure == null)
                {
                    return NotFound();
                }
                figure.MoveFigure(x, y);
                path.WriteJson(figures);
                return Ok(figure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // DELETE api/<FiguresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                List<Figure> figures = new();
                if (System.IO.File.Exists(path))
                {
                    using (StreamReader sr = new(path))
                    {
                        string json = await sr.ReadToEndAsync();
                        figures = JsonConvert.DeserializeObject<List<Figure>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects
                        });
                    }
                }
                Figure figure = figures.Find(x => x.Id == id);
                if (figure == null)
                {
                    return NotFound();
                }figures.Remove(figure);
                path.WriteJson(figures);
                return Ok("Figure Removed successfuly");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
