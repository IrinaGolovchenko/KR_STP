using AirShipsTask2.Model;
using AirShipsTask2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirShipsTask2.Controllers
{


    // путь должен содержать: /api/AirShip/
    // Например: http://localhost:32930/api/AirShip/get/1
    [Route("api/[controller]")]
    [ApiController]
    public class AirShipController : ControllerBase
    {
        private AirShipService service;

        public AirShipController(IConfiguration config)
        {
            // Строка подключения к базе данных 
            // адрес: 127.0.0.1
            // БД: testdatabase
            // Порт: 3306
            // логин: root
            // пароль: 1234
            this.service = new AirShipService("datasource=127.0.0.1;Initial Catalog=testdatabase;port=3306;username=root;password=1234;SSL Mode=none");
        }

        // Получить по идентификатору
        // нужен примерно такой запрос (порт может меняться!!!!)
        // http://localhost:32930/api/AirShip/get/1
        [HttpGet("get/{id}")]
        public AirShip GetById([FromRoute] int id)
        {
            return this.service.GetById(id);
        }

        // Получить все объекты
        // нужен примерно такой запрос (порт может меняться!!!!)
        // http://localhost:32930/api/AirShip/get/all
        [HttpGet("get/all")]
        public List<AirShip> GetAll()
        {
            return this.service.GetAll();
        }

        // Добавить объект (в теле запроса объект Json)
        // Например:
        //
        // {
	    //   "id": 1,
	    //   "name": "boeing",
	    //   "type": "AirBus"
        // }
        //

    // нужен примерно такой запрос (порт может меняться!!!!)
    // http://localhost:32930/api/AirShip/add
    [HttpPost("add")]
        public int Add(AirShip airShip)
        {
            return this.service.Add(airShip);
        }
    }
}
