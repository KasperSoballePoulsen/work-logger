# Work Logger
Work Logger er en applikation designet til at hjælpe brugere med at registrere og administrere deres arbejdstimer effektivt. Projektet er bygget med en trelags-arkitektur og indebærer både en WPF desktop-applikation og en ASP.NET webapplikation.

## Funktioner
- **Tidsregistrering**: Log dine arbejdstimer med start- og sluttidspunkter.
- **Projektstyring**: Opret og administrer projekter (arbejdssager) og tilknyt arbejdstimer til dem.
- **Opret medarbejdere**: Opret og administrere medarbejdere.
- **Brugergrænseflader**:
  - WPF desktop-applikation
  - ASP.NET webapplikation
- **Databasehåndtering via Entity Framework 6**
- **Adskilt arkitektur**: Brug af DAL, BLL og DTO til klar adskillelse mellem lag

## Teknologier
- **Sprog**: C#
- **Frameworks**:
  - .NET Framework
  - WPF
  - ASP.NET MVC
- **ORM**: Entity Framework 6
- **Database**: SQL Server Express 
- **Arkitektur**: 3-lags arkitektur (DAL, BLL, DTO, UI)

## Kom godt i gang
- Visual Studio 2019 eller nyere
- .NET Framework udviklingsværktøjer
- SQL Server Express eller anden kompatibel database
- Entity Framework 6 installeret

### Installation
1. **Klon projektet**:
   ```bash
   git clone https://github.com/KasperSoballePoulsen/work-logger.git

2. **Åbn løsningen**:
Åbn WorkLogger.sln i Visual Studio.
3. **Konfigurer database**:
Sørg for at connection string i App.config eller Web.config peger på din database.
Kør nødvendige Entity Framework-migrationer hvis det er sat op.
4. **Kør applikationen**:
WPF: Sæt WpfApp som startprojekt og tryk Start.
Web: Sæt WebApp som startprojekt og kør via browser.


