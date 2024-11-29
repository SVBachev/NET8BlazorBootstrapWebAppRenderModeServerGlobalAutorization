Создание службы Windows
	sc.exe create ".NET Joke Service" binpath="C:\Path\To\App.WindowsService.exe"

	Если вам нужно изменить корень содержимого конфигурации узла, вы можете передать его в качестве аргумента командной строки при указании binpath:
	sc.exe create "Svc Name" binpath="C:\Path\To\App.exe --contentRoot C:\Other\Path"

Настройка службы Windows

    Просмотр настроек
	sc.exe qfailure "<Service Name>"

	Чтобы настроить восстановление, используйте команду sc.exe failure "<Service Name>"

	sc.exe failure ".NET Joke Service" reset=0 actions=restart/60000/restart/60000/run/1000


