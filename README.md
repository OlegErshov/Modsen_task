# Modsen_task

Для того, чтобы запустить проект, нужно в настройках решения указать на одновременный запуск проекта Library.Api и IdentityServer. База данных создастся автоматически и заполнится тестовыми данными.

Пользователи:

id: "b391dd4d-fbda-46ed-a300-44d14facac99" UserName: "oleza" password: "1111" role: "User"

id: "e0dd19cf-ab64-40cf-adb3-2ea3bf5cb9cf" UserName: "ostrieKozerok" password: "7777" role: "Admin"

Роли:

id: "1" Name: "Admin"

id: "2" Name: "User"

UserName и password нужно использовать для авторизации через Swagger UI по url https://localhost:7132/swagger/index.html

Полный функционал WebApi имеет возможность тестирования через Swagger UI по utl https://localhost:7059/swagger/index.html

Так же работу приложения можно проверить через конечные точки:

Получение списка всех книг (роль не требуется) url https://localhost:7059/api/Book

Получение книги по её id (роль не требуется) url https://localhost:7059/api/Book/{id}

Получение книги по её ISBN (роль не требуется) url https://localhost:7059/api/Book/isbn/{isbn}

Все остальные методы можно тестировать через Swagger UI url https://localhost:7059/swagger/index.html

Для всез запросов, кроме Get любых видов, нужно быть залогиненным под ролью Admin.

