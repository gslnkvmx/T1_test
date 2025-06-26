# schoolAPI

## Запуск через Docker Compose

1. Соберите и запустите сервис и базу данных:

```sh
docker-compose up --build
```

2. API будет доступен по адресу: http://localhost:5000

3. Swagger UI: http://localhost:5000/swagger

## Миграции

Для применения миграций используйте:

```sh
docker-compose exec schoolapi dotnet ef database update
``` 