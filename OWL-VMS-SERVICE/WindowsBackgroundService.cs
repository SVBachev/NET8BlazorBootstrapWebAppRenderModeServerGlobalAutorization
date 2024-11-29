using System;
using System.Diagnostics;
using System.Threading;

namespace OWL_VMS_SERVICE
{
    public class WindowsBackgroundService : BackgroundService
    {
        private readonly ILogger<WindowsBackgroundService> _logger;

        public WindowsBackgroundService(ILogger<WindowsBackgroundService> logger)
        {
            // Системный логгер (на случай необработанных ошибок, пишет в системный журнал)
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                // Создайте экземпляр EventLog
                EventLog myLog = new EventLog();

                // Создаём источник, если он еще не существует.
                if (!EventLog.SourceExists("OWL-VMS"))
                {

                    // Источник журнала событий не следует создавать и сразу использовать.
                    // Для включения источника существует время задержки, его необходимо создать
                    // перед выполнением приложения, использующего исходный код.
                    // Выполните этот пример второй раз, чтобы использовать новый источник.
                    EventLog.CreateEventSource("OWL-VMS", "OWL-VMS-LOG");

                    // Источник создан.  Выйдите из приложения, чтобы разрешить его регистрацию.
                    // Чтобы система управления службами Windows могла использовать настроенные
                    // варианты восстановления, нам нужно завершить процесс с ненулевым кодом выхода.
                    Environment.Exit(1);
                }
                else
                {
                    // Назначаем его источник.
                    myLog.Source = "OWL-VMS";

                    // Запишите информационную запись в журнал событий.
                    myLog.WriteEntry(String.Concat("OWL-VMS Запущен: ",DateTime.Now.ToString()));
                }



                while (!stoppingToken.IsCancellationRequested)
                {
                    // Вместо этой заглушки будет создание потоков для записи
                    // 1 поток = 1 камера
                    Thread.Sleep(10000);
                    myLog.WriteEntry(String.Concat("OWL-VMS работает: ", DateTime.Now.ToString()));

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);

                // Завершает этот процесс и возвращает код выхода операционной системе.
                // Это необходимо, чтобы избежать «BackgroundServiceExceptionBehavior», который
                // выполняет один из двух сценариев:
                // 1. Если установлено значение «Игнорировать»: вообще ничего не будет делать, ошибки вызывают службы-зомби.
                // 2. Если установлено значение «StopHost»: будет корректно останавливаться хост и записываться ошибки.
                //
                // Чтобы система управления службами Windows могла использовать настроенные
                // варианты восстановления, нам нужно завершить процесс с ненулевым кодом выхода.
                Environment.Exit(1);
            }
        }
    }


        
}
