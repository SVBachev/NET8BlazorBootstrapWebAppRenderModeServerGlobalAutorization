�������� ������ Windows
	sc.exe create ".NET Joke Service" binpath="C:\Path\To\App.WindowsService.exe"

	���� ��� ����� �������� ������ ����������� ������������ ����, �� ������ �������� ��� � �������� ��������� ��������� ������ ��� �������� binpath:
	sc.exe create "Svc Name" binpath="C:\Path\To\App.exe --contentRoot C:\Other\Path"

��������� ������ Windows

    �������� ��������
	sc.exe qfailure "<Service Name>"

	����� ��������� ��������������, ����������� ������� sc.exe failure "<Service Name>"

	sc.exe failure ".NET Joke Service" reset=0 actions=restart/60000/restart/60000/run/1000


