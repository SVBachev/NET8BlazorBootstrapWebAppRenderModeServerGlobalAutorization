OWL VMS - проект для души =) А еще для записи и просмотра камер.

Данный проект развиваю в свободное время, для изучения актуальных технологий.

Описание задачи:
  Сейчас программное обеспечение для видеонаблюдения, по моему субъективному мнению, имеет один или несколько следующих недостатков:
  
  1) Цена (большинство решений платные и неоправданно дорогие)
  2) Сложность настройки
  3) Требования к системе
  4) Ограничено количество камер

В OWL VMS я хочу их все решить.

Если кто-то хочет поучаствовать в проекте или имеет пожелания/предложения
то можете отправить их на Email: s.v.bachev@gmail.com

В данном проекте реализовано:
1) Использование .net 9 совместно с Blazor Server и Razor Pages
2) Использование Blazor bootstrap
3) Использование авторизации через Active Directory

В планах реализации:
1) Подключение к Postgresql для хранения настроек
2) Механизм авторизации через Postgresql
3) Сервис для записи архива камер (RTSP поток)
4) Сервис для воспроизведения видео через SignalR и/или WebRTC
5) Настройка потоков

P.S. я знаю, что в этот репозиторий могут попасть данные для подключения к базе данных, другим серверам или что-то подобное. Я намеренно не буду их удалять (все сервера за NAT и используются только в целях тестирования). Так как считаю, что это может помочь тем, кто будет изучать этот код, а особенно тем кто не знаком с .net 9 Blazor Server или другими используемыми тут технологиями.


OWL VMS is a project for the soul =) And also for recording and viewing cameras.

I develop this project in my free time to study current technologies.

Task description:
  Currently, video surveillance software, in my subjective opinion, has one or more of the following disadvantages:

1) Price (most solutions are paid and unreasonably expensive)
2) Complexity of configuration
  3) System requirements
  4) The number of cameras is limited

In OWL VMS, I want to solve them all.

If someone wants to participate in the project or has suggestions/suggestions
, you can send them by Email: s.v.bachev@gmail.com

This project has implemented:
1) Usage .net 9 in conjunction with Blazor Server and Razor Pages
2) Using Blazor bootstrap
3) Using authorization via Active Directory

In the implementation plans:
1) Connect to Postgresql to store settings
2) Authorization mechanism via Postgresql
3) Camera archive recording service (RTSP stream)
4) Video playback service via SignalR and/or WebRTC
5) Setting up streams

P.S. I know that this repository may contain data for connecting to a database, other servers, or something similar. I will intentionally not delete them (all servers are behind NAT and are used only for testing purposes). Because I think it can help those who will study this code, and especially those who are not familiar with .net 9 Blazor Server or other technologies used here.
