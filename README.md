# vkparser
Web-приложение, которое обращается к личной странице в соц. сети «ВКонтакте», получает оттуда 5 последних постов, считает в этих постах вхождение одинаковых букв (сравнение регистро-независимое). Результат сортируется по алфавиту, итоговые результаты подсчета записываются в БД (PostgresSQL). 

Информация о запуске подсчета и об его окончание должна записываться в лог файл на локальной файловой системе. В качестве UI для взаимодействия с backend частью используется Swagger.