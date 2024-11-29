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
            // ��������� ������ (�� ������ �������������� ������, ����� � ��������� ������)
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                // �������� ��������� EventLog
                EventLog myLog = new EventLog();

                // ������ ��������, ���� �� ��� �� ����������.
                if (!EventLog.SourceExists("OWL-VMS"))
                {

                    // �������� ������� ������� �� ������� ��������� � ����� ������������.
                    // ��� ��������� ��������� ���������� ����� ��������, ��� ���������� �������
                    // ����� ����������� ����������, ������������� �������� ���.
                    // ��������� ���� ������ ������ ���, ����� ������������ ����� ��������.
                    EventLog.CreateEventSource("OWL-VMS", "OWL-VMS-LOG");

                    // �������� ������.  ������� �� ����������, ����� ��������� ��� �����������.
                    // ����� ������� ���������� �������� Windows ����� ������������ �����������
                    // �������� ��������������, ��� ����� ��������� ������� � ��������� ����� ������.
                    Environment.Exit(1);
                }
                else
                {
                    // ��������� ��� ��������.
                    myLog.Source = "OWL-VMS";

                    // �������� �������������� ������ � ������ �������.
                    myLog.WriteEntry(String.Concat("OWL-VMS �������: ",DateTime.Now.ToString()));
                }



                while (!stoppingToken.IsCancellationRequested)
                {
                    // ������ ���� �������� ����� �������� ������� ��� ������
                    // 1 ����� = 1 ������
                    Thread.Sleep(10000);
                    myLog.WriteEntry(String.Concat("OWL-VMS ��������: ", DateTime.Now.ToString()));

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);

                // ��������� ���� ������� � ���������� ��� ������ ������������ �������.
                // ��� ����������, ����� �������� �BackgroundServiceExceptionBehavior�, �������
                // ��������� ���� �� ���� ���������:
                // 1. ���� ����������� �������� ��������������: ������ ������ �� ����� ������, ������ �������� ������-�����.
                // 2. ���� ����������� �������� �StopHost�: ����� ��������� ��������������� ���� � ������������ ������.
                //
                // ����� ������� ���������� �������� Windows ����� ������������ �����������
                // �������� ��������������, ��� ����� ��������� ������� � ��������� ����� ������.
                Environment.Exit(1);
            }
        }
    }


        
}
