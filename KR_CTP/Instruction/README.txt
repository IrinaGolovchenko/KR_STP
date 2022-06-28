Понадобится: 
1) Visual Studio Community 2019 или 2022
2) MySQL сервер
3) Insomnia rest api для тестов

Запуск:
1) Распаковать архив
2) открывать AirShipsTask2.sln
3) запустить

Тестирование: 

В Insomnia 

1) Get запрос: http://localhost:32930/api/AirShip/get/1 (получить объект с идентификатором 1, если он есть в таблице)
2) Get запрос: http://localhost:32930/api/AirShip/get/all получить все объекты, если они есть в таблице
3) Post запрос: http://localhost:32930/api/AirShip/add добавить объект

ПОРТЫ (32930) МОГУТ ОТЛИЧАТЬСЯ!!!!! 