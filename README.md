# ToDo List Aplikace

Jednoduchá WPF (Windows Presentation Foundation) aplikace pro správu úkolů, vytvořená v C# a XAML. Tato aplikace umožňuje uživately přidávat, upravovat a odstraňovat úkoly, označovat je jako hotové, a to vše s podporou české lokalizace.

## Funkce

- **Přidávání úkolů** s názvem, popisem a datem splnění.
- **Označení úkolů jako hotových** pomocí dvojkliku.
- **Přesouvání úkolů** mezi aktivními a hotovými seznamy dvojklikem.
- **Úprava úkolů** po kliknutí pravým tlačítkem, včetně názvu, popisu a termínu splnění.
- **Barevné rozlišení úkolů** podle blížícího se termínu:
  - Červená pro úkoly, které mají termín splnění do jednoho dne nebo jsou již prošlé.
  - Oranžová pro úkoly s termínem splnění do tří dnů.
  - Zelená pro úkoly s delší dobou splnění.
  
## Lokalizace

- **Plná podpora české lokalizace**: Všechny datumy jsou zobrazovány v českém formátu (dd/MM/yyyy) a hotové úkoly jsou tříděny podle českých názvů měsíců.

## Jak používat

1. **Přidání úkolu**: Zadejte název úkolu, popis a vyberte datum splnění pomocí kalendáře "Vyber datum".
2. **Úprava úkolu**: Klikněte pravým tlačítkem na úkol a upravte jeho detaily (název, popis, datum).
3. **Označení úkolu jako hotového**: Dvojklikem na úkol jej přesunete do seznamu hotových úkolů.
4. **Znovuotevření úkolu**: Dvojklikem na hotový úkol jej přesunete zpět do aktivních úkolů.

## Instalace

### Požadavky

- Visual Studio s podporou .NET pro WPF.
- .NET Framework 4.7.2 nebo novější.

### Spuštění aplikace

1. Naklonujte tento repozitář:
   ```bash
   git clone https://github.com/DippyM/ToDo-List-App.git

2. Otevřete projekt ve Visual Studiu.

3. Sestavte projekt a spusťte aplikaci.

# Struktura projektu
MainWindow.xaml: Hlavní okno, kde uživatel spravuje úkoly.
MainWindow.xaml.cs: Backend logika pro správu úkolů.
EditTaskWindow.xaml: Dialogové okno pro úpravu úkolů.
EditTaskWindow.xaml.cs: Backend logika pro úpravu úkolů.
# Příspěvky
Rád přivítám jakékoliv návrhy na vylepšení nebo opravy. Neváhejte zaslat pull request.

markdown
Zkopírovat kód

### Jak to použít:
1. Vytvoř ve složce svého projektu nový soubor s názvem **README.md**.
2. Zkopíruj a vlož tento kód do **README.md**.
3. Ulož soubor a pomocí Git ho nahraj na svůj GitHub repozitář.

Tento formát Markdownu (`.md`) zajistí, že se na GitHubu vše správně naformátuje s nadpisy, seznamy a kódy. Dej mi vědět, pokud budeš potřebovat další pomoc!





