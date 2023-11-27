# Система тестирования
, создаваемая в рамках хакатона  
Стек:  
- .NET 7;  
- C# 11;  
- Angular 15;
- nodejs 18;  
- PostgreSql 15
### Порядок запуска 
**Вариант 1**
1. Открыть проект в visual studio или rider, чтобы можно было запустить через среду.
   Далее во встроенном терминале  
2. cd ./WebUI/ClientApp  
3. npm i  
4. Запустить конфигурацию Ancient:WebUI
  
**Вариант 2**
1. Открыть в двух окнах консоли папку с проектом  
2. В первом:  
  2.1 cd ./WebUI/ClientApp  
  2.2 npm i  
  2.3 ng serve  
3. Во втором: dotnet run -p ./WebUI
  
   <ins>В обоих случаях подождать, пока пройдет экран подключения прокси</ins>

### Описание прогресса
Из всей системы реализован только CRUD с вопросами, и тот сейчас крашится с ошибкой. Возможно, исправим.  
Больше ничего нет.
