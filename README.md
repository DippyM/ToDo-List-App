ToDo List Aplikace
Jednoduchá WPF (Windows Presentation Foundation) aplikace pro správu úkolů, vytvořená v C# a XAML. Tato aplikace ToDo List umožňuje uživatelům přidávat, upravovat a odstraňovat úkoly. Také podporuje kategorizaci úkolů, správu termínů pomocí výběru dat a zobrazení popisů úkolů.

Funkce
Přidávání úkolů s názvem, popisem a datem splnění.
Označení úkolů jako hotových pomocí dvojkliku.
Přesouvání úkolů mezi aktivními a hotovými seznamy pomocí dvojkliku.
Úprava úkolů po kliknutí pravým tlačítkem, včetně názvu, popisu a termínu splnění.
Kategorizace úkolů na základě termínů splnění, které jsou automaticky formátovány ve formátu dd/MM/yyyy.
Automatická změna barev úkolů podle blížícího se termínu:
Červená pro úkoly, které jsou do jednoho dne nebo již prošly.
Oranžová pro úkoly, které jsou do tří dnů.
Zelená pro úkoly s delší dobou splnění.
Lokalizace
Plná podpora české lokalizace: Všechna data jsou zobrazována v českém formátu (dd/MM/yyyy) a třídění úkolů podle měsíců používá české názvy měsíců.
Jak používat
Přidání úkolu: Zadejte název úkolu, popis a vyberte datum splnění pomocí kalendáře "Vyber datum".
Úprava úkolu: Klikněte pravým tlačítkem na úkol a upravte jeho detaily.
Označení úkolu jako hotového: Dvojklikem na úkol jej označíte jako hotový a přesunete jej do seznamu hotových úkolů.
Znovuotevření úkolu: Dvojklikem na hotový úkol jej přesunete zpět do seznamu aktivních úkolů.
Začínáme
Požadavky
Visual Studio s podporou .NET pro WPF.
.NET Framework 4.7.2 nebo novější.
Spuštění aplikace
Naklonujte repozitář:

bash
Zkopírovat kód
git clone https://github.com/tvoje-username/todolist-app.git
Otevřete projekt ve Visual Studiu.

Sestavte a spusťte aplikaci.

Struktura projektu
MainWindow.xaml: Hlavní okno, kde uživatel spravuje úkoly.
MainWindow.xaml.cs: Backend logika pro správu úkolů.
EditTaskWindow.xaml: Dialogové okno pro úpravu úkolů.
EditTaskWindow.xaml.cs: Backend logika pro okno úpravy úkolů.
Příspěvky
Rádi přivítáme jakékoliv příspěvky nebo vylepšení. Neváhejte zaslat pull request.
