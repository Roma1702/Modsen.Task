# Modsen.Task
## Инструкция по запуску проекта
1. Открыть решение Modsen.Task. В решении открыть окно Package Manager Console.
2. Прописать в Package Manager Console следующие команды:
    1. cd ./IdentityServerApi
    2. dotnet ef migrations add -c PersistedGrantDbContext
    3. dotnet ef database update -c  PersistedGrantDbContext
    4. dotnet ef migrations add -c ConfigurationDbContext
    5. dotnet ef database update -c  ConfigurationDbContext
3. Запустить проект
4. При авторизации ввести следующие данные:  
username: admin@aaa.com  
password: !QAZ2wsx  
client_id: Api  
client_secret: client_secret