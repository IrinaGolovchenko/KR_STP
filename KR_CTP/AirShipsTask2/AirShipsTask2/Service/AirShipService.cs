using AirShipsTask2.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AirShipsTask2.Service
{
    /*
     CREATE TABLE `testdatabase`.`air_ship` (
          `id` INT NOT NULL AUTO_INCREMENT,
          `name` VARCHAR(45) NULL,
          `type` VARCHAR(45) NULL,
          UNIQUE INDEX `id_UNIQUE` (`id` ASC));
     */
    public class AirShipService
    {
        private MySqlConnection connection;

        public AirShipService(string connectionString)
        {
            // инициализируем объект для работы с БД строкой подключения
            this.connection = new MySqlConnection(connectionString);

            // Открываем соединение 
            this.connection.Open();
        }

        public void connect()
        {
            this.connection.Open();
        }

        // Получить одну запись по идентификатору например: SELECT * FROM testdatabase.air_ship WHERE id = 1
        public AirShip GetById(int id)
        {
            // Объект, который будем заполнять из БД
            var airShip = new AirShip();

            // Объект, который работает с БД
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM testdatabase.air_ship WHERE id = " + id.ToString(), this.connection);
            // Навстраиваем, что наша команда к БД текстовая (выше)
            cmd.CommandType = CommandType.Text;

            // Выполняем запрос
              MySqlDataReader reader = cmd.ExecuteReader();

            // Если есть результат...
            if (reader.Read())
            {
                // ... то запишем его в объект
                airShip = new AirShip();

                // читаем из колонки id
                airShip.Id = Int32.Parse(reader.GetString("id"));

                // читаем из колонки name
                airShip.Name = reader.GetString("name").ToString();
                // читаем из колонки type
                airShip.Type = reader.GetString("type").ToString();

            }

            return airShip;
        }

        /**
         * Возвращает самы последний идентификатор в БД - последняя запись
         */
        public int GetLastId()
        {
            int id = 0;

            MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", this.connection);
            cmd.CommandType = CommandType.Text;
            // Объект для подключения к БД

            MySqlDataReader reader = cmd.ExecuteReader();

            // Читаем результат
            if (reader.Read())
            {
                // Читаем идентификатор
                id = Int32.Parse(reader.GetString("LAST_INSERT_ID()"));
            }

            return id;
        }

        // Получить все записи: SELECT * FROM testdatabase.air_shis
        public List<AirShip> GetAll()
        {
            // Список, в который будем собирать все объекты
            var airShips = new List<AirShip>();
            // Сюда перезаписываем объект из новой строки
            var airShip = new AirShip();
            // Объект для подключения к БД
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM testdatabase.air_ship", this.connection);
            // сообщаем, что будем выполнять текстовый запрос, а не например процедуру
            cmd.CommandType = CommandType.Text;

            // Выполняем
            MySqlDataReader reader = cmd.ExecuteReader();

            // Читаем в таблице первую строку
            if (reader.Read())
            {
                // переиницализация объекта
                airShip = new AirShip();

                // Читаем идентификатор воздушного судна
                airShip.Id = Int32.Parse(reader.GetString("id"));

                // Читаем имя воздушного судна
                airShip.Name = reader.GetString("name").ToString();
                // Читаем тип воздушного судна
                airShip.Type = reader.GetString("type").ToString();

                // Добавляем воздушное судно в список
                airShips.Add(airShip);
            }

            // Возвращаем список
            return airShips;
        }

        // Добавить запись: INSERT INTO testdatabase.air_ship(name, type) VALUES ("boeing", "AirBus")s
        public int Add(AirShip airShip)
        {
            // Команда, которую будем выполнять
            var sqlText = "INSERT INTO testdatabase.air_ship (name, type) VALUES ( '" + airShip.Name + "' , '" + airShip.Type + "')";
            // Объект для подключения к БД
            MySqlCommand cmd = new MySqlCommand(sqlText, this.connection);
            // Выполнить!
            cmd.ExecuteNonQuery();

            // Отдать самый последний идентификатор
            return GetLastId();
        }
    }
}
