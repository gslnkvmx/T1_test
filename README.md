# schoolAPI

## Инструкция по запуску 

1. Клонируйте репозиторий:

```sh
git clone https://github.com/gslnkvmx/T1_test.git
cd T1_test
```

2. Соберите и запустите сервисы:

```sh
docker-compose up --build
docker-compose exec schoolapi dotnet ef database update
```

3. После запуска:
   - API будет доступен по адресу: http://localhost:5276
   - Swagger UI: http://localhost:5276/swagger/index.html
